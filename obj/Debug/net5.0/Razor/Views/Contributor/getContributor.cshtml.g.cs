#pragma checksum "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b08d34d915d459940d9651b497441ced04f01a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contributor_getContributor), @"mvc.1.0.view", @"/Views/Contributor/getContributor.cshtml")]
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
#line 1 "C:\Shagufta Documents\Freelance work\QuizApp\Views\_ViewImports.cshtml"
using Quiz_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Shagufta Documents\Freelance work\QuizApp\Views\_ViewImports.cshtml"
using Quiz_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b08d34d915d459940d9651b497441ced04f01a7", @"/Views/Contributor/getContributor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5eddff45cd01d596818965338d209f8ffdc992c", @"/Views/_ViewImports.cshtml")]
    public class Views_Contributor_getContributor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz_App.Models.contributor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "normalAdminSaveUpdate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"table-responsive\" style=\"border-style:groove; border-color: red;text-align:center\">\r\n\r\n    <div class=\"btn-group\" style=\"background-image: url(\'/images/img1.jpg\');height:25%;\">\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b08d34d915d459940d9651b497441ced04f01a73841", async() => {
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Create Contributor\" formaction=\"normalAdminSaveUpdate\" class=\"btn btn-bd-primary\" />\r\n            <input type=\"submit\" value=\"Logout\" formaction=\"normalAdminLogout\" class=\"btn btn-default\">\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div><br />


    <table class=""table table-striped table-bordered table-hover table-condensed table-dark"" style=""margin-top:2%"">
        <thead>
            <tr style=""background-color:red"">
                <th scope=""col"">Contributor ID</th>
                <th scope=""col"">Full Name</th>
                <th scope=""col"">Address</th>
                <th scope=""col"">Mobile No</th>
                <th scope=""col"">Email Id</th>
                <th scope=""col"">User Name</th>
                <th scope=""col"">Password</th>
                <th scope=""col"">Contributor CreatedBy</th>
                <th scope=""col"">Admin Location</th>
                <th scope=""col"">Date Created</th>
                <th scope=""col"">Date Modified</th>
                <th scope=""col"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 33 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
              
                foreach (System.Data.DataRow dr in ViewBag.contributor.Rows)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"active\">\r\n                        <td>");
#nullable restore
#line 37 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["contributorId"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["fullName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 39 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["address"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["mobileNo"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["emailId"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 42 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["userName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["password"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["contributor_createdBy"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 45 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["adminLocation"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 46 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["dateCreated"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                       Write(dr["dateModified"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2296, "\"", 2357, 2);
            WriteAttributeValue("", 2303, "/Contributor/updateContributor?id=", 2303, 34, true);
#nullable restore
#line 49 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
WriteAttributeValue("", 2337, dr["contributorId"], 2337, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:aqua\">Update</a>|\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2421, "\"", 2482, 2);
            WriteAttributeValue("", 2428, "/Contributor/deleteContributor?id=", 2428, 34, true);
#nullable restore
#line 50 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
WriteAttributeValue("", 2462, dr["contributorId"], 2462, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red\">Delete</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 53 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
#nullable restore
#line 58 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
  
    if (TempData["msg"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n                    alert(\'");
#nullable restore
#line 62 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
                      Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \');\r\n        </script>\r\n");
#nullable restore
#line 64 "C:\Shagufta Documents\Freelance work\QuizApp\Views\Contributor\getContributor.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz_App.Models.contributor> Html { get; private set; }
    }
}
#pragma warning restore 1591
