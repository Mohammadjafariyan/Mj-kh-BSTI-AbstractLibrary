using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigPardakht.DynamicForm
{
    public interface IFormModel
    {
        Dictionary<string, SelectList> FormData { get; set; }
        Dictionary<string, List<CheckItem>> CheckList { get; set; }
    }


    public class CheckItem
    {

        public string Value { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }
}