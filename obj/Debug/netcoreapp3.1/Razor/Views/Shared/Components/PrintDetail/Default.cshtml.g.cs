#pragma checksum "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6ba92f37caa6fe8a29ab0d741d1e02c98375a47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_PrintDetail_Default), @"mvc.1.0.view", @"/Views/Shared/Components/PrintDetail/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/PrintDetail/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_PrintDetail_Default))]
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
#line 1 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using System.Reflection;

#line default
#line hidden
#line 2 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using AbstractLibrary.FormBuilder;

#line default
#line hidden
#line 3 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using AbstractLibrary.ViewComponents;

#line default
#line hidden
#line 4 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using BigPardakht.Model;

#line default
#line hidden
#line 5 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#line 6 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
using Microsoft.Extensions.DependencyInjection;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6ba92f37caa6fe8a29ab0d741d1e02c98375a47", @"/Views/Shared/Components/PrintDetail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66e443ba81bfd444e2b1c1ae94c4deedf2b8d44", @"/_ViewImports.cshtml")]
    public class Views_Shared_Components_PrintDetail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(296, 83, true);
            WriteLiteral("\r\n\r\n\r\n<style>\r\n    .readonlyForm input{\r\n    \r\n    border: none;\r\n    }\r\n</style>\r\n");
            EndContext();
#line 18 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
  
    var propertyInfos = Model.GetType().GetProperties();

    propertyInfos = propertyInfos.OrderBy(o => o.PropertyType == typeof(bool)).ToArray();

#line default
#line hidden
            BeginContext(537, 34, true);
            WriteLiteral("\r\n<div class=\"row readonlyForm\">\r\n");
            EndContext();
#line 25 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
     foreach (var prop in propertyInfos)
    {
        if (TempData.IsInHiddenList(prop.Name))
        {
            continue;
        }
        var attr = prop.CustomAttributes.FirstOrDefault();


        var val = prop.GetValue(Model);


        string translate = @MyGlobal.GetTranslate()[prop.Name];

        if (prop.Name == "Id")
        {
            

#line default
#line hidden
            BeginContext(946, 22, false);
#line 41 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
       Write(Html.Hidden("Id", val));

#line default
#line hidden
            EndContext();
#line 41 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
                                   
            continue;
        }

        if (prop.IsHasAttribute<HiddenAttribute>())
        {
            

#line default
#line hidden
            BeginContext(1083, 27, false);
#line 47 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
       Write(Html.Hidden(prop.Name, val));

#line default
#line hidden
            EndContext();
#line 47 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
                                        
            continue;
        }


        if (prop.PropertyType == typeof(bool) ||
            prop.PropertyType == typeof(bool?))
        {

#line default
#line hidden
            BeginContext(1260, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1276, "\"", 1315, 3);
            WriteAttributeValue("", 1284, "col-md-6", 1284, 8, true);
#line 55 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 1292, prop.Name, 1294, 10, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1304, "form-group", 1305, 11, true);
            EndWriteAttribute();
            BeginContext(1316, 21, true);
            WriteLiteral(">\r\n\r\n                ");
            EndContext();
            BeginContext(1338, 21, false);
#line 57 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(1359, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1378, 202, false);
#line 58 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Editor(prop.Name, prop.Name
                    , new
                    {
                        @class = "form-control",
                        @readonly="readonly"
                    }));

#line default
#line hidden
            EndContext();
            BeginContext(1580, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 65 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }


        if (attr == null)
        {

#line default
#line hidden
            BeginContext(1678, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1694, "\"", 1722, 2);
            WriteAttributeValue("", 1702, "col-md-6", 1702, 8, true);
#line 71 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 1710, prop.Name, 1712, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1723, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(1743, 202, false);
#line 72 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Editor(prop.Name, prop.Name
                    , new
                    {
                        @class = "form-control",
                        @readonly="readonly"
                    }));

