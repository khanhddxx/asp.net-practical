

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Report VCM/Danh sách NCC chưa có User", typeof(eLink.BookingVcmReport.Pages.CssVcmBaoCaoNCCController))]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmBaoCaoNCC"), Route("{action=index}")]
    public class CssVcmBaoCaoNCCController : Controller
    {
        [PageAuthorize("BaoCaoNCC")]
        public ActionResult Index()
        {
            return View("~/Modules/BookingVcmReport/CssVcmBaoCaoNCC/CssVcmBaoCaoNCCIndex.cshtml");
        }
    }
}