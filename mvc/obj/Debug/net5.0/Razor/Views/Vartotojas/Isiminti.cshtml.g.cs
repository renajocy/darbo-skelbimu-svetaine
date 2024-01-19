#pragma checksum "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "821fb2c772b5af53b0ad888c5437a89a3f73730858a47b95fcfb2563decca52c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vartotojas_Isiminti), @"mvc.1.0.view", @"/Views/Vartotojas/Isiminti.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"821fb2c772b5af53b0ad888c5437a89a3f73730858a47b95fcfb2563decca52c", @"/Views/Vartotojas/Isiminti.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4e65417ec4bfa3a7d71210a8e25791eae741f5b9b6083b4802692bdb23fdcbbc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Vartotojas_Isiminti : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mvc.Models.Isimintum>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Skelbimas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
  
    ViewData["Title"] = "Įsiminti skelbimai";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
  
    mvc.Models.darbasContext db = new darbasContext();
    var user = db.Vartotojas.SingleOrDefault(x => x.EPastas.Equals(User.Identity.Name));
    var isiminta = db.Isiminta.Count(y => y.FkVartotojas.EPastas.Equals(User.Identity.Name));
    var isiminti = db.Isiminta.Where(y => y.FkVartotojasid == user.Id).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Įsiminti skelbimai</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
#nullable restore
#line 17 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
         if (isiminta == 0 || isiminta == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-12 text-center\">\r\n                Jūs neturite išsaugotų skelbimų!\r\n            </dt>\r\n");
#nullable restore
#line 22 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-12 text-center\">\r\n                Viso įsimintų skelbimų: ");
#nullable restore
#line 26 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
                                   Write(isiminta);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <hr />\r\n");
#nullable restore
#line 29 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
             foreach (var skelbimas in db.Isiminta.Where(y => y.FkVartotojas.EPastas.Equals(User.Identity.Name)).ToList())
            {
                var skelb = db.Skelbimas.FirstOrDefault(z => z.Id == skelbimas.FkSkelbimasid);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4 class=\"text-center\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "821fb2c772b5af53b0ad888c5437a89a3f73730858a47b95fcfb2563decca52c6615", async() => {
#nullable restore
#line 33 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
                                                                                                          Write(skelb.Pavadinimas);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
                                                                         WriteLiteral(skelbimas.FkSkelbimasid);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </h4>\r\n");
#nullable restore
#line 35 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\Backup\repos\mvc\mvc\Views\Vartotojas\Isiminti.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n</div>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "821fb2c772b5af53b0ad888c5437a89a3f73730858a47b95fcfb2563decca52c9657", async() => {
                WriteLiteral("Grįžti į skelbimų sąrašą");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mvc.Models.Isimintum> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
