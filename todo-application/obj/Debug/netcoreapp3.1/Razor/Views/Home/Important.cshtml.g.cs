#pragma checksum "C:\Users\Lukas\source\repos\aspnet-core-final-project\todo-application\Views\Home\Important.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "929bdd6409c904dc28a88455bee2061480a5b2f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Important), @"mvc.1.0.view", @"/Views/Home/Important.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Lukas\source\repos\aspnet-core-final-project\todo-application\Views\_ViewImports.cshtml"
using todo_application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lukas\source\repos\aspnet-core-final-project\todo-application\Views\_ViewImports.cshtml"
using todo_application.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"929bdd6409c904dc28a88455bee2061480a5b2f6", @"/Views/Home/Important.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a39092910c7b7f06e577589d80d57e5ca63f4f3e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Important : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Lukas\source\repos\aspnet-core-final-project\todo-application\Views\Home\Important.cshtml"
  
    ViewData["Title"] = "Important";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("task", async() => {
                WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Important</h1>\r\n        <p>Essential reminders</p>\r\n    </div>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591