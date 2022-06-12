using System;
using System.Threading.Tasks;
using BigPardakht.Model;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.ViewComponents
{
    [ViewComponent]
    public class HorizontalTableViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(dynamic table,dynamic m,
            Func<dynamic,string> actionPart=null,
            Func<dynamic,string,dynamic, string> customRecordPart=null,
            Func<dynamic,string> editUrl=null,
            Func<dynamic,string> deleteUrl=null,
            Func<dynamic,string> createUrl=null)
        {
            return View("Default",(m,table,actionPart,customRecordPart,
                    editUrl,deleteUrl,createUrl) );
        }
    }
}