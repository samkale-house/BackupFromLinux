#pragma checksum "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f91a322c50a9b9c5b82b6fa2f5815b530c8ebc11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/_ViewImports.cshtml"
using AjaxAtClientPrj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/_ViewImports.cshtml"
using AjaxAtClientPrj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f91a322c50a9b9c5b82b6fa2f5815b530c8ebc11", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adf9376181361fc471c731ff43d4b3e23555f908", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content-panel"">
    <table class=""table striped-table"">
        <th><tr>
            <td>Title</td>
            <td>Genre</td>
            <td>Rating</td>
            <td>Price</td>
            <td>Launched Date</td>
        </tr></th>
        <tbody>
");
#nullable restore
#line 15 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
             foreach(var movie in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 18 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
                   Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
                   Write(movie.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
                   Write(movie.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
                   Write(movie.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
                   Write(movie.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 24 "/home/mrmlabs/Sam_Workspace/AjaxAtClientPrj/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <tr></tr>
        </tbody>
    </table>
</div>
<!--
<div class=""form-group"">
    <input type=""text"" id=""txtid1"" class=""form-control"">
</div>
<div class=""form-group"">
    <button id=""btnDetails"">Details</button>
</div>
<div id=""dvDetail""></div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
$(document).ready(function () {
    $('#btnDetails').click(function () {
        $.ajax({
            type: ""GET"",
            url: ""https://localhost:6001/Movies/""+$('#txtid1').val(),
            //contentType: ""application/json"",
            datatype: ""json"",
            success:function(result){alert(result.title);Console.log(result.title);},
    error: function (request, message, error) {
      console.log(error.message);
      handleException(request, message, error);}    
  });
    });
 function handleException(request, message, error) {
  var msg = """";
  msg += ""Code: "" + request.status + ""\n"";
  msg += ""Text: "" + request.statusText + ""\n"";
  if (request.responseJSON != null) {
    msg += ""Message: "" +
           request.responseJSON.Message + ""\n"";
  }
  alert(""error here :""+msg);
}
     });


    </script>
");
            }
            );
            WriteLiteral("-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
