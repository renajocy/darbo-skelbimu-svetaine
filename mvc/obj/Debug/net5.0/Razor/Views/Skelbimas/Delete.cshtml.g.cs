#pragma checksum "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad064756"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skelbimas_Delete), @"mvc.1.0.view", @"/Views/Skelbimas/Delete.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Backup\repos\mvc\mvc\Views\_ViewImports.cshtml"
using mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Backup\repos\mvc\mvc\Views\_ViewImports.cshtml"
using mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad064756", @"/Views/Skelbimas/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4e65417ec4bfa3a7d71210a8e25791eae741f5b9b6083b4802692bdb23fdcbbc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Skelbimas_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mvc.Models.Skelbima>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Skelbimas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
  
    ViewData["Title"] = "Naikinti skelbimą";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Naikinti skelbimą</h1>\r\n");
#nullable restore
#line 8 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
 if (User.Identity.Name == (Model.FkVartotojas.EPastas))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h1>");
#nullable restore
#line 11 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <hr />\r\n        <dl class=\"row\">\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 15 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Aprasymas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 18 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Aprasymas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <hr />\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 22 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Uzmokestis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 25 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Uzmokestis));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n            </dd>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 28 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Adresas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 31 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Adresas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 34 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 37 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 40 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.FkKategorija));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 43 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.FkKategorija.Pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <hr />\r\n            <h3 class=\"text-center\">Kontaktai</h3>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 48 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.FkVartotojas.Vardas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 51 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.FkVartotojas.Vardas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 54 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.FkVartotojas.Telefonas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 57 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.FkVartotojas.Telefonas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 60 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.FkVartotojas.EPastas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2449, "\"", 2516, 2);
            WriteAttributeValue("", 2456, "mailto:", 2456, 7, true);
#nullable restore
#line 63 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
WriteAttributeValue("", 2463, Html.DisplayFor(model => model.FkVartotojas.EPastas), 2463, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 63 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
                                                                                  Write(Html.DisplayFor(model => model.FkVartotojas.EPastas));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </dd>\r\n            <dt class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 66 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.MokejimoBudasNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-12 text-center\">\r\n                ");
#nullable restore
#line 69 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
           Write(Html.DisplayFor(model => model.MokejimoBudasNavigation.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n\r\n        <h3>Ar jūs įsitikinęs, kad norite panaikinti šį skelbimą?</h3>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad06475612582", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad06475612877", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 75 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Naikinti skelbimą\" class=\"btn btn-danger\" />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad06475614679", async() => {
                    WriteLiteral("Grįžti į skelbimų sąrašą");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 80 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"text-center alert-danger\">Klaida! Jūs neturite teisės atlikti šios procedūros!</h2>\r\n    <hr />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c68176e49462f88bc70f59de71c203d94e80fb1daa5072c6afcf7674ad06475617739", async() => {
                WriteLiteral("Grįžti į skelbimų sąrašą");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 87 "D:\Backup\repos\mvc\mvc\Views\Skelbimas\Delete.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mvc.Models.Skelbima> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
