using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class FormBuilderViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(dynamic model)
        {
            return View(model);
        }
    }
}