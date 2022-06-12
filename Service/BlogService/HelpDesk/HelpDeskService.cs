using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AbstractLibrary.Repository;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SignalRMVCChat.Models.HelpDesk;


namespace SignalRMVCChat.Service.HelpDesk
{
    public class HelpDeskService : SafeDeleteRepository<Models.HelpDesk.HelpDesk, BigPardakht.Data.ApplicationDbContext>
    {
        private CategoryImageService CategoryImageService;

        public HelpDeskService(ApplicationDbContext dbContext, CategoryImageService categoryImageService,
            IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            CategoryImageService = categoryImageService;
        }


        public async Task<HelpDeskHomeViewModel> GetHelpDeskHome(string lang, string searchTerm = null)
        {
            using (var db = new BigPardakht.Data.ApplicationDbContext())
            {
                if (db == null)
                {
                    throw new Exception("db is null ::::::");
                }

                var query = GetHelpDeskQuery(db, lang);

                var helpDeskIds = query.Select(q => q.Id);

                var cateogies = db.Categories.Where(c => helpDeskIds.Contains(c.HelpDeskId));

                var categoryIds = cateogies.Select(c => c.Id);


                var articlesQuery = db.Articles
                    .AsQueryable();

                // -------------------- search
                if (string.IsNullOrEmpty(searchTerm) == false)
                {
                    articlesQuery = articlesQuery.Where(
                        a => a.Title.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Description.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Summary.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.textValue.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Keywords.ToLower().Contains(searchTerm.ToLower())
                    );
                }
                // -------------------- search end


                var articles = articlesQuery
                    .Include(a => a.ArticleVisits)
                    .Where(a => a.CategoryId.HasValue && categoryIds.Contains(a.CategoryId.Value))
                    .OrderByDescending(a => a.ArticleVisits.Count()).Take(10).ToListAsync();

                var helpDesk = await query.FirstOrDefaultAsync();

                if (helpDesk == null)
                {
                    throw new Exception(" " +
                                        "فعلا مرکز پشتیبانی برای این سایت تعریف نشده است" +
                                        @"<span> <a href=""/Language"">پیکربندی مرکز پشتیبانی </a></span>"
                    );
                }

                var languages = GetLanguages(query, db);


                return new HelpDeskHomeViewModel
                {
                    Articles = await articles,
                    Categories = await cateogies.ToListAsync(),
                    HelpDesk = helpDesk,
                    Languages = await languages.ToListAsync(),
                };
            }
        }

        private IQueryable<Models.HelpDesk.Language> GetLanguages(IQueryable<Models.HelpDesk.HelpDesk> query,
            BigPardakht.Data.ApplicationDbContext db)
        {
            var thisWebsiteAllHelpDesks =
                db.HelpDesks; //.Where(h => query.Select(q => q.MyWebsiteId).Contains(h.MyWebsiteId));

            return thisWebsiteAllHelpDesks.Include(h => h.Language)
                .Select(h => h.Language);
        }

        private IQueryable<Models.HelpDesk.HelpDesk> GetHelpDeskQuery(
            BigPardakht.Data.ApplicationDbContext gapChatContext,
            string lang)
        {
            var query = gapChatContext.HelpDesks
                .Include(c => c.Language).AsQueryable();
            /*
            .Include(c => c.MyWebsite)
            .Where(c => c.MyWebsite.BaseUrl.Contains(websiteBaseUrl));
            */


            if (!string.IsNullOrEmpty(lang))
            {
                query = query.Where(c => c.Language.Code.ToLower() == lang.ToLower());
            }
            else
            {
                //query = query.Where(c => c.Selected);
            }

            return query;
        }

        public async Task<string> GetHelpDeskImage(int id)
        {
            return await CategoryImageService.Get()
                .Where(c => c.Id == id).Select(c => c.Content)
                .FirstOrDefaultAsync();
        }

        public async Task<ArticleViewModel> GetHelpDeskArticle(string title, string lang, HttpRequest request)
        {
            using (var db = new BigPardakht.Data.ApplicationDbContext())
            {
                if (db == null)
                {
                    throw new Exception("db is null ::::::");
                }

                var query = GetHelpDeskQuery(db, lang);

                var helpDeskIds = query.Select(q => q.Id);

                var cateogies = db.Categories.Where(c => helpDeskIds.Contains(c.HelpDeskId));

                var categoryIds = cateogies.Select(c => c.Id);

                var articles = db.Articles
                    .Include(c => c.Category)
                    .Where(a => a.CategoryId.HasValue && categoryIds.Contains(a.CategoryId.Value));

                var article = articles.Where(c => c.Title.Contains(title)).FirstOrDefault();
                if (article == null)
                {
                    throw new Exception("مقاله یافت نشد");
                }

                var relatedArticles = articles.Where(c => c.Id != article.Id)
                    .OrderByDescending(o => o.Id).Take(10).ToList();


                var helpDesk = query.FirstOrDefault();


                if (request != null)
                {
                    db.ArticleVisits.Add(new ArticleVisit
                    {
                        ArticleId = article.Id,
                        DateTime = DateTime.Now,
                        IpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        UserAgent = request.HttpContext.Request.Headers["User-Agent"].ToString(),
                        Browser = request.HttpContext.Request.Headers["User-Agent"].ToString(),
                    });

                    db.SaveChanges();
                }


                var languages = GetLanguages(query, db);

                return new ArticleViewModel
                {
                    Article = article,
                    RelatedArticles = relatedArticles,
                    HelpDesk = helpDesk,
                    Languages = await languages.ToListAsync()
                };
            }
        }

