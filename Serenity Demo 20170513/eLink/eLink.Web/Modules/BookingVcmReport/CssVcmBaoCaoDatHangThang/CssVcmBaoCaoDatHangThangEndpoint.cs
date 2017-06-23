
namespace eLink.BookingVcmReport.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Reporting;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using MyRepository = Repositories.CssVcmBaoCaoDatHangThangRepository;
    using MyRow = Entities.CssVcmBaoCaoDatHangThangRow;

    [RoutePrefix("Services/BookingVcmReport/CssVcmBaoCaoDatHangThang"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmBaoCaoDatHangThangController : ServiceEndpoint
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

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            DateTime tuNgay = DateTime.Now;
            DateTime denNgay = DateTime.Now.AddDays(7);

            if (request.Criteria.IsNull())
            {
                new ListResponse<MyRow>();
            }

            string jsonTuNgayDenNgay = request.Criteria.ToJson().Replace("[", "").Replace("]", "").Replace("\"", "");
            var arrCriteria = jsonTuNgayDenNgay.Split(',').ToList();

            if (arrCriteria.Count >= 7)
            {
                tuNgay = DateTime.ParseExact(arrCriteria[2], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                denNgay = DateTime.ParseExact(arrCriteria[6], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(-1);
            }
            string maNCC = string.Empty;
            if(request.EqualityFilter.ContainsKey("Vendor"))
            {
                maNCC = request.EqualityFilter["Vendor"].ToString();
            }

            var lstResult = new ListResponse<MyRow>();
            lstResult.Entities = new List<MyRow>();
            //DateTime date = DateTime.Now;
            //var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            //var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string strSql = string.Format(@"
                                    SELECT  po.MA_PO AS MaPo,
                                            po.Vendor,
                                            po.Vendor_SupplyingSite ,
                                    po.INSERT_DATE AS NgayDatHang ,
                                    po.NGAY_NHAN_THUC_TE AS NgayThucNhan ,
                                    ( SELECT    COUNT(DISTINCT det.Article)
                                      FROM      CSS_VCM_DANH_SACH_PO_DET WITH ( NOLOCK )
                                      WHERE     MA_PO = po.MA_PO
                                      GROUP BY  MA_PO
                                    ) AS SkuKeHoach ,
                                    ( SELECT    SUM(det.SO_LUONG_UPLOAD)
                                      FROM      CSS_VCM_DANH_SACH_PO_DET WITH ( NOLOCK )
                                      WHERE     MA_PO = po.MA_PO
                                      GROUP BY  MA_PO
                                    ) AS UnitKeHoach ,
                                    ( SELECT    COUNT(MA_PO)
                                      FROM      CSS_VCM_DANH_SACH_PO_DET WITH ( NOLOCK )
                                      WHERE     MA_PO = po.MA_PO
                                                AND OrderQuantity > 0
                                      GROUP BY  MA_PO
                                    ) AS SkuThucNhan ,
                                    ( SELECT    SUM(OrderQuantity)
                                      FROM      CSS_VCM_DANH_SACH_PO_DET WITH ( NOLOCK )
                                      WHERE     MA_PO = po.MA_PO
                                      GROUP BY  MA_PO
                                    ) AS UnitThucNhan ,
                                    po.GIO_GIAO AS GioGiao,
                                    po.GIO_NHAN_THUC_TE AS GioNhanThucTe,
                                    CAST(po.GIO_NHAN_THUC_TE - po.GIO_GIAO AS TIME(6)) AS ThoiGianTre ,
                                    po.GHI_CHU_HEN_GIAO AS GhiChuHenGiao
                            FROM    dbo.CSS_VCM_DANH_SACH_PO po WITH ( NOLOCK )
                                    INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK ) ON det.MA_PO = po.MA_PO
                            WHERE   po.TRANG_THAI = 'DA_NHAN_HANG'
                                    AND po.INSERT_DATE >= '{0}'
                                    AND po.INSERT_DATE <= '{1}'
                                    AND (1=1)
                            GROUP BY po.MA_PO ,
                                    po.Vendor,
                                    po.Vendor_SupplyingSite ,
                                    po.INSERT_DATE ,
                                    po.NGAY_NHAN_THUC_TE ,
                                    po.GIO_GIAO ,
                                    po.GIO_NHAN_THUC_TE ,
                                    po.GHI_CHU_HEN_GIAO;
		", tuNgay.ToString("yyyyMMdd"), denNgay.ToString("yyyyMMdd"));
            if(!string.IsNullOrWhiteSpace(maNCC))
            {
                strSql = strSql.Replace("(1=1)", string.Format("po.Vendor = '{0}' ",maNCC));
            }
            var lstPo = connection.Query<MyRow>(strSql);


            if (lstPo.ToList().IsEmptyOrNull())
                return new ListResponse<MyRow>(); ;
            int i = 0;
            foreach (MyRow item in lstPo)
            {
                item.Id = ++i;
                item.SkuChenhLech = item.SkuThucNhan - item.SkuKeHoach;
                item.UnitChenhLech = item.UnitThucNhan - item.UnitKeHoach;
                item.SkuTiLe = item.SkuKeHoach == 0 ? 0 : item.SkuChenhLech / item.SkuKeHoach * 100;
                item.UnitTiLe = item.UnitKeHoach == 0 ? 0 : item.UnitChenhLech / item.UnitKeHoach * 100;
                var unitDivided = item.UnitKeHoach == 0 ? 0 : item.UnitThucNhan / item.UnitKeHoach * 100;

                if (unitDivided < 85)
                    item.DeliveryInFullGrade = "D";
                else if (unitDivided >= 85 && unitDivided < 90)
                    item.DeliveryInFullGrade = "C";
                else if (unitDivided >= 90 && unitDivided < 95)
                    item.DeliveryInFullGrade = "B";
                else if (unitDivided >= 95 && unitDivided < 100)
                    item.DeliveryInFullGrade = "A";
                else
                    item.DeliveryInFullGrade = "A+";

                if (item.ThoiGianTre == null || item.ThoiGianTre > new TimeSpan(4, 0, 0))
                    item.DeliveryInTimeGrade = "D";
                else if (item.ThoiGianTre >= new TimeSpan(3, 0, 0) && item.ThoiGianTre <= new TimeSpan(4, 0, 0))
                    item.DeliveryInTimeGrade = "C";
                else if (item.ThoiGianTre >= new TimeSpan(2, 0, 0) && item.ThoiGianTre < new TimeSpan(3, 0, 0))
                    item.DeliveryInTimeGrade = "B";
                else if (item.ThoiGianTre >= new TimeSpan(1, 0, 0) && item.ThoiGianTre < new TimeSpan(2, 0, 0))
                    item.DeliveryInTimeGrade = "A";
                else
                    item.DeliveryInTimeGrade = "A+";
            }
            lstResult.Entities.AddRange(lstPo);
            return lstResult;
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.CssVcmBaoCaoDatHangThangColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "BaoCaoDatHang_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}
