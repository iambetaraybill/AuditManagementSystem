#pragma checksum "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "857dbbd8ec1c592dddc7dd89911204eb0489a7d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Severity), @"mvc.1.0.view", @"/Views/Home/Severity.cshtml")]
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
#line 1 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalClientMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\_ViewImports.cshtml"
using AuditManagementPortalClientMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"857dbbd8ec1c592dddc7dd89911204eb0489a7d9", @"/Views/Home/Severity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20c721f622f3e793f6eed981d572aca984194617", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Severity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuditManagementPortalClientMVC.Models.AuditResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
  
    Layout = "_Authenticated";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
   ViewData["Title"] = "SeverityResult"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Result Based On Audit Request</h1>\r\n\r\n");
#nullable restore
#line 12 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
 if (Model.ProjectExexutionStatus == "GREEN")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\" background-color: lawngreen;\">\r\n        <h1>Audit Id :</h1>\r\n        <h3>");
#nullable restore
#line 16 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
       Write(Model.AuditId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n        <h1>Project Execution Status :</h1>\r\n        <h3> ");
#nullable restore
#line 18 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.ProjectExexutionStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <h1>Remedial Action Duration :</h1>\r\n        <h3> ");
#nullable restore
#line 20 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.RemedialActionDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n    </div>\r\n");
#nullable restore
#line 23 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"


}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\" background-color: red; color: white;\">\r\n        <h1>Audit Id :</h1>\r\n        <h3>");
#nullable restore
#line 30 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
       Write(Model.AuditId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n        <h1>Project Execution Status :</h1>\r\n        <h3> ");
#nullable restore
#line 32 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.ProjectExexutionStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <h1>Remedial Action Duration :</h1>\r\n        <h3> ");
#nullable restore
#line 34 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"
        Write(Model.RemedialActionDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n    </div>\r\n");
#nullable restore
#line 37 "D:\MyAspDotNetProjects\AuditManagementPortalClientMVC\Views\Home\Severity.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuditManagementPortalClientMVC.Models.AuditResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
