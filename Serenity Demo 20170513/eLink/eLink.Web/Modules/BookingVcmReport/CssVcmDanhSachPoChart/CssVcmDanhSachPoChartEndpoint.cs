using System.Collections.Generic;
using System.Linq;
using eLink.BookingVcmReport.Entities;
using Serenity;

namespace eLink.BookingVcmReport.Endpoints
{
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Web.Mvc;

    using RelationRow = Entities.CssVcmDanhSachPoRow;

    [RoutePrefix("Services/BookingVcmReport/CssVcmDanhSachPoChart"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmDanhSachPoChartController : ServiceEndpoint
    {
        public CssVcmDanhSachPoResponse CssVcmDanhSachPoGetDataChart(IDbConnection connection, CssVcmDanhSachPoRequest request)
        {
            DateTime sDate = DateTime.Now;
            var response = new CssVcmDanhSachPoResponse();
            var sumQuantity = connection.Query<RelationRow>(string.Format(@"SELECT                               po.NGAY_GIAO AS NgayGiao,
                                    SUM(det.OrderQuantity) AS QUANTITY
                            FROM    dbo.CSS_VCM_DANH_SACH_PO po WITH ( NOLOCK )
                                    INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK ) ON po.MA_PO = det.MA_PO
                            WHERE   po.NGAY_GIAO IS NOT NULL
                                    AND po.NGAY_GIAO >= '{0}'
                                    AND po.NGAY_GIAO < '{1}'
                                    AND po.TRANG_THAI IN ('DA_HEN_GIAO','DA_CHAP_NHAN','DA_NHAN_HANG')
                            GROUP BY po.NGAY_GIAO;
		", sDate.AddDays(1).ToString("yyyyMMdd"), sDate.AddDays(7).ToString("yyyyMMdd")));

            response.Values = new List<Dictionary<string, object>>();
            for (var day = sDate.Date; day.Date < sDate.AddDays(8).Date; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Sunday) continue;
                var d = new Dictionary<string, object>
                {
                    ["Day"] = day.ToString("dd/MM")
                };

                foreach (var sum in sumQuantity.ToList())
                {
                    var ngay = d["Day"];

                    if (!ngay.Equals(sum.NgayGiao.Value.ToString("dd/MM")))
                        continue;

                    var quantity = sum.Quantity;
                    if (sum.NgayGiao.Value.DayOfWeek == DayOfWeek.Saturday)
                        quantity = (quantity / 275000) * 100;
                    else
                        quantity = (quantity / 550000) * 100;

                    d["s"] = Math.Round(Convert.ToDouble(quantity),2);
                }
                response.Values.Add(d);
            }
            response.Values.Insert(0,new Dictionary<string, object>() { ["Day"] = "Max" , ["s"] = 100 });

            return response;
        }
    }
}