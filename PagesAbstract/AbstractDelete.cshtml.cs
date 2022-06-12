using System.Threading.Tasks;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BigPardakht.PagesAbstract
{
    public class AbstractDelete<T, IRep,TContext> : AbstractPage where T : class, IEntity where IRep : IRepository<T,TContext>
    {
        protected IRep Repository;
        private readonly ILogger _logger;


        public AbstractDelete(IRep repository, ILogger<BigPardakht.PagesAbstract.AbstractDelete<T, IRep,TContext>> logger)
        {
            this.Repository = repository;
            _logger = logger;
        }

        [BindProperty] public T Entity { get; set; }

                
               
        [FromQuery]
        public string RedirectUrl { get; set; }
        
        public virtual async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entity = await Repository.Get().FirstOrDefaultAsync(m => m.Id == id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            Entity = await Repository.GetByIdAsync(id.Value);

            if (Entity != null)
            {
                await Repository.DeleteAsync(id.Value);
            }

            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                return RedirectToPage(RedirectUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}