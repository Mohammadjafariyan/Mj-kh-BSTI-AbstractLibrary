#pragma checksum "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3949307d9ea08fc51441d9a2462691efcba2bb9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HorizontalTable_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HorizontalTable/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/HorizontalTable/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_HorizontalTable_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using System.ComponentModel;

#line default
#line hidden
#line 2 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#line 3 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using System.Reflection;

#line default
#line hidden
#line 4 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using System.Security.Policy;

#line default
#line hidden
#line 5 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using AbstractLibrary.FormBuilder;

#line default
#line hidden
#line 6 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using BigPardakht.Model;

#line default
#line hidden
#line 7 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3949307d9ea08fc51441d9a2462691efcba2bb9e", @"/Views/Shared/Components/HorizontalTable/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66e443ba81bfd444e2b1c1ae94c4deedf2b8d44", @"/_ViewImports.cshtml")]
    public class Views_Shared_Components_HorizontalTable_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<(dynamic entity,dynamic table,Func<dynamic, string> actionPart,Func<dynamic, string, dynamic, string> customRecordPart, Func<dynamic, string> editUrl,Func<dynamic, string> deleteUrl,Func<dynamic, string> createUrl)>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(452, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 11 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
  
    var propertyInfos = Model.entity.GetType().GetProperties();
    var controller = ViewContext.RouteData.Values["controller"];


#line default
#line hidden
            BeginContext(596, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(676, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 27 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
 if (Model.createUrl != null)
{

#line default
#line hidden
            BeginContext(714, 31, true);
            WriteLiteral("    <a class=\"additinalButtons\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 745, "\"", 785, 1);
#line 29 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
WriteAttributeValue("", 752, Html.Raw(Model.createUrl(Model)), 752, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(786, 17, true);
            WriteLiteral(">رکورد جدید</a>\r\n");
            EndContext();
#line 30 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(815, 31, true);
            WriteLiteral("    <a class=\"additinalButtons\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 846, "\"", 875, 3);
            WriteAttributeValue("", 853, "/", 853, 1, true);
#line 33 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
WriteAttributeValue("", 854, controller, 854, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 865, "/Save?id=0", 865, 10, true);
            EndWriteAttribute();
            BeginContext(876, 17, true);
            WriteLiteral(">رکورد جدید</a>\r\n");
            EndContext();
#line 34 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
}

#line default
#line hidden
            BeginContext(896, 9, true);
            WriteLiteral("\r\n<br/>\r\n");
            EndContext();
            BeginContext(906, 104, false);
#line 37 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
Write(await Component.InvokeAsync("Paging", new
{
    total = Model.table.Total, page = Model.table.Page
}));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 104, true);
            WriteLiteral("\r\n<hr/>\r\n<table class=\"table table-striped table-bordered table-responsive \">\r\n\r\n    <thead>\r\n    <tr>\r\n");
            EndContext();
            BeginContext(1169, 32, true);
            WriteLiteral("        <th>\r\n\r\n\r\n\r\n            ");
            EndContext();
            BeginContext(1202, 31, false);
#line 51 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
       Write(MyGlobal.GetTranslate()["Name"]);

#line default
#line hidden
            EndContext();
            BeginContext(1233, 21, true);
            WriteLiteral("\r\n\r\n        </th>\r\n\r\n");
            EndContext();
#line 55 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
          
            int c = 1;
        

#line default
#line hidden
#line 58 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
         foreach (var entity in Model.table.EntityList)
        {

#line default
#line hidden
            BeginContext(1369, 19, true);
            WriteLiteral("            <th >\r\n");
            EndContext();
            BeginContext(1443, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 63 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                 if (Model.editUrl != null)
                {

#line default
#line hidden
            BeginContext(1509, 52, true);
            WriteLiteral("                    <a class=\"additinalButtons edit\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1561, "\"", 1590, 1);
#line 65 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
WriteAttributeValue("", 1568, Model.editUrl(entity), 1568, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1591, 13, true);
            WriteLiteral(">ویرایش</a>\r\n");
            EndContext();
#line 66 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1664, 52, true);
            WriteLiteral("                    <a class=\"edit additinalButtons\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1716, "\"", 1754, 4);
            WriteAttributeValue("", 1723, "/", 1723, 1, true);
#line 69 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
WriteAttributeValue("", 1724, controller, 1724, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 1735, "/Save?id=", 1735, 9, true);
#line 69 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
WriteAttributeValue("", 1744, entity.Id, 1744, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1755, 13, true);
            WriteLiteral(">ویرایش</a>\r\n");
            EndContext();
#line 70 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                }

#line default
#line hidden
#line 71 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                 if (Model.deleteUrl != null)
                {
                    

#line default
#line hidden
            BeginContext(1874, 168, false);
#line 73 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
               Write(Html.ConfirmModal("تاکید و اطمینان از حذف", "حذف",
                        "confirmModal", Html.DeleteForm((string) Model.deleteUrl(entity), "Post", (long) entity.Id)));

#line default
#line hidden
            EndContext();
#line 74 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                                                                                    
                }
                else
                {
                    

#line default
#line hidden
            BeginContext(2125, 169, false);
#line 78 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
               Write(Html.ConfirmModal("تاکید و اطمینان از حذف", "حذف",
                        "confirmModal", Html.DeleteForm(Url.Action("Delete", @controller), "Post", (long) entity.Id)));

#line default
#line hidden
            EndContext();
#line 79 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                                                                                     
                }

#line default
#line hidden
            BeginContext(2315, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 82 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                 if (Model.actionPart != null)
                {
                    

#line default
#line hidden
            BeginContext(2405, 34, false);
#line 84 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
               Write(Html.Raw(Model.actionPart(entity)));

#line default
#line hidden
            EndContext();
#line 84 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                       
                }

#line default
#line hidden
            BeginContext(2460, 19, true);
            WriteLiteral("            </th>\r\n");
            EndContext();
#line 87 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"

            c++;
        }

#line default
#line hidden
            BeginContext(2510, 42, true);
            WriteLiteral("    </tr>\r\n\r\n    </thead>\r\n    <tbody>\r\n\r\n");
            EndContext();
#line 95 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
      
        int counter = Model.table.EntityList.Count;
    

#line default
#line hidden
            BeginContext(2620, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 99 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
     foreach (PropertyInfo prop in propertyInfos)
    {
        string translate = MyGlobal.GetTranslate()[prop.Name];

        if (prop.IsHasAttribute<HiddenAttribute>() ||
            prop.IsHasAttribute<RichTextAttribute>() ||
            prop.IsHasAttribute<DontPrintAttribute>())
        {
        }
        else
        {

#line default
#line hidden
            BeginContext(2961, 18, true);
            WriteLiteral("            <tr>\r\n");
            EndContext();
#line 111 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                 if (prop.IsHasAttribute<DisplayAttribute>())
                {
                    var foo = prop.GetCustomAttribute<DisplayAttribute>();


#line default
#line hidden
            BeginContext(3139, 24, true);
            WriteLiteral("                    <th>");
            EndContext();
            BeginContext(3164, 8, false);
#line 115 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                   Write(foo.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3172, 7, true);
            WriteLiteral("</th>\r\n");
            EndContext();
#line 116 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(3239, 24, true);
            WriteLiteral("                    <td>");
            EndContext();
            BeginContext(3264, 9, false);
#line 119 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                   Write(translate);

#line default
#line hidden
            EndContext();
            BeginContext(3273, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 120 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(3299, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 123 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                 for (int i = 0; i < Model.table.EntityList.Count; i++)
                {
                    var entity = Model.table.EntityList[i];
                    var val = prop.GetValue(entity);



#line default
#line hidden
            BeginContext(3514, 78, true);
            WriteLiteral("                    <td >\r\n                        <div class=\"content\">\r\n\r\n\r\n");
            EndContext();
#line 133 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                             if (Model.customRecordPart != null)
                            {
                                var res = Model.customRecordPart(entity, prop.Name, val);
                                if (res == "")
                                {
                                    

#line default
#line hidden
            BeginContext(3900, 3, false);
#line 138 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                               Write(val);

#line default
#line hidden
            EndContext();
#line 138 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                        
                                }
                                else
                                {
                                    

#line default
#line hidden
            BeginContext(4050, 56, false);
#line 142 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                               Write(Html.Raw(Model.customRecordPart(entity, prop.Name, val)));

#line default
#line hidden
            EndContext();
#line 142 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                                                             
                                }
                            }
                            else
                            {
                                if (prop.PropertyType.IsEnum)
                                {
                                    var customAttribute = prop.GetCustomAttribute(typeof(DisplayNameAttribute));

                                    var selectByServiceAttribute = customAttribute as DisplayNameAttribute;

                                    if (selectByServiceAttribute == null)
                                    {
                                        if (val != null)
                                        {
                                            

#line default
#line hidden
            BeginContext(4824, 39, false);
#line 157 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                       Write(MyGlobal.GetTranslate()[val.ToString()]);

#line default
#line hidden
            EndContext();
#line 157 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                                                    
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
            BeginContext(5042, 3, false);
#line 161 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                       Write(val);

#line default
#line hidden
            EndContext();
#line 161 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                
                                        }
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
            BeginContext(5251, 36, false);
#line 166 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                   Write(selectByServiceAttribute.DisplayName);

#line default
#line hidden
            EndContext();
#line 166 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                                                             
                                    }
                                }
                                else if (prop.PropertyType == typeof(bool))
                                {
                                    if (val == true)
                                    {

#line default
#line hidden
            BeginContext(5568, 47, true);
            WriteLiteral("                                        <span> ");
            EndContext();
            BeginContext(5616, 31, false);
#line 173 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                          Write(MyGlobal.GetTranslate()["True"]);

#line default
#line hidden
            EndContext();
            BeginContext(5647, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 174 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(5776, 47, true);
            WriteLiteral("                                        <span> ");
            EndContext();
            BeginContext(5824, 32, false);
#line 177 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                          Write(MyGlobal.GetTranslate()["False"]);

#line default
#line hidden
            EndContext();
            BeginContext(5856, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 178 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                    }
                                }
                                else
                                {
                                    

#line default
#line hidden
            BeginContext(6049, 3, false);
#line 182 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                               Write(val);

#line default
#line hidden
            EndContext();
#line 182 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                                        
                                }
                            }

#line default
#line hidden
            BeginContext(6120, 61, true);
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n");
            EndContext();
#line 188 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(6200, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 190 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(6237, 30, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
            EndContext();
            BeginContext(6268, 104, false);
#line 197 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\HorizontalTable\Default.cshtml"
Write(await Component.InvokeAsync("Paging", new
{
    total = Model.table.Total, page = Model.table.Page
}));

#line default
#line hidden
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<(dynamic entity,dynamic table,Func<dynamic, string> actionPart,Func<dynamic, string, dynamic, string> customRecordPart, Func<dynamic, string> editUrl,Func<dynamic, string> deleteUrl,Func<dynamic, string> createUrl)> Html { get; private set; }
    }
}
#pragma warning restore 1591