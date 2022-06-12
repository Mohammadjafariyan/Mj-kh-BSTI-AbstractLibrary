using System.Threading.Tasks;
using AbstractLibrary.Model;
using BigPardakht.Model;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class TableViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(TableVCModel table)
        {
            return View("Default",table );
        }
    }
}