#line default
#line hidden
            EndContext();
            BeginContext(1945, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 79 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }


        if (prop.IsHasAttribute<DontPrintAttribute>())
        {
            continue;
        }

        if (prop.IsHasAttribute<RichTextAttribute>())
        {

#line default
#line hidden
            BeginContext(2174, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2190, "\"", 2218, 2);
            WriteAttributeValue("", 2198, "col-md-6", 2198, 8, true);
#line 90 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 2206, prop.Name, 2208, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2219, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(2239, 22, false);
#line 91 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Hidden(prop.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2261, 15, true);
            WriteLiteral("\r\n             ");
            EndContext();
            BeginContext(2277, 264, false);
#line 92 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
        Write(Html.TextArea(prop.Name, prop.Name
                                , new
                                {
                                    @class = "form-control",
                                    @readonly="readonly"
                                }));

#line default
#line hidden
            EndContext();
            BeginContext(2541, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 99 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"

            continue;
        }
        
        
        
        if (prop.IsHasAttribute<SelectByServiceAttribute>())
        {

#line default
#line hidden
            BeginContext(2702, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2718, "\"", 2757, 3);
            WriteAttributeValue("", 2726, "col-md-6", 2726, 8, true);
#line 107 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 2734, prop.Name, 2736, 10, false);

#line default
#line hidden
            WriteAttributeValue(" ", 2746, "form-group", 2747, 11, true);
            EndWriteAttribute();
            BeginContext(2758, 5, true);
            WriteLiteral(">\r\n\r\n");
            EndContext();
#line 109 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
                  
                    var customAttribute = prop.GetCustomAttribute(typeof(SelectByServiceAttribute));

                    var selectByServiceAttribute = customAttribute as SelectByServiceAttribute;

                    if (selectByServiceAttribute == null)
                    {
                        throw new Exception("fileAttribute is null");
                    }
                    var service = ServiceProvider.GetService(selectByServiceAttribute.ServiceType) as ISelectListProvider;

                

#line default
#line hidden
            BeginContext(3307, 36, true);
            WriteLiteral("                \r\n\r\n                ");
            EndContext();
            BeginContext(3344, 21, false);
#line 123 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(3365, 20, true);
            WriteLiteral("\r\n\r\n                ");
            EndContext();
            BeginContext(3386, 261, false);
#line 125 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.DropDownList(prop.Name,service.GetSelectList(val), selectByServiceAttribute.SelectLabel,
                    new
                    {
                        @class="form-control",
                        @readonly="readonly"

                    }));

#line default
#line hidden
            EndContext();
            BeginContext(3647, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 133 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"

            continue;
        }
        
        if (prop.IsHasAttribute<ReadOnlyAttribute>())
        {

#line default
#line hidden
            BeginContext(3781, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3797, "\"", 3825, 2);
            WriteAttributeValue("", 3805, "col-md-6", 3805, 8, true);
#line 139 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 3813, prop.Name, 3815, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3826, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(3846, 21, false);
#line 140 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(3867, 36, true);
            WriteLiteral("\r\n                \r\n                ");
            EndContext();
            BeginContext(3904, 168, false);
#line 142 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.TextBox(prop.Name, (val ?? "") + "", new
                {
                    @class = "form-control",
                @readonly="readonly"
                }));

#line default
#line hidden
            EndContext();
            BeginContext(4072, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 148 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }
        if (prop.IsHasAttribute<TextAttribute>())
        {

#line default
#line hidden
            BeginContext(4190, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4206, "\"", 4234, 2);
            WriteAttributeValue("", 4214, "col-md-6", 4214, 8, true);
#line 152 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 4222, prop.Name, 4224, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4235, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(4255, 21, false);
#line 153 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(4276, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(4295, 174, false);
#line 154 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.TextBox(prop.Name, (val ?? "") + "", new
                {
                    @class = "form-control",
                    @readonly="readonly"

                }));

#line default
#line hidden
            EndContext();
            BeginContext(4469, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 161 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }


        if (prop.IsHasAttribute<TextAreaAttribute>())
        {

#line default
#line hidden
            BeginContext(4595, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4611, "\"", 4639, 2);
            WriteAttributeValue("", 4619, "col-md-6", 4619, 8, true);
#line 167 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 4627, prop.Name, 4629, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4640, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(4660, 21, false);
#line 168 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(4681, 20, true);
            WriteLiteral("\r\n\r\n                ");
            EndContext();
            BeginContext(4702, 175, false);
#line 170 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.TextArea(prop.Name, (val ?? "") + "", new
                {
                    @class = "form-control",
                    @readonly="readonly"

                }));