        public async Task<CategoryArticlesViewModel> GetHelpDeskArticleByCategoryTitle(string categoryTitle,
            string lang)
        {
            using (var db = new BigPardakht.Data.ApplicationDbContext())
            {
                if (db == null)
                {
                    throw new Exception("db is null ::::::");
                }

                var query = GetHelpDeskQuery(db, lang);

                var helpDeskIds = query.Select(q => q.Id);

                var cateogies = db.Categories.Where(c => helpDeskIds.Contains(c.HelpDeskId));

                var categoryIds = cateogies.Select(c => c.Id);

                var articles = db.Articles
                    .Include(c => c.Category)
                    .Where(a => a.CategoryId.HasValue && categoryIds.Contains(a.CategoryId.Value))
                    .AsQueryable();


                articles = articles.Where(c => c.Category.Name.Contains(categoryTitle));


                var category = cateogies.Where(c => c.Name.Contains(categoryTitle)).FirstOrDefault();
                if (category == null)
                {
                    throw new Exception("دسته بندی یافت نشد");
                }


                var helpDesk = query.FirstOrDefault();

                var languages = GetLanguages(query, db);


                return new CategoryArticlesViewModel
                {
                    Articles = articles.ToList(),
                    Cateogies = cateogies.ToList(),
                    Category = category,
                    HelpDesk = helpDesk,
                    Languages = await languages.ToListAsync()
                };
            }
        }


        public async Task<CategoryArticlesViewModel> Search(string lang,
            string searchTerm)
        {
            using (var db = new BigPardakht.Data.ApplicationDbContext())
            {
                if (db == null)
                {
                    throw new Exception("db is null ::::::");
                }

                var query = GetHelpDeskQuery(db, lang);

                var helpDeskIds = query.Select(q => q.Id);

                var cateogies = db.Categories.Where(c => helpDeskIds.Contains(c.HelpDeskId));

                var categoryIds = cateogies.Select(c => c.Id);


                var articlesQuery = db.Articles.AsQueryable();

                // -------------------- search
                if (string.IsNullOrEmpty(searchTerm) == false)
                {
                    articlesQuery = articlesQuery.Where(
                        a => a.Title.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Description.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Summary.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.textValue.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                             a.Keywords.ToLower().Contains(searchTerm.ToLower()) ||
                             a.Category.Name.ToLower().Contains(searchTerm.ToLower())
                    );
                }
                // -------------------- search end

                var articles = articlesQuery
                    .Include(c => c.Category)
                    .Where(a => a.CategoryId.HasValue && categoryIds.Contains(a.CategoryId.Value))
                    .AsQueryable();


                var helpDesk = query.FirstOrDefault();

                var languages = GetLanguages(query, db);


                return new CategoryArticlesViewModel
                {
                    Articles = articles.ToList(),
                    Cateogies = cateogies.ToList(),
                    Category = new Category
                    {
                        Name = "جستجو"
                    },
                    HelpDesk = helpDesk,
                    Languages = await languages.ToListAsync()
                };
            }
        }
    }

    public class CategoryArticlesViewModel
    {
        public List<Models.HelpDesk.Article> Articles { get; set; }
        public List<Category> Cateogies { get; set; }
        public Category Category { get; set; }
        public Models.HelpDesk.HelpDesk HelpDesk { get; set; }
        public List<Models.HelpDesk.Language> Languages { get; set; }
    }

    public class ArticleViewModel
    {
        public Models.HelpDesk.Article Article { get; set; }
        public List<Models.HelpDesk.Article> RelatedArticles { get; set; }
        public Models.HelpDesk.HelpDesk HelpDesk { get; set; }
        public List<Models.HelpDesk.Language> Languages { get; set; }
    }

    public class HelpDeskHomeViewModel
    {
        public List<Models.HelpDesk.Article> Articles { get; set; }
        public List<Category> Categories { get; set; }
        public Models.HelpDesk.HelpDesk HelpDesk { get; set; }
        public List<Models.HelpDesk.Language> Languages { get; set; }
    }
}