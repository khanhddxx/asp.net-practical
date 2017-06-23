[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Report VCM/Báo cáo danh sách PO sắp nhận", typeof(eLink.BookingVcmReport.Pages.CssVcmBaoCaoDanhSachPOSapNhanPageController), null, "BaoCaoDanhSachPOSapNhan")]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmBaoCaoDanhSachPOSapNhan"), Route("{action=index}")]
    public class CssVcmBaoCaoDanhSachPOSapNhanPageController : Controller
    {        
        [PageAuthorize("BaoCaoDanhSachPOSapNhan")]
        public ActionResult BaoCaoDanhSachPOSapNhan()
        {
            return View("~/Modules/BookingVcmReport/CssVcmBaoCaoDanhSachPOSapNhan/CssVcmBaoCaoDanhSachPOSapNhanIndex.cshtml");
        }
    }
}