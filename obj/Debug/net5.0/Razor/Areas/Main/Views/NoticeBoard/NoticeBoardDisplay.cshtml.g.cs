#pragma checksum "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cc1e4d3ec149e8e3fbd6f5ba1c15b5f2e1ddba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Main_Views_NoticeBoard_NoticeBoardDisplay), @"mvc.1.0.view", @"/Areas/Main/Views/NoticeBoard/NoticeBoardDisplay.cshtml")]
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
#line 1 "G:\Quiz App\Quiz App\Areas\Main\Views\_ViewImports.cshtml"
using Quiz_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Quiz App\Quiz App\Areas\Main\Views\_ViewImports.cshtml"
using Quiz_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cc1e4d3ec149e8e3fbd6f5ba1c15b5f2e1ddba9", @"/Areas/Main/Views/NoticeBoard/NoticeBoardDisplay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5eddff45cd01d596818965338d209f8ffdc992c", @"/Areas/Main/Views/_ViewImports.cshtml")]
    public class Areas_Main_Views_NoticeBoard_NoticeBoardDisplay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz_App.Areas.Main.Models.NoticeBoardProperties>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
  
    ViewData["Title"] = "Notice Board";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"container\">\r\n    \r\n    <div class=\"row\">\r\n");
            WriteLiteral("\r\n        <div class=\"card-header py-3\">\r\n            <a class=\"d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm\"");
            BeginWriteAttribute("href", " href=\"", 441, "\"", 498, 1);
#nullable restore
#line 17 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
WriteAttributeValue("", 448, Url.Action("welcome","welcome",new {Area="Main"}), 448, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <span class=""icon text-white-50"">
                    <i class=""fas fa-fast-backward""></i>
                </span>
                <span class=""text"">Go Back</span>
            </a>
        </div>
        <div class=""card shadow mb-4"" style=""width:100%"">



            <div class=""card-body"">
                <div class=""table-responsive"" style=""width:100%"">
                    <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                        
                        <thead>
                            <tr>
                                <td>
                                    <h6 class=""m-0 font-weight-bold text-primary"">All Notice Data</h6>

                                </td>
                            </tr>
                            <tr>
                                <th>Notie Title</th>
                                <th>Notice Description</th>
                                <th>Notice Created By</th>
           ");
            WriteLiteral(@"                     <th>Notice Modified By</th>
                                <th>Notice Date Created</th>
                                <th>Notice Date Modified</th>
                                <th>Notice Date Expiry</th>
                                <th>Notice Edit</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Notie Title</th>
                                <th>Notice Description</th>
                                <th>Notice Created By</th>
                                <th>Notice Modified By</th>
                                <th>Notice Date Created</th>
                                <th>Notice Date Modified</th>
                                <th>Notice Date Expiry</th>
                                <th>Notice Edit</th>
                            </tr>
                        </tfoot>
                        <tbody>

");
#nullable restore
#line 64 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                              
                                foreach (System.Data.DataRow dr in ViewBag.Notice.Rows)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"active\">\r\n                                        <td>");
#nullable restore
#line 68 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 69 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeDescription"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 70 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeCreatedBy"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 71 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeModifiedBy"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 72 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeDateCreated"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 73 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeDateModified"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 74 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                       Write(dr["NoticeDateExpiry"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3918, "\"", 3961, 2);
            WriteAttributeValue("", 3925, "NoticeBoardUpdate?id=", 3925, 21, true);
#nullable restore
#line 84 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
WriteAttributeValue("", 3946, dr["NoticeID"], 3946, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary rounded-0\">Edit</a>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 4060, "\"", 4103, 2);
            WriteAttributeValue("", 4067, "NoticeBoardDelete?id=", 4067, 21, true);
#nullable restore
#line 85 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
WriteAttributeValue("", 4088, dr["NoticeID"], 4088, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-danger rounded-0\" onclick=\"return confirm(\'Are You Sure You Wish To Delete This Record \');\">Delete</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 88 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>


    </div>
</div>


<script type=""text/javascript"">
    $(document).ready(function () {
        var table = $('#dataTable').DataTable({
            language: {
                searchPlaceholder: ""Search Results"",
            },
            ""lengthMenu"": [
                [5, 10, 25, 50, 100, -1],
                [5, 10, 25, 50, 100, ""All""]
            ],
            ""autoWidth"": true,
            ""responsive"": true,
            ""lengthChange"": true,
            ""ordering"": true,
            columnDefs: [{
                targets: [0,1],
                createdCell: function (cell) {
                    var $cell = $(cell);


                    $(cell).contents().wrapAll(""<div class='content'></div>"");
                    var $content = $cell.find("".content"");

                    $(cell).append($(""<button>Read more</button>""));
                    $btn = ");
            WriteLiteral(@"$(cell).find(""button"");

                    $content.css({
                        ""height"": ""50px"",
                        ""overflow"": ""hidden""
                    })
                    $cell.data(""isLess"", true);

                    $btn.click(function () {
                        var isLess = $cell.data(""isLess"");
                        $content.css(""height"", isLess ? ""auto"" : ""50px"")
                        $(this).text(isLess ? ""Read less"" : ""Read more"")
                        $cell.data(""isLess"", !isLess)
                    })
                }
            }]
        });

        //Moving Table Filtering Search Bar To A Table Header.
        $('#tableSearch').html($('.dataTables_filter'));
        //Moving Results Per Page DropDown Menu To A Table Header.
        $('#tablePerPage').html($('#table_length'));
    });


</script>






");
#nullable restore
#line 157 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
  await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 160 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
  
    if (TempData["msg"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n                    alert(\'");
#nullable restore
#line 164 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
                      Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \');\r\n        </script>\r\n");
#nullable restore
#line 166 "G:\Quiz App\Quiz App\Areas\Main\Views\NoticeBoard\NoticeBoardDisplay.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz_App.Areas.Main.Models.NoticeBoardProperties> Html { get; private set; }
    }
}
#pragma warning restore 1591
