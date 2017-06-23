

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "BookingVcmReport/CssVcmDanhSachPoDet", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoDetController))]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmDanhSachPoDet"), Route("{action=index}")]
    public class CssVcmDanhSachPoDetController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPoDet/CssVcmDanhSachPoDetIndex.cshtml");
        }
    }
}