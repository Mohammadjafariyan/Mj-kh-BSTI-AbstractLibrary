using System.Collections.Generic;
using System.Threading.Tasks;
using BigPardakht.Model;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class PagingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int total, int page)
        {
            return View((total,page));
        }
    }
}