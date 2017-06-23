

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Report VCM/Báo cáo theo tháng", typeof(eLink.BookingVcmReport.Pages.CssVcmBaoCaoDatHangThangController))]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmBaoCaoDatHangThang"), Route("{action=index}")]
    public class CssVcmBaoCaoDatHangThangController : Controller
    {
        [PageAuthorize("BaoCaoDatHangThang")]
        public ActionResult Index()
        {
            return View("~/Modules/BookingVcmReport/CssVcmBaoCaoDatHangThang/CssVcmBaoCaoDatHangThangIndex.cshtml");
        }
    }
}