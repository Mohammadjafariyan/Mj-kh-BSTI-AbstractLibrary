using System.Linq;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace AbstractLibrary.Service
{
    public class SupportedLanguagesService : ISelectListProvider
    {
        private readonly IOptions<RequestLocalizationOptions> _locOptions;

        public SupportedLanguagesService(IOptions<RequestLocalizationOptions> LocOptions)
        {
            _locOptions = LocOptions;
        }

        public SelectList GetSelectList(dynamic value)
        {
            
            var cultureItems = _locOptions.Value.SupportedUICultures
                .Select(c => new SelectListItem {Value = c.Name, Text = c.DisplayName})
                .ToList();

            return new SelectList(cultureItems,  "Value", "Text", value);
        }

        public string GetSelectListSelectedValue(dynamic value)
        {
            var cultureItems = _locOptions.Value.SupportedUICultures
                .Select(c => new SelectListItem {Value = c.Name, Text = c.DisplayName})
                .ToList();

            return cultureItems.Where(s => s.Value == value).Select(s => s.Text).FirstOrDefault();
        }
    }
}