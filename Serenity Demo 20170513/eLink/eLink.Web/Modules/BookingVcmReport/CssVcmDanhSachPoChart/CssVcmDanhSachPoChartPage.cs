[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Report VCM/Biểu đồ đặt hàng", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoChartController))]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmDanhSachPoChart"), Route("{action=index}")]
    public class CssVcmDanhSachPoChartController : Controller
    {
        [PageAuthorize("DanhSachPoChart"), Route("~/")]
        public ActionResult Index()
        {
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPoChart/Index.cshtml");
        }
    }
}