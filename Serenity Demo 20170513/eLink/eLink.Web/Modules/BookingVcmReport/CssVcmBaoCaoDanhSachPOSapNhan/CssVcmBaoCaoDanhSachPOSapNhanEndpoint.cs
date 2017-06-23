using System.Linq;

namespace eLink.BookingVcmReport.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.CssVcmDanhSachPoRepository;
    using MyRow = Entities.CssVcmDanhSachPoRow;
    using DetailRow = Entities.CssVcmDanhSachPoDetRow;
    using OfficeOpenXml;
    using System.IO;
    using Repositories;
    using System.Collections.Generic;
    using Serenity.Reporting;

    [RoutePrefix("Services/BookingVcmReport/CssVcmBaoCaoDanhSachPOSapNhan"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmBaoCaoDanhSachPOSapNhanController : ServiceEndpoint
    {
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }

        [HttpPost]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        public static string menuAccess { set; get; }
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {

            ListResponse<MyRow> rs = new ListResponse<Entities.CssVcmDanhSachPoRow>();
            rs.Entities = new List<Entities.CssVcmDanhSachPoRow>();
            string sqlData = string.Format(@"SELECT  MA_PO AS MaPo ,
        NGAY_GIAO AS NgayGiao ,
        Vendor ,
        Vendor_SupplyingSite AS VendorSupplyingSite ,
        GHI_CHU GhiChu ,
        INSERT_DATE AS InsertDate ,
        INSERT_TIME AS InsertTime ,
        INSERT_USER AS InsertUser ,
        INSERT_USER_NAME AS InsertUserName ,
        UPDATE_DATE AS UpdateDate ,
        UPDATE_TIME AS UpdateTime ,
        UPDATE_USER AS UpdateUser ,
        UPDATE_USER_NAME AS UpdateUserName ,
        TRANG_THAI AS TrangThai ,
        GIO_GIAO AS GioGiao ,
        GHI_CHU_HEN_GIAO AS GhiChuHenGiao ,
        GHI_CHU_TU_CHOI AS GhiChuTuChoi ,
        TEN_TRANG_THAI AS TenTrangThai ,
        NV_LAI_XE AS NvLaiXe ,
        SDT_NV_LAI_XE AS SdtNvLaiXe ,
        BIEN_SO_XE AS BienSoXe ,
        NGAY_NHAN_THUC_TE AS NgayNhanThucTe ,
        GIO_NHAN_THUC_TE AS GioNhanThucTe
FROM    dbo.CSS_VCM_DANH_SACH_PO WITH ( NOLOCK )
WHERE   TRANG_THAI IN ('DA_CHAP_NHAN') AND GIO_GIAO >= '{0}'
        AND GIO_GIAO <= '{1}'", DateTime.Now.AddMinutes(-30).ToString("yyyyMMdd HH:mm"), DateTime.Now.AddHours(1).ToString("yyyyMMdd HH:mm"));

            var lstPo = connection.Query<MyRow>(sqlData);
            rs.Entities.AddRange(lstPo);
            return rs;
        }
      
    }
}
