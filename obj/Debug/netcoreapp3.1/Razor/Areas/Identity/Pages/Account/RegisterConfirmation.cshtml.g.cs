#pragma checksum "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4852d2844d083a3120d0da82a70ef697ebd3167a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_RegisterConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml", typeof(AspNetCore.Areas_Identity_Pages_Account_RegisterConfirmation), null)]
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
#line 1 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\_ViewImports.cshtml"
using BigPardakht.Areas.Identity;

#line default
#line hidden
#line 3 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\_ViewImports.cshtml"
using BigPardakht.Areas.Identity.Pages;

#line default
#line hidden
#line 1 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using BigPardakht.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4852d2844d083a3120d0da82a70ef697ebd3167a", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66e443ba81bfd444e2b1c1ae94c4deedf2b8d44", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0068e0ebcf2aac4928156328f37f7e2766ce853c", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df3a3d43ba363d0fa55d7a1eee0e0d3194083e42", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_RegisterConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    ViewData["Title"] = "Register confirmation";

#line default
#line hidden
            BeginContext(98, 44, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"topspace\"></div>\r\n\r\n\r\n<h1>");
            EndContext();
            BeginContext(143, 17, false);
#line 12 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(160, 7, true);
            WriteLiteral("</h1>\r\n");
            EndContext();
#line 13 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    if (@Model.DisplayConfirmAccountLink)
    {

#line default
#line hidden
            BeginContext(221, 232, true);
            WriteLiteral("<p>\r\n    This app does not currently have a real email sender registered, see <a href=\"https://aka.ms/aspaccountconf\">these docs</a> for how to configure a real email sender.\r\n    Normally this would be emailed: <a id=\"confirm-link\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 453, "\"", 487, 1);
#line 18 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
WriteAttributeValue("", 460, Model.EmailConfirmationUrl, 460, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(488, 47, true);
            WriteLiteral(">Click here to confirm your account</a>\r\n</p>\r\n");
            EndContext();
#line 20 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(559, 69, true);
            WriteLiteral("<p>\r\n        Please check your email to confirm your account.\r\n</p>\r\n");
            EndContext();
#line 26 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }

#line default
#line hidden
            BeginContext(638, 37, true);
            WriteLiteral("\r\n\r\n<div class=\"bottomspace\"></div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterConfirmationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel>)PageContext?.ViewData;
        public RegisterConfirmationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591