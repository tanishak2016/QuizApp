#pragma checksum "G:\Quiz App\Quiz App\Views\Account\normalAdminSaveUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bf342cdb105c19e2fe51871001d40d21c71c594"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_normalAdminSaveUpdate), @"mvc.1.0.view", @"/Views/Account/normalAdminSaveUpdate.cshtml")]
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
#line 1 "G:\Quiz App\Quiz App\Views\_ViewImports.cshtml"
using Quiz_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Quiz App\Quiz App\Views\_ViewImports.cshtml"
using Quiz_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf342cdb105c19e2fe51871001d40d21c71c594", @"/Views/Account/normalAdminSaveUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5eddff45cd01d596818965338d209f8ffdc992c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_normalAdminSaveUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz_App.Models.normalAdmin>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "G:\Quiz App\Quiz App\Views\Account\normalAdminSaveUpdate.cshtml"
  
    ViewData["Title"] = "This is Normal Admin Page...";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral(@"
<div class=""container"">
    <div class=""col-md-6 mx-auto text-center"">
        <div class=""header-title"">
            <h1 class=""wv-heading--title"">
                Create or Update New Admin Here
            </h1>

        </div>
    </div>
    <div class=""row"">
        <div class=""col-sm-6 mx-auto"" style=""text-align:center;background-color:antiquewhite;border-style:dashed;border-color:red"">
            <div class=""myform form "">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bf342cdb105c19e2fe51871001d40d21c71c5944632", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <input type=""text"" name=""name"" class=""form-control my-input""  placeholder=""Admin Name"" style=""width:50%;height:20%;background-color:white"">
                    </div>
                    <div class=""form-group"">
                        <input type=""text"" name=""phone"" class=""form-control my-input""  placeholder=""Phone Number"" style=""width: 50%; height: 20%; background-color: white"">
                    </div>
                    <div class=""form-group"">
                        <input type=""text"" name=""email"" class=""form-control my-input""  placeholder=""Assign User Name"" style=""width: 50%; height: 20%; background-color: white"">
                    </div>
                    <div class=""form-group"">
                        <input type=""text"" min=""0"" name=""password""  class=""form-control my-input"" placeholder=""Admin Password"" style=""width: 50%; height: 20%; background-color: white"">
                    </div>
                    <div ");
                WriteLiteral("class=\"text-center\" style=\"margin-left:32%\">\r\n                        <button type=\"submit\" class=\" btn btn-block send-button tx-tfm\">Submit</button>\r\n                    </div>\r\n");
                WriteLiteral("\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-sm-6 mx-auto\" style=\"text-align: center; background-color: antiquewhite; border-style: dashed; border-color: red\">\r\n            <h1>Admin List Here</h1>\r\n");
            WriteLiteral("        </div>  \r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 104 "G:\Quiz App\Quiz App\Views\Account\normalAdminSaveUpdate.cshtml"
   
    if(TempData!=null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <script>\r\n                   alert(\'");
#nullable restore
#line 108 "G:\Quiz App\Quiz App\Views\Account\normalAdminSaveUpdate.cshtml"
                     Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n               </script>\r\n");
#nullable restore
#line 110 "G:\Quiz App\Quiz App\Views\Account\normalAdminSaveUpdate.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz_App.Models.normalAdmin> Html { get; private set; }
    }
}
#pragma warning restore 1591
