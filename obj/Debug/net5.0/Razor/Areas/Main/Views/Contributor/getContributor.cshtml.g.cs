#pragma checksum "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d84e0a3876d5387c653b90d7630716810b9bcc83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Main_Views_Contributor_getContributor), @"mvc.1.0.view", @"/Areas/Main/Views/Contributor/getContributor.cshtml")]
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
#line 1 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\_ViewImports.cshtml"
using Quiz_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\_ViewImports.cshtml"
using Quiz_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d84e0a3876d5387c653b90d7630716810b9bcc83", @"/Areas/Main/Views/Contributor/getContributor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5eddff45cd01d596818965338d209f8ffdc992c", @"/Areas/Main/Views/_ViewImports.cshtml")]
    public class Areas_Main_Views_Contributor_getContributor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz_App.Areas.Main.Models.contributor>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">

        <div class=""card shadow mb-4"" style=""width:100%"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-primary"">All Contributor Data</h6>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"" style=""width:100%"">
                    <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr>
");
            WriteLiteral(@"                                <th>Full Name</th>
                                <th>Address</th>
                                <th>Mobile No</th>
                                <th>Email Id</th>
                                <th>User Name</th>
                                <th>Password</th>
                                <th>Contributor CreatedBy</th>
                                <th>Admin Location</th>
                                <th>Date Created</th>
                                <th>Date Modified</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 31 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                             foreach (System.Data.DataRow dr in ViewBag.contributor.Rows)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"active\">\r\n");
            WriteLiteral("                                    <td>");
#nullable restore
#line 35 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["fullName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["address"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 37 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["mobileNo"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["emailId"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["userName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 40 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["password"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["contributor_createdBy"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 42 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["adminLocation"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 43 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["dateCreated"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                                   Write(dr["dateModified"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2312, "\"", 2360, 2);
            WriteAttributeValue("", 2319, "updateContributor?id=", 2319, 21, true);
#nullable restore
#line 46 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
WriteAttributeValue("", 2340, dr["contributorId"], 2340, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary rounded-0\" >Edit</a>|\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2457, "\"", 2505, 2);
            WriteAttributeValue("", 2464, "deleteContributor?id=", 2464, 21, true);
#nullable restore
#line 47 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
WriteAttributeValue("", 2485, dr["contributorId"], 2485, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-danger rounded-0\" onclick=\"return confirm(\'Are You Sure You Wish To Delete This Record \');\">Delete</a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 50 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("       \r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 68 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
  await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 73 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
      
        if (TempData["msg"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <script>\r\n                    alert(\'");
#nullable restore
#line 77 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
                      Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \');\r\n            </script>\r\n");
#nullable restore
#line 79 "C:\Shagufta Documents\Freelance work\QuizApp\Areas\Main\Views\Contributor\getContributor.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz_App.Areas.Main.Models.contributor> Html { get; private set; }
    }
}
#pragma warning restore 1591
