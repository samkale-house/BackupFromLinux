#pragma checksum "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36c2f93d8449a306525c17aaae74bf3a116b8a18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageProducts_AllProducts), @"mvc.1.0.view", @"/Views/ManageProducts/AllProducts.cshtml")]
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
#line 1 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/_ViewImports.cshtml"
using ReportGenerationPrj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/_ViewImports.cshtml"
using ReportGenerationPrj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36c2f93d8449a306525c17aaae74bf3a116b8a18", @"/Views/ManageProducts/AllProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"051054e1edc7432a84abec1802a4f86547e7a9aa", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageProducts_AllProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SamProduct>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""table table-striped w-auto"">
   
    <table>
        <thead>
            <tr>
                <th scope=""col"">Product_id</th>
                <th scope=""col"">Name</th>
                <th scope=""col"">Price</th>
                <th scope=""col"">Launched On</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
             foreach (var product in Model)
            {             
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td scope=\"row\">");
#nullable restore
#line 23 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
                           Write(product.Product_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 24 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
               Write(product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 25 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
               Write(product.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>12-12-");
#nullable restore
#line 26 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
                     Write(product.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>");
#nullable restore
#line 27 "/home/mrmlabs/Sam_Workspace/ReportGenerationPrj/Views/ManageProducts/AllProducts.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SamProduct>> Html { get; private set; }
    }
}
#pragma warning restore 1591
