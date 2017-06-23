
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
    using MyRepository = Repositories.CssVcmBaoCaoDatHangKheThoiGianRepository;
    using MyRow = Entities.CssVcmBaoCaoDatHangKheThoiGianRow;
    using RelationRow = Entities.CssVcmDanhSachPoRow;

    [RoutePrefix("Services/BookingVcmReport/CssVcmBaoCaoDatHangKheThoiGian"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmBaoCaoDatHangKheThoiGianController : ServiceEndpoint
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



            var lstResult = new ListResponse<MyRow>();
            lstResult.Entities = new List<MyRow>();
            DateTime sDate = DateTime.Now;
            var lstPo = connection.Query<RelationRow>(string.Format(@"SELECT                                             po.GIO_GIAO AS GioGiao,
                                    SUM(det.OrderQuantity) AS QUANTITY
                            FROM    dbo.CSS_VCM_DANH_SACH_PO po WITH ( NOLOCK )
                                    INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK ) ON            po.MA_PO = det.MA_PO
                            WHERE   po.GIO_GIAO IS NOT NULL
                                    AND po.NGAY_GIAO >= '{0}'
                                    AND po.NGAY_GIAO <= '{1}'
                                    AND po.TRANG_THAI IN ('DA_CHAP_NHAN','DA_NHAN_HANG')
                            GROUP BY po.GIO_GIAO;
		", tuNgay.ToString("yyyyMMdd"), denNgay.ToString("yyyyMMdd")));


            Dictionary<string, MyRow> dicResult = new Dictionary<string, MyRow>();
            for (var day = tuNgay.Date; day.Date < denNgay.AddDays(1); day = day.AddDays(1))
            {
                var lstKheThoiGian = getListKheThoiGian(connection, day);
                if (lstKheThoiGian.Count() > 0)
                {
                    foreach (var kheThoiGian in lstKheThoiGian)
                    {
                        kheThoiGian.SoLuong = 0;
                        kheThoiGian.ChenhLech = 0;
                        string key = kheThoiGian.NgayGiao + "_" + kheThoiGian.KheThoiGian;
                        dicResult.Add(key, kheThoiGian);
                    }
                }
            }
            var lstKheThoiGianAll = getListKheThoiGianAll(connection);
            foreach (RelationRow item in lstPo.ToList())
            {
                var gioGiao = item.GioGiao.Value;
                var mykheThoiGian = getKheThoiGian(gioGiao, lstKheThoiGianAll);

                if (mykheThoiGian != null)
                {
                    string key = mykheThoiGian.NgayGiao + "_" + mykheThoiGian.KheThoiGian;
                    dicResult[key].SoLuong += Convert.ToInt32(item.Quantity);
                }
            }
            if (dicResult.IsEmptyOrNull()) return new ListResponse<MyRow>();

            int i = 0;
            foreach (var key in dicResult.Keys)
            {
                i++;
                dicResult[key].Id = i;
                dicResult[key].ChenhLech = dicResult[key].SoLuongToiDa - dicResult[key].SoLuong;
                
               lstResult.Entities.Add(dicResult[key]);
            }
            return lstResult;
        }

        private bool TimeInRange(DateTime day, TimeSpan t1, TimeSpan t2, bool isLast = false)
        {
            bool compare = false;
            if (!isLast)
                compare
                = TimeSpan.Compare(day.TimeOfDay, t1) >= 0 && TimeSpan.Compare(day.TimeOfDay, t2) < 0;
            else
                compare
               = TimeSpan.Compare(day.TimeOfDay, t1) >= 0 && TimeSpan.Compare(day.TimeOfDay, t2) <= 0;
            return compare;
        }

        private void SetDictionaryKeyValue(Dictionary<string, RelationRow> dic, RelationRow row, int startTime)
        {
            string key = row.GioGiao.Value.ToString("ddMMyyyy") + "_" + startTime;
            if (row.Quantity != null)
                dic[key].Quantity += row.Quantity;
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.CssVcmBaoCaoDatHangKheThoiGianColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "BaoCaoKheThoiGian_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        public IEnumerable<MyRow> getListKheThoiGianAll(IDbConnection connection)
        {
            var listKheThoiGianAll = connection.Query<MyRow>(@"SELECT KHE_THOI_GIAN as KheThoiGian,
                                            FROM_TIME as FromTime,
                                            TO_TIME as ToTime,
                                            DAY_OF_WEEK as DayOfWeek,
                                            SO_LUONG_TOI_DA as SoLuongToiDa,
                                            EQUAL_FROM_TIME as EqualFromTime,
                                            EQUAL_TO_TIME as EqualToTime
                                            FROM dbo.CSS_VCM_BAO_CAO_DAT_HANG_KHE_THOI_GIAN WITH(NOLOCK)  ORDER BY FROM_TIME");

            return listKheThoiGianAll;
        }
        public IEnumerable<MyRow> getListKheThoiGian(IDbConnection connection, DateTime ngayGiao)
        {
            var listKheThoiGianAll = getListKheThoiGianAll(connection);
            var listKheThoiGian = new List<MyRow>();
            foreach (var kheThoiGian in listKheThoiGianAll)
            {
                DateTime myFromTime = kheThoiGian.FromTime.Value;
                DateTime myToTime = kheThoiGian.ToTime.Value;
                kheThoiGian.NgayGiao = ngayGiao.ToString("dd/MM/yyyy");
                kheThoiGian.FromTime = new DateTime(ngayGiao.Year, ngayGiao.Month, ngayGiao.Day, myFromTime.Hour, myFromTime.Minute, myFromTime.Millisecond);
                kheThoiGian.FromTime = new DateTime(ngayGiao.Year, ngayGiao.Month, ngayGiao.Day, myToTime.Hour, myToTime.Minute, myToTime.Millisecond);

                if (kheThoiGian.DayOfWeek.Contains(ngayGiao.DayOfWeek.ToString()))
                    listKheThoiGian.Add(kheThoiGian);
            }
            return listKheThoiGian;
        }

        public MyRow getKheThoiGian(DateTime gioGiao, IEnumerable<MyRow> lstKheThoiGian)
        {
            double myGioGiao = gioGiao.TimeOfDay.TotalHours;
            if (gioGiao == DateTime.MinValue) { return null; }
            foreach (var kheThoiGian in lstKheThoiGian)
            {
                double fromTimeTotalHours = kheThoiGian.FromTime.Value.TimeOfDay.TotalHours;
                double toTimeTotalHours = kheThoiGian.ToTime.Value.TimeOfDay.TotalHours;
                bool equalFromTime = kheThoiGian.EqualFromTime.Value;
                bool equalToTime = kheThoiGian.EqualToTime.Value;

                if (((myGioGiao >= fromTimeTotalHours && equalFromTime) || (myGioGiao > fromTimeTotalHours && !equalFromTime))
                    && ((myGioGiao <= toTimeTotalHours && equalToTime) ||(myGioGiao < toTimeTotalHours && !equalToTime))
                    && kheThoiGian.DayOfWeek.Contains(gioGiao.DayOfWeek.ToString()))
                {
                    DateTime myFromTime = kheThoiGian.FromTime.Value;
                    DateTime myToTime = kheThoiGian.ToTime.Value;
                    kheThoiGian.NgayGiao = gioGiao.ToString("dd/MM/yyyy");
                    kheThoiGian.FromTime = new DateTime(gioGiao.Year, gioGiao.Month, gioGiao.Day, myFromTime.Hour,myFromTime.Minute,myFromTime.Millisecond);
                    kheThoiGian.ToTime = new DateTime(gioGiao.Year, gioGiao.Month, gioGiao.Day, myToTime.Hour, myToTime.Minute, myToTime.Millisecond);

                    return kheThoiGian;
                }
            }
            return null;
        }
    }
}
