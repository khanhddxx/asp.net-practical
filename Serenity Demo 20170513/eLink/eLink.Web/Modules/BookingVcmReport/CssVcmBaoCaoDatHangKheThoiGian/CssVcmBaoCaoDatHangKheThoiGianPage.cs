

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Report VCM/Báo cáo theo khe thời gian", typeof(eLink.BookingVcmReport.Pages.CssVcmBaoCaoDatHangKheThoiGianController))]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmBaoCaoDatHangKheThoiGian"), Route("{action=index}")]
    public class CssVcmBaoCaoDatHangKheThoiGianController : Controller
    {
        [PageAuthorize("BaoCaoDatHangKheThoiGian")]
        public ActionResult Index()
        {
            return View("~/Modules/BookingVcmReport/CssVcmBaoCaoDatHangKheThoiGian/CssVcmBaoCaoDatHangKheThoiGianIndex.cshtml");
        }
    }
}