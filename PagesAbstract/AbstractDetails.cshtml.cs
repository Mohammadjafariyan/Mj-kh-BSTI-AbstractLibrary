using System.Linq;
using System.Threading.Tasks;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BigPardakht.PagesAbstract
{
    public class AbstractDetails <T, IRep,TContext> : AbstractPage where T : class, IEntity where IRep : IRepository<T,TContext>
    {
        protected IRep Repository;
        private readonly ILogger _logger;


        public AbstractDetails(IRep repository,ILogger<BigPardakht.PagesAbstract.AbstractDetails<T,IRep,TContext>> logger)
        {
            this.Repository = repository;
            _logger = logger;
        }

        
        [BindProperty(SupportsGet = true)]
        public T Entity { get; set; }

        public virtual async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Entity = await AddIncludes(Repository.Get()).FirstOrDefaultAsync(m => m.Id == id);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        
        
        public virtual  IQueryable<T> AddIncludes(IQueryable<T> queryable)
        {
            return queryable;
            //        ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");

        }
    }
}
