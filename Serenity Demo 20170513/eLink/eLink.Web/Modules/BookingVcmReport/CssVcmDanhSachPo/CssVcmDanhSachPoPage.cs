[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Booking VCM/Upload PO", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoController), null, "KhoUpLoadDanhSach")]
[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Booking VCM/NCC hẹn lịch giao", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoController), null, "NhaCungCapHenGiao")]
[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Booking VCM/Kho xác nhận lịch giao", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoController), null, "KhoXacNhanLichGiao")]
[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Booking VCM/Kho nhận hàng thực tế", typeof(eLink.BookingVcmReport.Pages.CssVcmDanhSachPoController), null, "ThongTinKhoDaXacNhan")]

namespace eLink.BookingVcmReport.Pages
{
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("BookingVcmReport/CssVcmDanhSachPo"), Route("{action=index}")]
    public class CssVcmDanhSachPoController : Controller
    {
        [PageAuthorize("UploadPO")]
        public ActionResult KhoUpLoadDanhSach()
        {
            eLink.BookingVcmReport.Endpoints.CssVcmDanhSachPoController.menuAccess = "KhoUpLoadDanhSach";
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPo/Indext/CssVcmDanhSachPoIndex.cshtml");
        }

        [PageAuthorize("NhaCungCapHenGiao")]
        public ActionResult NhaCungCapHenGiao()
        {
            eLink.BookingVcmReport.Endpoints.CssVcmDanhSachPoController.menuAccess = "NhaCungCapHenGiao";
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPo/Indext/CssVcmDanhSachPo_NhaCungCapHenGiaoIndex.cshtml");
        }

        [PageAuthorize("KhoXacNhanLichGiao")]
        public ActionResult KhoXacNhanLichGiao()
        {
            eLink.BookingVcmReport.Endpoints.CssVcmDanhSachPoController.menuAccess = "KhoXacNhanLichGiao";
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPo/Indext/CssVcmDanhSachPo_KhoXacNhanLichGiaoIndex.cshtml");
        }
        [PageAuthorize("ThongTinKhoDaXacNhan")]
        public ActionResult ThongTinKhoDaXacNhan()
        {
            eLink.BookingVcmReport.Endpoints.CssVcmDanhSachPoController.menuAccess = "ThongTinKhoDaXacNhan";
            return View("~/Modules/BookingVcmReport/CssVcmDanhSachPo/Indext/CssVcmDanhSachPo_ThongTinKhoDaXacNhanIndex.cshtml");
        }
       
    }
}