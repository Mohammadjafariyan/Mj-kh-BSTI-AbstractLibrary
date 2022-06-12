using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class PrintDetailViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(dynamic model)
        {
            return View("Default",model);
        }
    }
}