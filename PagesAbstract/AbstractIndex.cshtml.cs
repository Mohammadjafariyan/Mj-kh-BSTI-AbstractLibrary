using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AbstractLibrary.Model;
using BigPardakht.Model;
using BigPardakht.Model.Service;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BigPardakht.PagesAbstract
{
    public class AbstractIndex<T, IRep,TContext> : AbstractPage where T : class , IEntity, new() where IRep : IRepository<T,TContext>
    {
        protected IRep Repository;
        private readonly ILogger<BigPardakht.PagesAbstract.AbstractIndex<T, IRep,TContext>> _logger;

        protected IExportDocxService DocxService;
        protected IHostingEnvironment _hostingEnvironment;

        public AbstractIndex(IRep repository, ILogger<BigPardakht.PagesAbstract.AbstractIndex<T, IRep,TContext>> logger)
        {
            this.Repository = repository;
            SuccessMessage = "با موفقیت ثبت شد";
            ErrorMessage = "خطا هیج کدی ارسال نشده است";
            _logger = logger;
        }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        [FromQuery] public int? Page { get; set; }
        [FromQuery] public int? Id { get; set; }


        [FromQuery] public string Search { get; set; }

        public MyDataTableResponse<T> Records { get; set; }


        public virtual async Task<IActionResult> OnGet()
        {
            var query = Repository.Get();


            query = Includes(query);

            if (string.IsNullOrEmpty(Search) == false)
            {
                query = ApplySearch(query);
            }


            if (Page.HasValue)
            {
                Records = await MyGlobal.Paging<T>(query, MyGlobal.TakeConst, Page.Value);
            }
            else
            {
                Records = await MyGlobal.Paging<T>(query, MyGlobal.TakeConst, null);
            }

            return Page();
        }

        
        public virtual async Task<IActionResult> OnPostExtractDocxAsync()
        {
           
            var list = await Repository.Get().ToListAsync();

            
            string filePath = Path.Combine(this._hostingEnvironment.WebRootPath, "Print/");
            DocxService.basePath = filePath;


          var path=  DocxService.ExportDocx(new Dictionary<string, string>(),
                new TableVCModel
                {
                    table = new MyDataTableResponse<T>
                    {
                        EntityList = list
                    }
                }, "PrintTableReport.docx", new T());

            return DownloadFile(path);
        }
        protected virtual IQueryable<T> Includes(IQueryable<T> query)
        {
            return query;
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!Id.HasValue)
            {
                TempData[MyGlobal.ErrorMessage] = ErrorMessage;
                return Page();
            }

            Repository.Delete(Id.Value);

            TempData[MyGlobal.SuccessMessage] = SuccessMessage;
            return Page();
        }*/


        protected virtual IQueryable<T> ApplySearch(IQueryable<T> query)
        {
            return query;
        }
    }
}