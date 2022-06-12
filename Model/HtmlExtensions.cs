using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text.Encodings.Web;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model;
using AbstractLibrary.Model.MarketModel;
using AbstractLibrary.Model.MultiLanguageModel;
using AbstractLibrary.Model.MultiLanguageModel.MultiLanguageService;
using AbstractLibrary.Model.SiteCommonModel;
using FileModule.Model;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NBitcoin;
using SignalRMVCChat.Service.HelpDesk.Language;
using Xceed.Document.NET;
using Language = SignalRMVCChat.Models.HelpDesk.Language;

namespace BigPardakht.Model
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return MyGlobal.GetTranslate()[enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName()];
        }
    }

    public static class HtmlExtensions
    {
        public static string SlickSliderItem(this IHtmlHelper html, Product product,
            IRequestCultureFeature cultureFeature,
            List<SiteConst> siteConsts)
        {
            return $@"

<div class=""card"" >
                                    <img class=""card-img-top"" src=""{product.Files.GetSingleFileUrl()}"" alt=""Card image"">
                <div class=""card-body"">
                <h4 class=""card-title"">{product.Title.GetTranslateText(cultureFeature)}</h4>
                <p class=""card-text"">{product.Cost}</p>
                <a href=""#"" class=""btn btn-primary"">{LanguageHelpService.GetText(siteConsts, cultureFeature, "add to cart", "افزودن به سبد")}</a>
                </div>
                </div>

";
        }
        /*public static object AnyNewTicketReceied(this IHtmlHelper html, 
            ClaimsPrincipal user, MyCommonService myCommonService)
        {
            int count= myCommonService.AnyNewTicketReceied(user);
        }*/

        public static void AddToHiddens(this ITempDataDictionary tempData, string name)
        {
            tempData["hidden"] = new NameValueCollection();
            ((NameValueCollection) tempData["hidden"])[name] = true.ToString();
        }

        public static IHtmlContent TranslationInputs(this IHtmlHelper html, string inputName, string textLabel,
            TranslateInputsSettingViewModel translateInputViewModel)
        {
            string output = "";
            for (int i = 0; i < translateInputViewModel.Translates.Count; i++)
            {
                output += @$"
 
<div class=""form-group"">

<label>{textLabel}   به {translateInputViewModel.Translates[i].LanguageName}</label>
<input type=""text"" class=""form-control""
                                   id=""{inputName}"" name=""{inputName}[{i + 1}].Text"" value=""{translateInputViewModel.Translates[i].Text}"">


                
                    <input  type=""hidden"" name=""{inputName}[{i + 1}].Code"" value=""{translateInputViewModel.Translates[i].Code}""/>
                    <input  type=""hidden"" name=""{inputName}[{i + 1}].LanguageName"" value=""{translateInputViewModel.Translates[i].LanguageName}""/>

</div>

";
            }

            return html.Raw(output);
        }


        public static bool IsInHiddenList(this ITempDataDictionary tempData, string name)
        {
            NameValueCollection hiddens = tempData["hidden"] as NameValueCollection;
            if (hiddens == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(hiddens.Get(name)))
            {
                return true;
            }

            return false;
        }

        public static IHtmlContent ShowFiles(this IHtmlHelper html, int[] files)
        {
            string output = "";
            for (int i = 0; i < files.Length; i++)
            {
                output += @$"

<div class=""card"" >
<img class=""card-img-top"" src=""/file/byId?fileId={files[i]}""  style=""width:15vw;height:15vh""/>

</div>
";
            }

            return html.Raw(output);
        }

        public static IHtmlContent Help(this IHtmlHelper html, PropertyInfo property)
        {
            if (property == null)
            {
                return html.Raw("");
            }

            var customAttribute = property.GetCustomAttributes(typeof(MyAbstractAttribute))
                .Cast<MyAbstractAttribute>();


            if (customAttribute == null || customAttribute?.Any() == false || customAttribute?.Any() == null)
            {
                return html.Raw("");
            }

            var message = customAttribute.Where(s => s.Help != null).Select(s => s.Help).FirstOrDefault();

            if (string.IsNullOrEmpty(message))
            {
                return html.Raw("");
            }

            return html.Raw(@$"
                <small>{message}</small>
                    ");
        }

        public static IHtmlContent ShowFiles(this IHtmlHelper html, string files)
        {
            string output = "";
            if (string.IsNullOrEmpty(files))
            {
                output = "";
            }
            else
            {
                var arr = files.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    output += @$"

<img  src=""/file/byId?fileId={arr[i]}""  style=""width:15vw;height:15vh""/>
";
                }
            }

            return html.Raw(output);
        }

        public static IHtmlContent AddParamIfNotExist(this IHtmlHelper html, IQueryCollection query,
            string parameter)
        {
            var val = query[parameter];

            return html.Raw(!string.IsNullOrEmpty(query[parameter]) ? @$"?{parameter}={val}" : "");
        }

        public static IHtmlContent ShowImage(this IHtmlHelper html,
            FileContent fileContent)
        {
            string base64String = Convert.ToBase64String(fileContent.Content
                , 0, fileContent.Content.Length);
            string src = "data:image/jpg;base64," + base64String;

            return html.Raw(
                @$"

<img  src=""{src}""  style=""width:15vw;height:15vh""/>

");
        }

        public static string GetHtmlToString(this IHtmlContent content)
        {
            using (var writer = new System.IO.StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static IHtmlContent Input(this IHtmlHelper html, string title,
            string name, dynamic value)
        {
            return html.Raw($@"
    <div class=""form-group"">
                <label>{title}</label>
                <input name=""{name}"" id=""titleTemp"" value=""{value}"" class=""form-control"" />
                </div>
");
        }


        public static IHtmlContent Select(this IHtmlHelper html, string title,
            string name, dynamic value, dynamic list)
        {
            return html.Raw($@"
    <div class=""form-group"">
                <label>{title}</label>
                <input name=""{name}"" id=""titleTemp"" value=""{value}"" class=""form-control"" />

{
                html.DropDownList(name,
                    new SelectList(list, "Value", "Name", value), title, new
                    {
                        @class = "form-control"
                    })}
                </div>
");
        }


        public static string DeleteForm(this IHtmlHelper html, string action, string method, long id)
        {
            return $@"

                <p>آیا از حذف این رکورد اطمینان دارید ؟</p>
                <form class=""additinalButtons"" action=""{action}"" method=""{method}"">
                {html.AntiForgeryToken().GetHtmlToString()}
<input type=""hidden"" name=""Id""  value=""{id}""  />
                </form>
";
        }


        public static IHtmlContent ConfirmModal(this IHtmlHelper html, string title,
            string buttonTitle,
            string modalId,
            string formBody)
        {
            return html.Raw($@"
   
 <button type=""button"" class=""btn btn-primary additinalButtons"" data-toggle=""modal"" data-target=""#{modalId}"">
                     {buttonTitle}
                   </button>
                   
                   <!-- Modal -->
                   <div class=""modal fade"" id=""{modalId}"" tabindex=""-1"" role=""dialog""
 aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                     <div class=""modal-dialog"" role=""document"">
                       <div class=""modal-content"">
                         <div class=""modal-header"">
                           <h5 class=""modal-title"" id=""exampleModalLabel"">{title}</h5>
                           <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                             <span aria-hidden=""true"">&times;</span>
                           </button>
                         </div>
                         <div class=""modal-body"">
                           {formBody}
                         </div>
                         <div class=""modal-footer"">
                           <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">لغو</button>
                           <button type=""button"" class=""btn btn-primary"" onclick=""function submitForm(param) {{
                    
                    $(param).parents('.modal').find('form').submit();
                }}
                    submitForm(this)"">بله</button>
                         </div>
                       </div>
                     </div>
                   </div>
");
        }


        public static IHtmlContent DynamicModal(this IHtmlHelper html, string title,
            string buttonTitle,
            string modalId,
            string formBody)
        {
            string button = buttonTitle != null
                ? $@"<button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#{modalId}"">
                     {buttonTitle}
                   </button>"
                : "";
            return html.Raw($@"
   
 {button}
                   
                   <!-- Modal -->
                   <div class=""modal fade"" id=""{modalId}"" tabindex=""-1"" role=""dialog""
 aria-labelledby=""exampleModalLabel"" aria-hidden=""true"" >
                     <div class=""modal-dialog mw-100 w-75"" role=""document"">
                       <div class=""modal-content"" >
                         <div class=""modal-header"">
                           <h5 class=""modal-title"" id=""exampleModalLabel"">{title}</h5>
                           <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                             <span aria-hidden=""true"">&times;</span>
                           </button>
                         </div>
                         <div class=""modal-body"">
                           {formBody}
                         </div>
                         <div class=""modal-footer"">
                           <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">بستن</button>
                         </div>
                       </div>
                     </div>
                   </div>
");
        }
    }
}