using System.Linq;
using System.Threading.Tasks;
using AbstractLibrary.Model.File;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BigPardakht.PagesAbstract
{
    //[AbstractLibrary.Installation.AnyRequestFilter]          

    public class AbstractSave<T, TRep, TContext> : AbstractPage where T : class, IEntity, new()
        where TRep : IRepository<T, TContext>
    {
        protected TRep Repository;

        protected readonly ILogger<BigPardakht.PagesAbstract.AbstractSave<T, TRep, TContext>> _logger;
        protected TContext _context;


        public AbstractSave(TRep repository, ILogger<BigPardakht.PagesAbstract.AbstractSave<T, TRep, TContext>> logger)
        {
            this.Repository = repository;
            _context = repository.GetContext();
            _logger = logger;
        }

        [FromQuery] public int? Id { get; set; }


        [FromQuery] public string RedirectUrl { get; set; }

        [BindProperty] public T Model { get; set; }


        public virtual async Task<IActionResult> OnGet()
        {
            Model = new T();

            Model.Id = 0;

            _logger.Log(LogLevel.Information, "onget", Id);
            if (Id.HasValue)
            {
                Model = Repository.GetById(Id.Value, null, this.Includes);
            }

            SetDropdowns();

            return Page();
        }

        protected virtual IQueryable<T> Includes(IQueryable<T> arg)
        {
            return arg;
        }


        public virtual async Task<IActionResult> OnPostAsync()
        {
            _logger.Log(LogLevel.Information, "OnPostAsync ModelState", ModelState);
            if (!ModelState.IsValid)
            {
                SetDropdowns();
                return Page();
            }

            if (Model is IFileSupport)
            {
                var model = (IFileSupport) Model;

                model.Files = model.FilesBind?.Split(",")
                    .Where(s => string.IsNullOrEmpty(s) == false)
                    .Select(s => int.Parse(s)).ToArray();
            }

            _logger.Log(LogLevel.Information, "OnPostAsync Model", Model);
            await Repository.SaveAsync(Model);

            _logger.Log(LogLevel.Information, "OnPostAsync RedirectUrl", RedirectUrl);
            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                return RedirectToPage(RedirectUrl);
            }
            else
            {
                SetDropdowns();
                return RedirectToPage("Index");

            }
        }


        public virtual async void SetDropdowns()
        {
            //        ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
        }
    }
}