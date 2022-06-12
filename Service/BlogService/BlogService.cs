using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SignalRMVCChat.Models.weblog;


namespace SignalRMVCChat.Service
{
    public class BlogService
    {
            private readonly BigPardakht.Data.ApplicationDbContext ApplicationDbContext;

            public BlogService(BigPardakht.Data.ApplicationDbContext ApplicationDbContext)
            {
               this.ApplicationDbContext = ApplicationDbContext;
            }

            // GET
            public List<Blog> Index(BlogType type)
            {
                var list = this.ApplicationDbContext.Blogs.Where(b=>b.Type==type).ToList();

                return list;
            }
    }
}