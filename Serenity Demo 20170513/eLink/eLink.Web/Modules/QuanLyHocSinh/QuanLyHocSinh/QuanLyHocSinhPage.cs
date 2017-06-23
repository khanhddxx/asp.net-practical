

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "QuanLyHocSinh/QuanLyHocSinh", typeof(eLink.QuanLyHocSinh.Pages.QuanLyHocSinhController))]

namespace eLink.QuanLyHocSinh.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("QuanLyHocSinh/QuanLyHocSinh"), Route("{action=index}")]
    public class QuanLyHocSinhController : Controller
    {
        [PageAuthorize("Adminstration")]
        public ActionResult Index()
        {
            return View("~/Modules/QuanLyHocSinh/QuanLyHocSinh/QuanLyHocSinhIndex.cshtml");
        }
    }
}