#line default
#line hidden
            EndContext();
            BeginContext(4877, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 177 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }
        
        

        if (prop.IsHasAttribute<SelectColorAttribute>())
        {
            var customAttribute = prop.GetCustomAttribute(typeof(SelectColorAttribute));

            var fileAttribute = customAttribute as SelectColorAttribute;

            if (fileAttribute == null)
            {
                throw new Exception("fileAttribute is null");
            }
            
            

#line default
#line hidden
            BeginContext(5353, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 5369, "\"", 5408, 3);
            WriteAttributeValue("", 5377, "col-md-6", 5377, 8, true);
#line 194 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 5385, prop.Name, 5387, 10, false);

#line default
#line hidden
            WriteAttributeValue(" ", 5397, "form-group", 5398, 11, true);
            EndWriteAttribute();
            BeginContext(5409, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(5429, 21, false);
#line 195 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(5450, 58, true);
            WriteLiteral("\r\n                <input type=\"color\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("id", "\r\n                       id=\"", 5508, "\"", 5547, 1);
#line 197 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("", 5537, prop.Name, 5537, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 5548, "\"", 5565, 1);
#line 197 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("", 5555, prop.Name, 5555, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5566, 61, true);
            WriteLiteral(" value=\"#ff0000\" readonly=\"readonly\">\r\n\r\n            </div>\r\n");
            EndContext();
#line 200 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            

        }
        if (prop.IsHasAttribute<FileAttribute>())
        {
            var customAttribute = prop.GetCustomAttribute(typeof(FileAttribute));

            var fileAttribute = customAttribute as FileAttribute;

            if (fileAttribute == null)
            {
                throw new Exception("fileAttribute is null");
            }


#line default
#line hidden
            BeginContext(6005, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 6021, "\"", 6049, 2);
            WriteAttributeValue("", 6029, "col-md-6", 6029, 8, true);
#line 214 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 6037, prop.Name, 6039, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6050, 68, true);
            WriteLiteral(">\r\n                <input\r\n                    type=\"file\" id=\"file\"");
            EndContext();
            BeginWriteAttribute("name", "\r\n                    name=\"", 6118, "\"", 6156, 1);
#line 217 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("", 6146, prop.Name, 6146, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6157, 20, true);
            WriteLiteral(" readonly=\"readonly\"");
            EndContext();
            BeginWriteAttribute("accept", "\r\n                    accept=\"", 6177, "\"", 6228, 1);
#line 218 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("", 6207, fileAttribute.Accept, 6207, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6229, 24, true);
            WriteLiteral("\r\n\r\n                    ");
            EndContext();
            BeginContext(6255, 54, false);
#line 220 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
                Write(fileAttribute.Multiple ? @"multiple=""multiple""" : "");

#line default
#line hidden
            EndContext();
            BeginContext(6310, 1959, true);
            WriteLiteral(@"
                    onchange=""CheckSize(this)""/>

                <script>
                function FileListItems (files) {
                  var b = new ClipboardEvent("""").clipboardData || new DataTransfer()
                  for (var i = 0, len = files.length; i<len; i++) b.items.add(files[i])
                  return b.files
                }
                
                function showErr(param,msg){
                    
                    $(param).parent().find(""alert"").remove();
                    
                    $(param).parent().append(`
                    
                    <div class=""alert alert-warning"">${msg}</div>`)
                    }

                function CheckSize(param) {
                         
                    
                    var alertSent=false;
                    var newFileList = Array.from(event.target.files);

                    
                    let arr=[];
                    for(let i = 0; i < newFileList.length; i++) {
");
            WriteLiteral(@"                      if(newFileList[i].size > 2097152){
                          
                      if (!alertSent){
                          
                                                   showErr(param,'اندازه فایل بسیار بزرگ است بنابراین فایل های بزرگ اضافه نشد');
alertSent=true;
                          }

                      }else{
                          
                          if (i>5){
                              
                                                   showErr(param,'امکان انتخاب بیش از 5 فایل در یک زمان وجود ندارد');
                            break;
 }else{
                              arr.push(newFileList[i]);
                              }
                          }
                    }
                    
                    param.files=new FileListItems(arr);
                    
                  };
                </script>
            </div>
");
            EndContext();
#line 273 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }


        if (prop.IsHasAttribute<SelectFileAttribute>())
        {
            
            continue;
        }
        if (prop.IsHasAttribute<SelectAttribute>())
        {

#line default
#line hidden
            BeginContext(8487, 16, true);
            WriteLiteral("            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 8503, "\"", 8542, 3);
            WriteAttributeValue("", 8511, "col-md-6", 8511, 8, true);
#line 284 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
WriteAttributeValue("  ", 8519, prop.Name, 8521, 10, false);

#line default
#line hidden
            WriteAttributeValue(" ", 8531, "form-group", 8532, 11, true);
            EndWriteAttribute();
            BeginContext(8543, 21, true);
            WriteLiteral(">\r\n\r\n                ");
            EndContext();
            BeginContext(8565, 21, false);
#line 286 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.Label(translate));

#line default
#line hidden
            EndContext();
            BeginContext(8586, 20, true);
            WriteLiteral("\r\n\r\n                ");
            EndContext();
            BeginContext(8607, 148, false);
#line 288 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
           Write(Html.DropDownList(prop.Name, ViewData[prop.Name] as SelectList, new
                {
                    @readonly="readonly"
                }));

#line default
#line hidden
            EndContext();
            BeginContext(8755, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 293 "E:\workplace\shared\AbstractLibrary\Views\Shared\Components\PrintDetail\Default.cshtml"
            continue;
        }
    }

#line default
#line hidden
            BeginContext(8818, 14, true);
            WriteLiteral("\r\n\r\n\r\n\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IServiceProvider ServiceProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591