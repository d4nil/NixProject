#pragma checksum "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7222dfcfd91b34a540a24e66d20a6b9aadd8eaa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Orders), @"mvc.1.0.view", @"/Views/Order/Orders.cshtml")]
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
#line 1 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\_ViewImports.cshtml"
using User_Interface.Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\_ViewImports.cshtml"
using User_Interface.Presentation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
using Domain.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7222dfcfd91b34a540a24e66d20a6b9aadd8eaa4", @"/Views/Order/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f308605dfac5ab73ccb69394e5fecc5816402d", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
  
    ViewData["Title"] = "Orders";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>????????????</h1>
<div class=""row"">
    <div class=""col"">
        ??????
    </div>
    <div class=""col"">
        ??????????
    </div><div class=""col"">
        ????????
    </div><div class=""col"">
        ??????????
    </div><div class=""col"">
        ??????????????????????
    </div><div class=""col"">
        ????????
    </div>
    <div class=""col"">
        ???????????????? ????????????
    </div>
    <div class=""col"">
        ???????????????????? ????????????
    </div>
    <div class=""col"">
    </div>
    <div class=""col"">
    </div>
</div>

");
#nullable restore
#line 35 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
 foreach (var o in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 39 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 42 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.City.city);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 45 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 48 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 51 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 54 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
   Write(o.SumCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col\">\r\n");
#nullable restore
#line 57 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
         foreach (var c in o.lines)
        {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
           Write(c.Product.PName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
                                
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col\">\r\n");
#nullable restore
#line 63 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
         foreach (var c in o.lines)
        {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
           Write(c.Quantity);

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
                           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n        <div class=\"col\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7222dfcfd91b34a540a24e66d20a6b9aadd8eaa49156", async() => {
                WriteLiteral("\r\n                ???????????????? ????????????\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
                                                           WriteLiteral(o.OrderId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7222dfcfd91b34a540a24e66d20a6b9aadd8eaa411742", async() => {
                WriteLiteral("\r\n                ???????????????? \r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
                                                          WriteLiteral(o.OrderId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 79 "C:\Users\Kifardan\source\repos\NixProjectNull\User_Interface.Presentation\Views\Order\Orders.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
