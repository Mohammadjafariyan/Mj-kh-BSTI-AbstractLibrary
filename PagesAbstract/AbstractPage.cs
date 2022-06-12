using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigPardakht.PagesAbstract
{
    
    public class AbstractPage:PageModel
    {
        
        public FileResult DownloadFile(string path)
        {
            var fileName = Path.GetFileName(path);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        
    }
}