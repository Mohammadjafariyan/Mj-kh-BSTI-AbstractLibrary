using Microsoft.EntityFrameworkCore;
using SignalRMVCChat.Models.HelpDesk;
using SignalRMVCChat.Models.weblog;

namespace WeblogModule.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                /*
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
                */
                
                
                optionsBuilder.UseInMemoryDatabase("Test2");

            }
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<HelpDesk> HelpDesks { get; set; }
        public DbSet<ArticleVisit> ArticleVisits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region HelpDesk

            modelBuilder.Entity<Language>()
                .HasMany(r => r.HelpDesks)
                .WithOne(o => o.Language)
                .HasForeignKey(o => o.LanguageId);

            modelBuilder.Entity<HelpDesk>()
                .HasMany(r => r.Categories)
                .WithOne(o => o.HelpDesk)
                .HasForeignKey(o => o.HelpDeskId);

            /*modelBuilder.Entity<HelpDesk>()
                .HasOne(r => r.MyWebsite)
                .WithMany(o => o.HelpDesks)
                .HasForeignKey(o => o.MyWebsiteId);*/


            modelBuilder.Entity<Category>()
                .HasMany(r => r.Articles)
                .WithOne(o => o.Category)
                .HasForeignKey(o => o.CategoryId);


            modelBuilder.Entity<Article>()
                .HasMany(r => r.ArticleVisits)
                .WithOne(o => o.Article)
                .HasForeignKey(o => o.ArticleId);

            /*modelBuilder.Entity<Article>()
                .HasOne(r => r.ArticleContent)
                .WithOne(o => o.Article)
                .HasForeignKey<ArticleContent>();*/

            #endregion


            #region Blog

            modelBuilder.Entity<Category>()
                .HasMany(r => r.Blogs)
                .WithOne(o => o.Category)
                .HasForeignKey(o => o.CategoryId);

            #endregion
            
            base.OnModelCreating(modelBuilder);
        }
    }
}