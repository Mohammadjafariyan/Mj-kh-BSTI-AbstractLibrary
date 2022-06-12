using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AbstractLibrary.Data.Models.autoGeneratedContext;
using AbstractLibrary.Model.FrontModel;
using AbstractLibrary.Model.MarketModel;
using AbstractLibrary.Model.SiteCommonModel;
using AbstractLibrary.Model.User;
using BigPardakht.Model;
using BigPardakht.Model.User;
using FileModule.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using my_webapp.Model;
using Newtonsoft.Json;
using SignalRMVCChat.Models;
using SignalRMVCChat.Models.autoGeneratedContext;
using SignalRMVCChat.Models.HelpDesk;
using SignalRMVCChat.Models.weblog;
using SignalRMVCChat.Service;
using File = System.IO.File;

namespace BigPardakht.Data
{
    public  class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext()
        {
        }


        #region Blog Package

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<HelpDesk> HelpDesks { get; set; }
        public DbSet<ArticleVisit> ArticleVisits { get; set; }

        #endregion

        #region FrontPackage

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<Slide> Slides { get; set; }

        #endregion


        #region MarketPackage

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductPropertyValue> ProductPropertyValues { get; set; }

        #endregion


        #region SiteCommonPackage

        public DbSet<SiteConst> SiteConsts { get; set; }
        public DbSet<NewsSettler> NewsSettlers { get; set; }

        #endregion


        #region Other

        public DbSet<Setting> Settings { get; set; }


        #endregion

        #region File

        public DbSet< FileModule.Model.File> Files { get; set; }
        public DbSet<FileContent> FileContents { get; set; }

        #endregion

        public void DetachAll()
        {
            foreach (EntityEntry entityEntry in this.ChangeTracker.Entries().ToArray())
            {
                if (entityEntry.Entity != null)
                {
                    entityEntry.State = EntityState.Detached;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FrontPackage

            modelBuilder.Entity<Menu>()
                .HasOne(s => s.MenuCategory)
                .WithMany(s => s.MenuList)
                .HasForeignKey(s => s.MenuCategoryId);

            modelBuilder.Entity<SlideShow>()
                .HasOne(s => s.Slide)
                .WithMany(s => s.SlideShows)
                .HasForeignKey(s => s.SlideId);

            modelBuilder.Entity<SlideShow>()
                .HasOne(s => s.Product)
                .WithMany(s => s.SlideShows)
                .HasForeignKey(s => s.ProductId).IsRequired(false);

            modelBuilder.Entity<SlideShow>()
                .HasOne(s => s.ProductCategory)
                .WithMany(s => s.SlideShows)
                .HasForeignKey(s => s.ProductCategoryId).IsRequired(false);
            
            
            /*
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.OwnsOne(e => e.Title);
            });       
            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.OwnsOne(e => e.Title);
            }); */
            
      

            #endregion


            #region MarketPackage

            modelBuilder.Entity<Product>()
                .HasOne(s => s.ProductCategory)
                .WithMany(s => s.ProductList)
                .HasForeignKey(s => s.ProductCategoryId);

            modelBuilder.Entity<ProductPropertyValue>()
                .HasOne(s => s.Product)
                .WithMany(s => s.ProductPropertyValueList)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<ProductPropertyValue>()
                .HasOne(s => s.ProductProperty)
                .WithMany(s => s.ProductPropertyValueList)
                .HasForeignKey(s => s.ProductPropertyId);

            /*modelBuilder.Entity<Product>(entity =>
            {
                //entity.OwnsOne(e => e.Description);
                entity.OwnsOne(e => e.Title);
            });
         
            /*modelBuilder.Entity<ProductPropertyValue>(entity =>
            {
                entity.OwnsOne(e => e.TextValue);
            });#1#
            
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.OwnsOne(e => e.Title);
            });   
            
            modelBuilder.Entity<ProductProperty>(entity =>
            {
                entity.OwnsOne(e => e.Title);
            });*/ 
            #endregion


            #region SiteCommonPackage

                 
            /*
            modelBuilder.Entity<SiteConst>(entity =>
            {
                entity.OwnsOne(e => e.Title);
            }); */
            #endregion


            #region Blog Package

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

            #endregion


            #region FilePackage

            modelBuilder.Entity< FileModule.Model.File>()
                .HasOne(s => s.FileContent)
                .WithOne(s => s.File)
                .HasForeignKey<FileContent>(s => s.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
            /*
            #region GatewayWallet

            builder.Entity<GatewayWallet>()
                .HasOne(a => a.PaymentGateway)
                .WithMany(a => a.GatewayWallets)
                .HasForeignKey(e => e.PaymentGatewayId);


            builder.Entity<GatewayWallet>()
                .HasOne(a => a.Wallet)
                .WithMany(a => a.GatewayWallets)
                .HasForeignKey(e => e.WalletId);

            #endregion
            */


            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DbContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        private void Seed(ModelBuilder builder)
        {
            if (MyGlobal.FakeData)
            {
                //   DebugDbSeed.Seed(builder);
            }
        }


        #region general

        public DbSet<ContactForm> ContactForms { get; set; }

        #endregion
    }
}