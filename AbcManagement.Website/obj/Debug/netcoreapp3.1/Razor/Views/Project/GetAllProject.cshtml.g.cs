#pragma checksum "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef8925e48174935504d7a7f31c773ba566f052a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_GetAllProject), @"mvc.1.0.view", @"/Views/Project/GetAllProject.cshtml")]
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
#line 1 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\_ViewImports.cshtml"
using AbcManagement.Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\_ViewImports.cshtml"
using AbcManagement.Website.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef8925e48174935504d7a7f31c773ba566f052a2", @"/Views/Project/GetAllProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd7fd792be828c1420bf7e181fd41558dac8f559", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_GetAllProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AbcManagement.Website.Models.UserProject>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    .delete {
        margin-left: 10px !important;
    }

    .redClass {
        background-color: white !important;
    }
</style>
<div class=""card"">
    <div class=""card-block"">

        <div class=""dt-responsive table-responsive"">
            <table id=""footer-search"" class=""table table-striped table-bordered nowrap"">
                <thead>
                    <tr class=""thcol"">
                        <th>Icon</th>
                        <th>Project Name</th>
                        <th>Progress</th>
                        <th>User</th>                      
                        <th>Açıklama</th>
                        <th class=""serc text-center"">Eylem</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 28 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                     foreach (var item in Model.myProject)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"colum\">\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                       Write(item.Icon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                       Write(item.ProjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                       Write(item.Progress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                       Write(Model.myUser.Where(x=>x.Id==item.AppUserId).FirstOrDefault().UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                   \r\n                  \r\n                        <td class=\"serc text-center\">\r\n                            <a href=\"#\" class=\"btn btn-danger btn-sm\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1376, "\"", 1407, 3);
            WriteAttributeValue("", 1386, "deleteOrder(", 1386, 12, true);
#nullable restore
#line 37 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
WriteAttributeValue("", 1398, item.Id, 1398, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1406, ")", 1406, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"icofont icofont-ui-delete\"></i> <span class=\"delete\">Delete</span></a>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1521, "\"", 1586, 1);
#nullable restore
#line 38 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
WriteAttributeValue("", 1528, Url.Action("DemirbasUpdate","Demirbas",new {id=item.Id }), 1528, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info btn-sm\"><i class=\"icofont icofont-ui-reply\"></i> <span class=\"sil\">Update</span></a>\r\n\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
                <tfoot>
                </tfoot>
            </table>
        </div>
    </div>
</div>


<script>
    $('#footer-search').DataTable({
        dom: 'Bfrtip',
        ""language"": {
            ""url"": ""//cdn.datatables.net/plug-ins/1.10.19/i18n/Turkish.json""
        },
        ""createdRow"": function (row, data, dataIndex) {
            $(row).addClass('redClass');
        },
        ""pageLength"": 5,
        buttons: [

        ]
    });
</script>

<script>
        function deleteOrder(id) {
        Swal.fire({
        title: ""Uyarı"",
        text: ""Seçtiğiniz Kayıt Silinsin mi?"",
        icon: ""warning"",
        showCancelButton: true,
        closeOnConfirm: false,
        confirmButtonClass: ""btn-danger"",
        confirmButtonText: ""SİL"",
            confirmButtonColor: ""#ec6c62"",
        cancelButtonText: ""Iptal"",
        }).then((result) => {
        if (result.value) {
        $.ajax({
        url: '");
#nullable restore
#line 83 "C:\Users\Yunus\Desktop\AbcManagement.Website\AbcManagement.Website\Views\Project\GetAllProject.cshtml"
         Write(Url.Action("DeleteDemirbas", "Demirbas"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
        data: { ""id"": id },
        type: ""POST""
        }).done(function (data) {
        if (data) {
        Swal.fire
        ({
        title: ""Başarılı!"",
        text: ""Kayıt Silindi"",
        icon: ""success""
        }).then(function () {
        window.location.href = '/Demirbaşlar/demirbaş_listesi';
        });
        }
        else {
        Swal.fire(""Oops"", ""Kayıt Silinemedi"", ""error"");
        }
        }).fail(function () {
        Swal.fire(""Oops"", ""Server tarafında hata oluştu."", ""error"");
        });
        }
        else {
        Swal.fire(""Oops"", ""Kayıt Silinemedi"", ""error"");
        }
        });
        }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AbcManagement.Website.Models.UserProject> Html { get; private set; }
    }
}
#pragma warning restore 1591
