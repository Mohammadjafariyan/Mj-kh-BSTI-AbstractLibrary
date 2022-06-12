using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class RichTextViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(string propertyName,
            string label,string preValue)
        {
            return View("Default", (propertyName,
                 label,preValue));
        }
    }
}