#pragma checksum "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0600642be00646d826f418580fcd6a50acb89db0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account__StatusMessage), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/_StatusMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Identity/Pages/Account/_StatusMessage.cshtml", typeof(AspNetCore.Areas_Identity_Pages_Account__StatusMessage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0600642be00646d826f418580fcd6a50acb89db0", @"/Areas/Identity/Pages/Account/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66e443ba81bfd444e2b1c1ae94c4deedf2b8d44", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0068e0ebcf2aac4928156328f37f7e2766ce853c", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df3a3d43ba363d0fa55d7a1eee0e0d3194083e42", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 34, true);
            WriteLiteral("\r\n<div class=\"topspace\"></div>\r\n\r\n");
            EndContext();
#line 5 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";

#line default
#line hidden
            BeginContext(168, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 176, "\"", 233, 4);
            WriteAttributeValue("", 184, "alert", 184, 5, true);
            WriteAttributeValue(" ", 189, "alert-", 190, 7, true);
#line 8 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_StatusMessage.cshtml"
WriteAttributeValue("", 196, statusMessageClass, 196, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 215, "alert-dismissible", 216, 18, true);
            EndWriteAttribute();
            BeginContext(234, 158, true);
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n        ");
            EndContext();
            BeginContext(393, 5, false);
#line 10 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_StatusMessage.cshtml"
   Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(398, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 12 "E:\workplace\shared\AbstractLibrary\Areas\Identity\Pages\Account\_StatusMessage.cshtml"
}

#line default
#line hidden
            BeginContext(415, 37, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
