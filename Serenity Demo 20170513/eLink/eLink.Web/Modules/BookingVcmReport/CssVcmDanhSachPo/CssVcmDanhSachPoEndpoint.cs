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
    using System.Linq;

    [RoutePrefix("Services/BookingVcmReport/CssVcmDanhSachPo"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmDanhSachPoController : ServiceEndpoint
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
            ListResponse<MyRow> rs = new MyRepository().List(connection, request);

            List<MyRow> lstRemove = new List<MyRow>();
            foreach (var a in rs.Entities)
            {
                List<string> lstStatus = new List<string>();
                //if (menuAccess == "KhoUpLoadDanhSach")
                //{
                //    lstStatus.Add("THEM_MOI");
                //}
                if (menuAccess == "NhaCungCapHenGiao")
                {
                    lstStatus.Add("DA_XAC_NHAN");
                    lstStatus.Add("TU_CHOI_GIAO_HANG");
                    lstStatus.Add("DA_HEN_GIAO");
                    lstStatus.Add("DA_CHAP_NHAN");
                }
                if (menuAccess == "KhoXacNhanLichGiao")
                {
                    lstStatus.Add("DA_HEN_GIAO");
                }
                if (menuAccess == "ThongTinKhoDaXacNhan")
                {
                    lstStatus.Add("DA_CHAP_NHAN");
                    lstStatus.Add("DA_NHAN_HANG");
                }
                if (lstStatus.Count >= 1 && !lstStatus.Contains(a.TrangThai))
                {
                    lstRemove.Add(a);
                }

                if (!Authorization.Username.ToString().ToUpper().Contains("VCM")
                    && !Authorization.Username.ToString().ToUpper().Contains("ADMIN")
                    && !Authorization.Username.ToString().ToUpper().Contains("KHO")
                    )
                {
                    if ((a as MyRow).Vendor.Trim().ToUpper() != Authorization.Username.Trim().ToUpper().Replace("NCC", ""))
                    {
                        lstRemove.Add(a);
                    }
                }

            }

            foreach (var a in lstRemove)
            {
                rs.Entities.Remove(a);
            }
            CssVcmBaoCaoDatHangKheThoiGianController kheThoiGianController = new CssVcmBaoCaoDatHangKheThoiGianController();
            var lstKheThoiGianAll = kheThoiGianController.getListKheThoiGianAll(connection);
            Dictionary<string, decimal> dicKheThoiGian_DaChapNhan = new Dictionary<string, decimal>();

            foreach (var po in rs.Entities)
            {
                if (po.GioGiao != null)
                {
                    var kheThoiGianRow = kheThoiGianController.getKheThoiGian(po.GioGiao.Value, lstKheThoiGianAll);
                    if (kheThoiGianRow != null)
                    {
                        string key = kheThoiGianRow.NgayGiao + "_" + kheThoiGianRow.KheThoiGian;
                        if (!dicKheThoiGian_DaChapNhan.ContainsKey(key))
                        {

                            decimal soLuongDaChapNhan = GetNumberOfPoDeliveryOnTime(connection, kheThoiGianRow.FromTime.Value, kheThoiGianRow.ToTime.Value, kheThoiGianRow.EqualFromTime.Value, kheThoiGianRow.EqualToTime.Value);
                            dicKheThoiGian_DaChapNhan.Add(key, soLuongDaChapNhan);
                        }
                        po.SLKhungThoiGianDaXacNhan = dicKheThoiGian_DaChapNhan[key];
                    }
                }
            }
            return rs;
        }

        [HttpPost]
        public ExcelImportResponse ExcelImport(IUnitOfWork uow, ExcelImportRequest request)
        {
            request.CheckNotNull();
            Check.NotNullOrWhiteSpace(request.FileName, "filename");
            UploadHelper.CheckFileNameSecurity(request.FileName);
            if (!request.FileName.StartsWith("temporary/"))
                throw new ArgumentOutOfRangeException("filename");

            ExcelPackage ep = new ExcelPackage();
            using (var fs = new FileStream(UploadHelper.DbFilePath(request.FileName), FileMode.Open, FileAccess.Read))
                ep.Load(fs);

            var master = MyRow.Fields;

            var response = new ExcelImportResponse { ErrorList = new List<string>() };

            var worksheet = ep.Workbook.Worksheets[1];

            var duplicatePo = "";

            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var poNumber = Convert.ToString(worksheet.Cells[row, 3].Value ?? "");
                if (poNumber.IsTrimmedEmpty())
                    break;
                var site = Convert.ToString(worksheet.Cells[row, 12].Value ?? "");
                if (string.IsNullOrWhiteSpace(site))
                {
                    throw new Exception("PO " + poNumber + " không có site");
                }

                var po = uow.Connection.TryFirst<MyRow>(q => q
                            .Select(master.MaPo)
                            .Where(master.MaPo == poNumber));

                if (po != null)
                {
                    if (!duplicatePo.Contains(poNumber))
                        duplicatePo += poNumber + ",";
                }
            }

            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var poNumber = Convert.ToString(worksheet.Cells[row, 3].Value ?? "");
                if (poNumber.IsTrimmedEmpty())
                    break;

                if (duplicatePo.Contains(poNumber)) continue;

                var po = new DetailRow
                {
                    MaPo = poNumber,
                    Vendor = Convert.ToString(worksheet.Cells[row, 1].Value ?? ""),
                    VendorSupplyingSite = Convert.ToString(worksheet.Cells[row, 2].Value ?? ""),
                    Item = Convert.ToInt32(worksheet.Cells[row, 6].Value ?? 0),
                    Article = Convert.ToString(worksheet.Cells[row, 7].Value ?? ""),
                    ShortText = Convert.ToString(worksheet.Cells[row, 10].Value ?? ""),
                    OrderQuantity = Convert.ToDecimal(worksheet.Cells[row, 13].Value ?? 0),
                    OrderUnit = Convert.ToString(worksheet.Cells[row, 8].Value ?? ""),
                    GTIN = Convert.ToString(worksheet.Cells[row, 9].Value ?? ""),
                    MerchandiseCategory = Convert.ToString(worksheet.Cells[row, 11].Value ?? ""),
                    //Ctns = Convert.ToString(worksheet.Cells[row, 11].Value ?? ""),
                    //Weight = Convert.ToDecimal(worksheet.Cells[row, 12].Value ?? 0),
                    //Cbm = Convert.ToString(worksheet.Cells[row, 13].Value ?? ""),
                    //NameOfUploader = Convert.ToString(worksheet.Cells[row, 14].Value ?? ""),
                    //TelofUploader = Convert.ToString(worksheet.Cells[row, 15].Value ?? ""),
                    //Note = Convert.ToString(worksheet.Cells[row, 16].Value ?? ""),
                    //NvLaiXe = Convert.ToString(worksheet.Cells[row, 17].Value ?? ""),
                    //SdtNvLaiXe = Convert.ToString(worksheet.Cells[row, 18].Value ?? ""),
                    //BienSoXe = Convert.ToString(worksheet.Cells[row, 19].Value ?? ""),
                };

                po.InsertDate = po.InsertTime = po.UpdateTime = po.UpdateDate = DateTime.Now;

                po.SoLuongUpload = po.OrderQuantity;
                po.SoLuongNccHenGiao = po.OrderQuantity;

                if (uow.Connection.TryFirst<MyRow>(q => q
                 .Select(master.MaPo)
                 .Where(master.MaPo == po.MaPo)) == null)
                {
                    new MyRepository().Create(uow, new SaveWithLocalizationRequest<MyRow>
                    {
                        Entity = new MyRow()
                        {
                            MaPo = po.MaPo,
                            VendorSupplyingSite = po.VendorSupplyingSite,
                            Vendor = po.Vendor,
                            TrangThai = "THEM_MOI",
                            TenTrangThai = "Thêm mới",
                            InsertDate = DateTime.Now,
                            InsertUser = Authorization.Username,
                            InsertUserName = Authorization.Username,
                            DeliveryDate = Convert.ToDateTime(worksheet.Cells[row, 4].Value ?? DateTime.MinValue),
                            NvLaiXe = po.NvLaiXe,
                            Site = Convert.ToString(worksheet.Cells[row, 12].Value ?? ""),
                            ReleaseStrategy = Convert.ToString(worksheet.Cells[row, 5].Value ?? ""),
                            SdtNvLaiXe = po.SdtNvLaiXe,
                            BienSoXe = po.BienSoXe,
                        }
                    });
                    response.Inserted = response.Inserted + 1;
                }

                new CssVcmDanhSachPoDetRepository().Create(uow, new SaveWithLocalizationRequest<DetailRow>
                {
                    Entity = po
                });
            }
            if (!string.IsNullOrWhiteSpace(duplicatePo))
            {
                response.ErrorList.Add(string.Format("Đã upload thành công {0} PO. Các PO sau bị trùng : {1}" + Environment.NewLine, response.Inserted, duplicatePo.Remove(duplicatePo.Length - 1)));
            }
            return response;
        }

        [HttpPost]
        public ExcelImportResponse ExcelUpdate(IUnitOfWork uow, ExcelUpdateRequest request)
        {
            request.CheckNotNull();
            Check.NotNullOrWhiteSpace(request.FileName, "filename");
            UploadHelper.CheckFileNameSecurity(request.FileName);
            if (!request.FileName.StartsWith("temporary/"))
                throw new ArgumentOutOfRangeException("filename");

            ExcelPackage ep = new ExcelPackage();
            using (var fs = new FileStream(UploadHelper.DbFilePath(request.FileName), FileMode.Open, FileAccess.Read))
                ep.Load(fs);

            var master = MyRow.Fields;

            var response = new ExcelImportResponse { ErrorList = new List<string>() };

            var worksheet = ep.Workbook.Worksheets[1];

            //var connection = SqlConnections.NewByKey("Default");
            var connection = uow.Connection;
            List<string> dsMaPODistinct = new List<string>();
            List<DetailRow> lstDetUpload = new List<DetailRow>();
            string thongBaoQuaSoLuongKhoYeuCau = "";

            string trangThaiTrongNCCHenGiao = "'DA_XAC_NHAN', 'TU_CHOI_GIAO_HANG','DA_HEN_GIAO'";
            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var poNumber = Convert.ToString(worksheet.Cells[row, 1].Value ?? "");
                if (poNumber.IsTrimmedEmpty())
                    break;

                var po = new DetailRow
                {
                    MaPo = poNumber,
                    NvLaiXe = Convert.ToString(worksheet.Cells[row, 2].Value ?? ""),
                    SdtNvLaiXe = Convert.ToString(worksheet.Cells[row, 3].Value ?? ""),
                    BienSoXe = Convert.ToString(worksheet.Cells[row, 4].Value ?? ""),

                    Article = Convert.ToString(worksheet.Cells[row, 5].Value ?? ""),
                    ShortText = Convert.ToString(worksheet.Cells[row, 6].Value ?? ""),

                    OrderQuantity = Convert.ToDecimal(worksheet.Cells[row, 7].Value ?? 0),
                    OrderUnit = Convert.ToString(worksheet.Cells[row, 8].Value ?? ""),
                    Ctns = Convert.ToString(worksheet.Cells[row, 9].Value ?? ""),
                    Weight = Convert.ToDecimal(worksheet.Cells[row, 10].Value ?? 0),
                    Cbm = Convert.ToString(worksheet.Cells[row, 11].Value ?? ""),


                    NgaySanXuat = Convert.ToDateTime(worksheet.Cells[row, 12].Value ?? DateTime.MinValue),
                    NgayHetHan = Convert.ToDateTime(worksheet.Cells[row, 13].Value ?? DateTime.MinValue),

                };

                po.SoLuongNccHenGiao = po.OrderQuantity;

                lstDetUpload.Add(po);

                if (!dsMaPODistinct.Contains(po.MaPo))
                {
                    dsMaPODistinct.Add(po.MaPo);
                }

            }
            string maPO = "'" + string.Join("','", dsMaPODistinct) + "'";
            List<string> lstMaPOTheoTrangThai = getlstMaPOTheoTrangThai(connection, maPO, trangThaiTrongNCCHenGiao);
            if (lstMaPOTheoTrangThai.Count == 0)
            {
                throw new Exception("Không có PO nào trong file upload có trong NCC hẹn lịch giao. Không thể thực hiện cập nhật.");
            }
            foreach (DetailRow po in lstDetUpload)
            {
                if (lstMaPOTheoTrangThai.Contains(po.MaPo))
                {
                    decimal soLuong = Convert.ToDecimal(po.OrderQuantity ?? 0);
                    if (checkQuaSoLuongKhoYeuCau(connection, soLuong, po.MaPo, po.Article))
                    {
                        thongBaoQuaSoLuongKhoYeuCau = (string.IsNullOrWhiteSpace(thongBaoQuaSoLuongKhoYeuCau) ? "Danh sách mã PO - mã hàng có số lượng vượt quá số lượng kho yêu cầu :" : thongBaoQuaSoLuongKhoYeuCau) + Environment.NewLine + po.MaPo + " - " + po.Article;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(thongBaoQuaSoLuongKhoYeuCau))
            {
                throw new Exception(thongBaoQuaSoLuongKhoYeuCau);
            }
            dsMaPODistinct.Clear();
            foreach (DetailRow po in lstDetUpload)
            {
                var poNumber = po.MaPo;
                if (!dsMaPODistinct.Contains(poNumber))
                {
                    string sqlUpdateMaster = string.Format(@"UPDATE CSS_VCM_DANH_SACH_PO
                                    SET     NV_LAI_XE = N'{0}',
                                            SDT_NV_LAI_XE = '{1}',
                                            BIEN_SO_XE = N'{2}',
                                            UPDATE_DATE= '{4}',
                                            UPDATE_TIME= '{4}',
                                            UPDATE_USER= '{5}',
                                            TRANG_THAI = 'DA_XAC_NHAN',TEN_TRANG_THAI = N'Chuyển NCC' ,NGAY_GIAO = NULL,GIO_GIAO = NULL
                                    WHERE   MA_PO = '{6}' AND TRANG_THAI IN ( {7} ) ", po.NvLaiXe, po.SdtNvLaiXe, po.BienSoXe, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm"), Authorization.Username, po.MaPo, trangThaiTrongNCCHenGiao);

                    var successMaster = connection.Query<int>(sqlUpdateMaster);
                    response.Updated = response.Updated + 1;
                    dsMaPODistinct.Add(poNumber);
                }
                string ngaySanXuat = po.NgaySanXuat == DateTime.MinValue ? "NULL" : po.NgaySanXuat.ToSqlDate();
                string ngayHetHan = po.NgayHetHan == DateTime.MinValue ? "NULL" : po.NgayHetHan.ToSqlDate();
                string sqlUpdateDetail = string.Format(@"UPDATE CSS_VCM_DANH_SACH_PO_DET
                                    SET     OrderQuantity = '{0}',
                                            SO_LUONG_NCC_HEN_GIAO = '{0}',
                                            Ctns = '{1}',
                                            Cbm = '{2}',
                                            Weight = '{3}',
                                            UPDATE_DATE= '{4}',
                                            UPDATE_TIME= '{5}',
                                            UPDATE_USER= '{6}',
                                            NGAY_SAN_XUAT = {7},
                                            NGAY_HET_HAN = {8}
                                    WHERE   MA_PO = '{9}' AND Article = '{10}' 
                                            AND EXISTS ( SELECT TOP 1
                                                                    1
                                                             FROM   CSS_VCM_DANH_SACH_PO WITH ( NOLOCK )
                                                             WHERE  MA_PO = '{9}'
                                                                    AND TRANG_THAI IN ( {11} ) )", po.OrderQuantity, po.Ctns, po.Cbm, po.Weight, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm"), Authorization.Username, ngaySanXuat, ngayHetHan, po.MaPo, po.Article, trangThaiTrongNCCHenGiao);

                var successDetail = connection.Query<int>(sqlUpdateDetail);
            }
            return response;
        }
        [HttpPost]
        public ExcelImportResponse ExcelUpdateThongTinKhoXacNhan(IUnitOfWork uow, ExcelUpdateRequest request)
        {
            request.CheckNotNull();
            Check.NotNullOrWhiteSpace(request.FileName, "filename");
            UploadHelper.CheckFileNameSecurity(request.FileName);
            if (!request.FileName.StartsWith("temporary/"))
                throw new ArgumentOutOfRangeException("filename");

            ExcelPackage ep = new ExcelPackage();
            using (var fs = new FileStream(UploadHelper.DbFilePath(request.FileName), FileMode.Open, FileAccess.Read))
                ep.Load(fs);

            var master = MyRow.Fields;

            var response = new ExcelImportResponse { ErrorList = new List<string>() };

            var worksheet = ep.Workbook.Worksheets[1];

            //var connection = SqlConnections.NewByKey("Default");
            var connection = uow.Connection;
            List<string> dsMaPODistinct = new List<string>();
            List<DetailRow> lstDetUpload = new List<DetailRow>();
            string thongBaoQuaSoLuongKhoYeuCau = "";
            string trangThaiTrongThongTinKhoDaXacNhan = "'DA_CHAP_NHAN','DA_NHAN_HANG'";
            List<string> lstPOCoGioNhanThucTe = new List<string>();
            Dictionary<string, DateTime> dicPOGioNhanThucTe = new Dictionary<string, DateTime>();
            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var poNumber = Convert.ToString(worksheet.Cells[row, 1].Value ?? "");
                if (poNumber.IsTrimmedEmpty())
                    break;

                DateTime gioNhanThucTeUpload = DateTime.MinValue;
                if (worksheet.Cells[row, 5].Value != null)
                {
                    if (!lstPOCoGioNhanThucTe.Contains(poNumber))
                    {
                        lstPOCoGioNhanThucTe.Add(poNumber);
                        if (worksheet.Cells[row, 5].Value is DateTime)
                        {
                            DateTime tgTemp = Convert.ToDateTime(worksheet.Cells[row, 5].Value);
                            gioNhanThucTeUpload = DateTime.MinValue.AddHours(tgTemp.Hour).AddMinutes(tgTemp.Minute);
                        }
                        else
                        {
                            decimal a = Convert.ToDecimal(worksheet.Cells[row, 5].Value);

                            int min = (int)((a * 1440) % 60);
                            int hour = (int)((a * 1440) / 60);
                            gioNhanThucTeUpload = DateTime.MinValue.AddHours(hour).AddMinutes(min);
                        }
                    }
                }
                else
                {
                    if (!lstPOCoGioNhanThucTe.Contains(poNumber))
                    {
                        throw new Exception(string.Format("PO {0} không có giờ nhận thực tế", poNumber));
                    }
                }


                var po = new DetailRow
                {
                    MaPo = poNumber,

                    Article = Convert.ToString(worksheet.Cells[row, 2].Value ?? ""),
                    ShortText = Convert.ToString(worksheet.Cells[row, 3].Value ?? ""),

                    OrderQuantity = Convert.ToDecimal(worksheet.Cells[row, 4].Value ?? 0),

                    GioNhanThucTe = gioNhanThucTeUpload,
                };

                po.SoLuongThucNhan = po.OrderQuantity;

                lstDetUpload.Add(po);

                if (!dsMaPODistinct.Contains(po.MaPo))
                {
                    dsMaPODistinct.Add(po.MaPo);
                }

            }
            string maPO = "'" + string.Join("','", dsMaPODistinct) + "'";
            List<string> lstMaPOTheoTrangThai = getlstMaPOTheoTrangThai(connection, maPO, trangThaiTrongThongTinKhoDaXacNhan);
            if (lstMaPOTheoTrangThai.Count == 0)
            {
                throw new Exception("Không có PO nào trong file upload có trong thông tin kho Chuyển NCC. Không thể upload dữ liệu nhận thực tế.");
            }
            foreach (DetailRow po in lstDetUpload)
            {
                if (lstMaPOTheoTrangThai.Contains(po.MaPo))
                {
                    decimal soLuong = po.OrderQuantity.Value;
                    if (checkQuaSoLuongKhoYeuCau(connection, soLuong, po.MaPo, po.Article))
                    {
                        thongBaoQuaSoLuongKhoYeuCau = (string.IsNullOrWhiteSpace(thongBaoQuaSoLuongKhoYeuCau) ? "Danh sách mã PO - mã hàng có số lượng vượt quá số lượng kho yêu cầu :" : thongBaoQuaSoLuongKhoYeuCau) + Environment.NewLine + po.MaPo + " - " + po.Article;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(thongBaoQuaSoLuongKhoYeuCau))
            {
                throw new Exception(thongBaoQuaSoLuongKhoYeuCau);
            }

            dsMaPODistinct.Clear();
            foreach (DetailRow po in lstDetUpload)
            {
                var poNumber = po.MaPo;

                if (lstMaPOTheoTrangThai.Contains(poNumber))
                {
                    if (!dsMaPODistinct.Contains(poNumber))
                    {
                        DateTime gioNhanThucTeDefine = getGioNhanThucTeDefine(poNumber, po.GioNhanThucTe.Value);
                        DateTime ngayNhanThucTeDefine = gioNhanThucTeDefine;

                        string gioNhanThucTe = gioNhanThucTeDefine == DateTime.MinValue ? "NULL" : "'" + gioNhanThucTeDefine.ToString("yyyyMMdd HH:mm") + "'";
                        string ngayNhanThucTe = ngayNhanThucTeDefine == DateTime.MinValue ? "NULL" : "'" + ngayNhanThucTeDefine.ToString("yyyyMMdd") + "'";

                        string sqlUpdateMaster = string.Format(@"UPDATE CSS_VCM_DANH_SACH_PO
                                    SET     NGAY_NHAN_THUC_TE = {0},
                                            GIO_NHAN_THUC_TE = {1},                                           
                                            UPDATE_DATE= '{2}',
                                            UPDATE_TIME= '{3}',
                                            UPDATE_USER= '{4}',
                                            TRANG_THAI = 'DA_NHAN_HANG',TEN_TRANG_THAI = N'Đã nhận hàng'
                                    WHERE   MA_PO = '{5}' AND TRANG_THAI IN ( {6} ) ", ngayNhanThucTe, gioNhanThucTe, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm"), Authorization.Username, po.MaPo, trangThaiTrongThongTinKhoDaXacNhan);

                        var successMaster = connection.Query<int>(sqlUpdateMaster);
                        response.Updated = response.Updated + 1;
                        dsMaPODistinct.Add(poNumber);
                    }

                    string sqlUpdateDetail = string.Format(@"UPDATE CSS_VCM_DANH_SACH_PO_DET
                                    SET     OrderQuantity = '{0}',
                                            SO_LUONG_THUC_NHAN = '{0}',
                                            UPDATE_DATE= '{1}',
                                            UPDATE_TIME= '{2}',
                                            UPDATE_USER= '{3}'
                                    WHERE   MA_PO = '{4}' AND Article = '{5}' 
                                            AND EXISTS ( SELECT TOP 1
                                                                    1
                                                             FROM   CSS_VCM_DANH_SACH_PO WITH ( NOLOCK )
                                                             WHERE  MA_PO = '{4}'
                                                                    AND TRANG_THAI IN ( {6} ) )", po.OrderQuantity, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm"), Authorization.Username, po.MaPo, po.Article, trangThaiTrongThongTinKhoDaXacNhan);

                    var successDetail = connection.Query<int>(sqlUpdateDetail);
                }

            }

            return response;
        }


        [HttpPost]
        public BaseUpdateResponse UpdateStatus(IDbConnection connection, ListKeysRequest request)
        {
            request.CheckNotNull();
            if (request != null && request.Keys != null && request.Keys.Length == 1)
            {
                request.Keys = request.Keys[0].Split(',');
            }
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);
            //var connection = SqlConnections.NewByKey("Default");
            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"UPDATE  CSS_VCM_DANH_SACH_PO
                                    SET     TRANG_THAI = 'DA_XAC_NHAN',TEN_TRANG_THAI = N' Chuyển NCC',UPDATE_USER = '{1}',UPDATE_USER_NAME = '{1}',UPDATE_DATE = '{2}',UPDATE_TIME ='{3}'
                                    WHERE   TRANG_THAI = 'THEM_MOI'
                                            AND MA_PO IN ( '{0}' )", id, Authorization.Username, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm")));
            }
            return response;
        }


        public decimal GetNumberOfPo(IDbConnection connection, string maPO)
        {
            //var connection = SqlConnections.NewByKey("Default");
            var sumQuantity = connection.Query<decimal>(string.Format(@"SELECT isnull( SUM(det.OrderQuantity),0)
                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                        INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det ON mt.MA_PO = det.MA_PO
                                WHERE   mt.MA_PO = '{0}' ", maPO));
            return ((List<decimal>)sumQuantity).Count > 0 ? ((List<decimal>)sumQuantity)[0] : 0;
        }

        public decimal GetNumberOfPoDeliveryOnThisDay(IDbConnection connection, POUpdateDeliveryDateRequest request)
        {
            //var connection = SqlConnections.NewByKey("Default");
            var sumQuantity = connection.Query<decimal>(string.Format(@"SELECT isnull( SUM(det.OrderQuantity),0)
                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                        INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det ON mt.MA_PO = det.MA_PO
                                WHERE   mt.NGAY_GIAO = '{0}' AND mt.TRANG_THAI IN ('DA_HEN_GIAO','DA_CHAP_NHAN','DA_NHAN_HANG')", request.DeliveryDate.ToString("yyyyMMdd")));
            return ((List<decimal>)sumQuantity).Count > 0 ? ((List<decimal>)sumQuantity)[0] : 0;
        }

        public decimal GetNumberOfPoDeliveryOnTime(IDbConnection connection, DateTime fromTime, DateTime toTime, bool equalFromTime = true, bool equalToTime = true)
        {
            //var connection = SqlConnections.NewByKey("Default");
            string sqlSumQuantity = string.Format(@"SELECT isnull( SUM(det.OrderQuantity),0)
                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                        INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det ON mt.MA_PO = det.MA_PO
                                WHERE   mt.GIO_GIAO >= '{0}' AND mt.GIO_GIAO <= '{1}' AND mt.TRANG_THAI IN ('DA_CHAP_NHAN','DA_NHAN_HANG')", fromTime.ToString("yyyyMMdd HH:mm"), toTime.ToString("yyyyMMdd HH:mm"));
            if (!equalFromTime)
            {
                sqlSumQuantity = sqlSumQuantity.Replace("mt.GIO_GIAO >=", "mt.GIO_GIAO >");
            }
            if (!equalToTime)
            {
                sqlSumQuantity = sqlSumQuantity.Replace("mt.GIO_GIAO <=", "mt.GIO_GIAO <");
            }
            var sumQuantity = connection.Query<decimal>(sqlSumQuantity);
            return ((List<decimal>)sumQuantity).Count > 0 ? ((List<decimal>)sumQuantity)[0] : 0;
        }

        [HttpPost]
        public BaseUpdateResponse UpdateDeliveryDate(IUnitOfWork uow, POUpdateDeliveryDateRequest request)
        {
            request.CheckNotNull();
            if (request != null && request.Keys != null && request.Keys.Length == 1)
            {
                request.Keys = request.Keys[0].Split(',');
            }
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);

            //var connection = SqlConnections.NewByKey("Default");
            var connection = uow.Connection;
            var sumQuantity = connection.Query<String>(string.Format(@"SELECT  MA_PO
                                                             FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                             WHERE   mt.MA_PO IN ( '{0}' )
                                                             AND mt.TRANG_THAI NOT IN ( 'DA_XAC_NHAN', 'TU_CHOI_GIAO_HANG','DA_HEN_GIAO' );", id));
            if (sumQuantity != null)
                foreach (var sum in ((List<string>)sumQuantity))
                {
                    response.ErrorList.Add((sum));
                }
            double gioHienTai = DateTime.Now.TimeOfDay.TotalHours;
            DateTime ngayHenGiao = request.DeliveryDate;
            DateTime ngayDuocHenGiao = DateTime.Now;
            ngayDuocHenGiao = gioHienTai > 15 ? DateTime.Now.AddDays(2) : DateTime.Now.AddDays(1);

            if (ngayHenGiao.Date < ngayDuocHenGiao.Date)
            {
                //Để booking cho ngày N + 1 thì NCC phải book trước 3:00 chiều ngày N(sau 3:00 chiều không thể book được cho ngày N + 1), tuy nhiên NCC vẫn có thể book cho ngày N+2.
                throw new Exception(string.Format(@"Để booking cho ngày {0} thì NCC phải book trước 3:00 chiều ngày {1}. Ngày được hẹn giao {2}!", ngayHenGiao.ToString("dd/MM/yyyy"), ngayHenGiao.AddDays(-1).ToString("dd/MM/yyyy"), ngayDuocHenGiao.ToString("dd/MM/yyyy")));
            }
            //lấy số lượng đã có
            var deliveryDate = request.DeliveryDate;
            decimal sumQuantity_DaCoThoiGianGiao = GetNumberOfPoDeliveryOnThisDay(connection, request);
            string sqlSumQuantity_PO = string.Format(@"SELECT isnull( SUM(det.OrderQuantity),0)
                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                        INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det ON mt.MA_PO = det.MA_PO
                                WHERE   (mt.TRANG_THAI NOT IN ('DA_HEN_GIAO','DA_CHAP_NHAN','DA_NHAN_HANG') OR (mt.NGAY_GIAO <> '{0}' OR mt.NGAY_GIAO IS NULL)) AND mt.MA_PO IN ('{1}')", request.DeliveryDate.ToString("yyyyMMdd"), id);
            var sumQuantity_PO = connection.Query<decimal>(sqlSumQuantity_PO);
            var sumQuantity_PO_SapThem = ((List<decimal>)sumQuantity_PO).Count > 0 ? ((List<decimal>)sumQuantity_PO)[0] : 0;

            //Nếu không hợp lệ thì            
            int maxDonHang1Ngay = 0;

            double gioHenGiao = deliveryDate.TimeOfDay.TotalHours;

            if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
            {
                if (gioHenGiao > 12 || gioHenGiao < 7)
                {
                    throw new Exception("Thứ 7 chỉ chọn giờ giao 7h->12h");
                }
                maxDonHang1Ngay = 440000;
            }
            if (deliveryDate.DayOfWeek >= DayOfWeek.Monday && deliveryDate.DayOfWeek <= DayOfWeek.Friday)
            {
                if (gioHenGiao > 15 || gioHenGiao < 7)
                {
                    throw new Exception("Thứ 2->Thứ 6 chỉ chọn giờ giao 7h->15h");
                }
                maxDonHang1Ngay = 550000;
            }
            if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new Exception("Ngày giao phải khác chủ nhật!");
            }

            if ((sumQuantity_DaCoThoiGianGiao + sumQuantity_PO_SapThem) >= maxDonHang1Ngay)
            {
                throw new Exception(string.Format("Lượng đơn hàng ngày {0} không được vượt quá {1}!", deliveryDate.ToString("dd/MM/yyyy"), maxDonHang1Ngay));
            }

            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"UPDATE CSS_VCM_DANH_SACH_PO
                                    SET     NGAY_GIAO = '{0}',
                                            TRANG_THAI = 'DA_HEN_GIAO', GHI_CHU_HEN_GIAO = N'{1}', GIO_GIAO = '{2}' ,TEN_TRANG_THAI = N'Đã hẹn giao' 
                                    WHERE   MA_PO IN ( '{3}' )", request.DeliveryDate.ToString("yyyyMMdd"), request.Note, request.DeliveryDate.ToString("yyyy-MM-dd HH:mm"), id));
                response.Updated = lstId.Count;
            }
            //response.Updated++;
            return response;
        }
        [HttpPost]
        public BaseUpdateResponse ValidateXacNhanKhoXacNhanLichGiao(IDbConnection connection, ListKeysRequest request)
        {
            request.CheckNotNull();
            if (request != null && request.Keys != null && request.Keys.Length == 1)
            {
                request.Keys = request.Keys[0].Split(',');
            }
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);

            var lstPO = getThongTinDonHangTheoMaPO(connection, lstId);
            CssVcmBaoCaoDatHangKheThoiGianController kheThoiGianController = new CssVcmBaoCaoDatHangKheThoiGianController();
            var lstKheThoiGianAll = kheThoiGianController.getListKheThoiGianAll(connection);
            Dictionary<string, decimal> dicKheThoiGian_SoLuongToiDa = new Dictionary<string, decimal>();
            Dictionary<string, decimal> dicKheThoiGian_SoLuongSapChapNhan = new Dictionary<string, decimal>();
            Dictionary<string, decimal> dicKheThoiGian_DaChapNhan = new Dictionary<string, decimal>();

            foreach (var po in lstPO)
            {
                var kheThoiGianRow = kheThoiGianController.getKheThoiGian(po.GioGiao.Value, lstKheThoiGianAll);
                if (kheThoiGianRow != null)
                {
                    string key = kheThoiGianRow.NgayGiao + "_" + kheThoiGianRow.KheThoiGian;
                    if (!dicKheThoiGian_SoLuongToiDa.ContainsKey(key))
                    {
                        dicKheThoiGian_SoLuongToiDa.Add(key, kheThoiGianRow.SoLuongToiDa.Value);
                        dicKheThoiGian_SoLuongSapChapNhan.Add(key, 0);

                        decimal soLuongDaChapNhan = GetNumberOfPoDeliveryOnTime(connection, kheThoiGianRow.FromTime.Value, kheThoiGianRow.ToTime.Value, kheThoiGianRow.EqualFromTime.Value, kheThoiGianRow.EqualToTime.Value);
                        dicKheThoiGian_DaChapNhan.Add(key, soLuongDaChapNhan);
                    }
                    dicKheThoiGian_SoLuongSapChapNhan[key] += po.Quantity.Value;
                }
            }

            foreach (var key in dicKheThoiGian_SoLuongToiDa.Keys)
            {
                string ngay = key.Split('_')[0].Trim();
                string khungGio = key.Split('_')[1].Trim();
                decimal SoLuongToiDa = dicKheThoiGian_SoLuongToiDa[key];
                decimal soLuongDaChapNhan = dicKheThoiGian_DaChapNhan[key];
                decimal SoLuongSapChapNhan = dicKheThoiGian_SoLuongSapChapNhan[key];
                if (SoLuongSapChapNhan + soLuongDaChapNhan > SoLuongToiDa)
                {
                    string thongBao = string.Format("Ngày {0} khung giờ {1} đã xác nhận {2} unit.Nếu xác nhận thêm {3} unit sẽ vượt quá {4} unit tối đa",
                        ngay, khungGio, soLuongDaChapNhan.ToString("N0"), SoLuongSapChapNhan.ToString("N0"), SoLuongToiDa.ToString("N0"));
                    response.ErrorList.Add(thongBao);
                }
            }

            return response;

        }
        [HttpPost]
        public BaseUpdateResponse ConfirmWarehouseStatus(IDbConnection connection, ListKeysRequest request)
        {
            request.CheckNotNull();
            if (request != null && request.Keys != null && request.Keys.Length == 1)
            {
                request.Keys = request.Keys[0].Split(',');
            }
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);
            //var connection = SqlConnections.NewByKey("Default");

            var sumQuantity = connection.Query<String>(string.Format(@"SELECT  MA_PO
                                                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                                WHERE   mt.MA_PO IN ( '{0}' )
                                                                        AND mt.TRANG_THAI NOT IN ( 'DA_HEN_GIAO' );", id));
            if (sumQuantity != null)
                foreach (var sum in ((List<string>)sumQuantity))
                {
                    response.ErrorList.Add((sum));
                }


            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"
                                                        UPDATE  CSS_VCM_DANH_SACH_PO
                                                        SET     TRANG_THAI = 'DA_CHAP_NHAN', TEN_TRANG_THAI = N'Đã nhận lịch giao',UPDATE_USER = '{1}',UPDATE_USER_NAME = '{1}',UPDATE_DATE = '{2}',UPDATE_TIME ='{3}'
                                                        WHERE   MA_PO IN ( '{0}' );", id, Authorization.Username, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm")));


                guiMailThongBaoDonHangDuocKhoChapNhan(connection, lstId);
            }
            return response;
        }

        [HttpPost]
        public BaseUpdateResponse DenyWarehouseStatus(IDbConnection connection, POUpdateDeliveryDateRequest request)
        {
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);
            //var connection = SqlConnections.NewByKey("Default");
            var sumQuantity = connection.Query<String>(string.Format(@"SELECT  MA_PO
                                                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                                WHERE   mt.MA_PO IN ( '{0}' )
                                                                        AND mt.TRANG_THAI NOT IN ( 'DA_HEN_GIAO' );", id));
            if (sumQuantity != null)
                foreach (var sum in ((List<string>)sumQuantity))
                {
                    response.ErrorList.Add((sum));
                }

            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"
                                                        UPDATE  CSS_VCM_DANH_SACH_PO
                                                        SET     TRANG_THAI = 'TU_CHOI_GIAO_HANG', GHI_CHU_TU_CHOI = N'{0}' ,TEN_TRANG_THAI = N'Từ chối lịch giao',UPDATE_USER = '{2}',UPDATE_USER_NAME = '{2}',UPDATE_DATE = '{3}',UPDATE_TIME ='{4}'
                                                        WHERE   MA_PO IN ( '{1}' );", request.Note, id, Authorization.Username, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd HH:mm")));
                guiMailThongBaoDonHangBiKhoTuChoi(connection, lstId);
            }
            return response;
        }

        [HttpPost]
        public BaseUpdateResponse DeletePO(IDbConnection connection, ListKeysRequest request)
        {
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);
            //var connection = SqlConnections.NewByKey("Default");

            var sumQuantity = connection.Query<String>(string.Format(@"SELECT  MA_PO
                                                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                                WHERE   mt.MA_PO IN ( '{0}' )
                                                                        AND mt.TRANG_THAI IN ( 'DA_NHAN_HANG' );", id));
            if (sumQuantity != null)
                foreach (var sum in ((List<string>)sumQuantity))
                {
                    response.ErrorList.Add((sum));
                }


            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"DELETE  dbo.CSS_VCM_DANH_SACH_PO
                                                                        WHERE   MA_PO IN ( '{0}' );

                                                                        DELETE  dbo.CSS_VCM_DANH_SACH_PO_DET
                                                                        WHERE   MA_PO IN ( '{0}' );", id));
            }
            //response.Updated++;
            return response;
        }

        [HttpPost]
        public BaseUpdateResponse KhoHuyLichDonHang(IDbConnection connection, POUpdateDeliveryDateRequest request)
        {
            var response = new BaseUpdateResponse { ErrorList = new List<string>() };
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);
            //var connection = SqlConnections.NewByKey("Default");

            var sumQuantity = connection.Query<String>(string.Format(@"SELECT  MA_PO
                                                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                                WHERE   mt.MA_PO IN ( '{0}' )
                                                                        AND mt.TRANG_THAI NOT IN (  'DA_CHAP_NHAN' );", id));
            if (sumQuantity != null)
                foreach (var sum in ((List<string>)sumQuantity))
                {
                    response.ErrorList.Add((sum));
                }


            if (response.ErrorList.IsEmptyOrNull())
            {
                var success = connection.Query<int>(string.Format(@"UPDATE  CSS_VCM_DANH_SACH_PO
                                                                    SET     TRANG_THAI = 'DA_XAC_NHAN' ,
                                                                            TEN_TRANG_THAI = N'Chuyển NCC' ,NGAY_GIAO = NULL,GIO_GIAO = NULL,
                                                                            GHI_CHU_TU_CHOI = N'{1}'
                                                                    WHERE   MA_PO IN ( '{0}' );", id, request.Note));
            }
            //response.Updated++;
            return response;
        }

        public bool checkQuaSoLuongKhoYeuCau(IDbConnection connection, decimal soLuong, string maPO, string article)
        {

            //var connection = SqlConnections.NewByKey("Default");
            string sqlSoLuongKhoYeuCau = string.Format(@"SELECT isnull( det.SO_LUONG_UPLOAD,0)
                                FROM    dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK )                                       
                                WHERE   MA_PO = '{0}' AND Article = '{1}'", maPO, article);
            var soLuongKhoYeuCau = connection.Query<decimal>(sqlSoLuongKhoYeuCau);
            var _soLuongKhoYeuCau = ((List<decimal>)soLuongKhoYeuCau).Count > 0 ? ((List<decimal>)soLuongKhoYeuCau)[0] : 0;
            if (soLuong > _soLuongKhoYeuCau)
            {
                return true;
            }

            return false;
        }

        public List<string> getlstMaPOTheoTrangThai(IDbConnection connection, string maPO, string trangThai)
        {
            //mã po dạng '4900051113','4900051114'
            //var connection = SqlConnections.NewByKey("Default");
            string sqlgetMaPOTheoTrangThai = string.Format(@"SELECT MA_PO
                                FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )                                       
                                WHERE   MA_PO IN ( {0} ) AND TRANG_THAI IN ({1})", maPO, trangThai);
            var lstMaPOTheoTrangThai = connection.Query<string>(sqlgetMaPOTheoTrangThai);
            var _lstMaPOTheoTrangThai = ((List<string>)lstMaPOTheoTrangThai).Count > 0 ? (List<string>)lstMaPOTheoTrangThai : new List<string>();

            return _lstMaPOTheoTrangThai;
        }

        public DateTime getGioNhanThucTeDefine(string maPO, DateTime time)
        {
            var connection = SqlConnections.NewByKey("Default");
            string sqlNgayHenGiao = string.Format(@"SELECT  NGAY_GIAO as NgayGiao
                                                    FROM    dbo.CSS_VCM_DANH_SACH_PO WITH ( NOLOCK )       
                                                    WHERE   MA_PO = '{0}' ", maPO);
            var ngayHenGiao = connection.Query<DateTime>(sqlNgayHenGiao);
            if (ngayHenGiao.ToList().IsEmptyOrNull())
            {
                return DateTime.MinValue;
            }
            DateTime gioNhanThucTeDefine = DateTime.MinValue;
            foreach (var date in ngayHenGiao)
            {
                gioNhanThucTeDefine = date.AddHours(time.Hour).AddMinutes(time.Minute);
                break;
            }
            return gioNhanThucTeDefine;
        }
        // lấy mẫu upload excel

        public FilePathResult getExcelFromMapPath(string mapPath)
        {
            var dir = new DirectoryInfo(Server.MapPath(mapPath));
            FileInfo[] fileNames = dir.GetFiles("*.*");
            if (fileNames.IsEmptyOrNull()) return null;
            fileNames.OrderByDescending(f => f.CreationTime);
            var fileVirtualPath = dir + fileNames[0].Name;
            return File(fileVirtualPath, "application/force-download", Path.GetFileName(fileVirtualPath));
        }

        public FilePathResult ListExcel(IDbConnection connection, ListRequest request)
        {
            return getExcelFromMapPath("~/App_Data/upload/uploadPO/");
        }

        public FilePathResult ListMauExcelNCCHenLichGiao(IDbConnection connection, ListRequest request)
        {
            return getExcelFromMapPath("~/App_Data/upload/NCCHenLichGiao/");
        }

        public FilePathResult ListMauExcelThongTinKhoXacNhan(IDbConnection connection, ListRequest request)
        {
            return getExcelFromMapPath("~/App_Data/upload/ThongTinKhoDaXacNhan/");

        }

        public List<string> getListStringColumnsThuTuXapXep()
        {
            return new List<string>() {
                                        "MaPo",
                                        "NvLaiXe",
                                        "SdtNvLaiXe",
                                        "BienSoXe",
                                        "Article",
                                        "ShortText",
                                        "OrderQuantity",
                                        "OrderUnit",
                                        "Ctns",
                                        "Weight",
                                        "Cbm",
                                        "NgaySanXuat",
                                        "NgayHetHan",
    };
        }

        public FileContentResult ListXuatFileExcelNCCHenLichGiao(IDbConnection connection, ListKeysExRequest request)

        {
            request.CheckNotNull();
            var lstId = request.Keys.ToList();
            string id = string.Join("','", lstId);

            string sqlData = string.Format(@"SELECT  mt.MA_PO AS MaPo ,
                                                    mt.NV_LAI_XE AS NvLaiXe ,
                                                    mt.SDT_NV_LAI_XE AS SdtNvLaiXe ,
                                                    mt.BIEN_SO_XE AS BienSoXe ,
                                                    det.Article AS Article ,
                                                    det.ShortText AS ShortText ,
                                                    det.OrderQuantity AS OrderQuantity ,
                                                    det.OrderUnit AS OrderUnit ,
                                                    det.OrderUnit AS Ctns ,
                                                    det.Weight AS Weight ,
                                                    det.CBM AS Cbm ,
                                                    det.NGAY_SAN_XUAT AS NgaySanXuat ,
                                                    det.NGAY_HET_HAN AS NgayHetHan
                                            FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
                                                    INNER JOIN dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK ) ON mt.MA_PO = det.MA_PO
                                            WHERE   mt.MA_PO IN ( '{0}' )", id);

            var data = connection.Query<DetailRow>(sqlData);
            var report = new DynamicDataReport(data, getListStringColumnsThuTuXapXep(), typeof(Columns.CssVcmNCCHenGiaoXuatExcelColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "NCCHenGiao_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }

        public void SendEmailTuDong(string dsTo, string Subject, string Body)
        {

            try
            {
                //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var response = new BaseUpdateResponse { ErrorList = new List<string>() };
                string[] lstTo = dsTo.Split(';');
                foreach (var to in lstTo)
                {
                    if (string.IsNullOrWhiteSpace(to)) continue;

                    var message = new System.Net.Mail.MailMessage();
                    message.To.Add(new System.Net.Mail.MailAddress(to.Trim()));  // replace with valid value 
                    message.From = new System.Net.Mail.MailAddress("auto@sagawa.vn");  // replace with valid value
#pragma warning disable CS0618 // Type or member is obsolete
                    message.ReplyTo = new System.Net.Mail.MailAddress("quyenttk@sagawa.vn");
#pragma warning restore CS0618 // Type or member is obsolete
                    message.Subject = Subject;
                    message.Body = string.Format(Body);
                    message.IsBodyHtml = true;
                    using (var smtp = GetSmtpClient("sagawa"))
                    {
                        var credential = new System.Net.NetworkCredential
                        {
                            UserName = "auto@sagawa.vn",
                            Password = "mottudong"
                        };

                        smtp.Credentials = credential;
                        smtp.Send(message);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static System.Net.Mail.SmtpClient GetSmtpClient(string mailType)
        {
            System.Net.Mail.SmtpClient SmtpMail = new System.Net.Mail.SmtpClient();
            if (mailType == "sagawa")
            {
                SmtpMail.Host = "mail.sagawa.vn";
                SmtpMail.Port = 587;
                SmtpMail.EnableSsl = false;
            }
            else
            {
                throw new Exception("Khong Support loai Email nay");
            }

            SmtpMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SmtpMail.UseDefaultCredentials = false;
            return SmtpMail;
        }

        public void guiMailThongBaoDonHangDuocKhoChapNhan(IDbConnection connection, List<string> lstMaDonHang)
        {

            //var connection = SqlConnections.NewByKey("Default");
            var lstPo = getThongTinDonHangTheoMaPO(connection, lstMaDonHang);

            Dictionary<string, string> dicVendor = lstPo.Select(x => new { x.Vendor, x.VendorSupplyingSite }).Distinct().ToDictionary(x => x.Vendor, x => x.VendorSupplyingSite);
            var lstVendor = lstPo.Select(x => x.Vendor).Distinct().ToList();

            Dictionary<string, string> dicEmail = getDicEmailTheoMaNCC(connection, lstVendor);

            Dictionary<string, string> dicMailSubject = new Dictionary<string, string>();
            foreach (var vendor in lstVendor)
            {
                var lstInfoPoOfVendor = lstPo.Where(x => x.Vendor == vendor).Select(x => x.MaPo + " giờ giao: " + x.GioGiao.Value.ToString("dd/MM/yyyy HH:mm")).ToList();
                string thongBaoChoVendor = "Kính gửi " + dicVendor[vendor] + "<br>Chúng tôi xin thông báo thông tin đơn hàng được chấp nhận:" + "<br>" + string.Join("<br>", lstInfoPoOfVendor);
                dicMailSubject.Add(vendor, thongBaoChoVendor);
            }
            List<string> lstVendorKhongGuiDuocMail = new List<string>();
            foreach (var vendor in lstVendor)
            {
                if (dicEmail.ContainsKey(vendor))
                {
                    string to = dicEmail[vendor];
                    string subject = "Thông báo giao hàng";
                    string body = dicMailSubject[vendor];
                    if (!string.IsNullOrWhiteSpace(to))
                        SendEmailTuDong(to, subject, body);
                    else if (!lstVendorKhongGuiDuocMail.Contains(vendor)) lstVendorKhongGuiDuocMail.Add(vendor);
                }
                else
                {
                    if (!lstVendorKhongGuiDuocMail.Contains(vendor)) lstVendorKhongGuiDuocMail.Add(vendor);
                }
            }
            if (lstVendorKhongGuiDuocMail.Count > 0)
                throw new Exception("Danh sách NCC không gửi được mail do không tìm thấy địa chỉ mail" + Environment.NewLine + string.Join(Environment.NewLine, lstVendorKhongGuiDuocMail));

        }

        public void guiMailThongBaoDonHangBiKhoTuChoi(IDbConnection connection, List<string> lstMaDonHang)
        {
            //var connection = SqlConnections.NewByKey("Default");
            var lstPo = getThongTinDonHangTheoMaPO(connection, lstMaDonHang);

            Dictionary<string, string> dicVendor = lstPo.Select(x => new { x.Vendor, x.VendorSupplyingSite }).Distinct().ToDictionary(x => x.Vendor, x => x.VendorSupplyingSite);
            var lstVendor = lstPo.Select(x => x.Vendor).Distinct().ToList();

            Dictionary<string, string> dicEmail = getDicEmailTheoMaNCC(connection, lstVendor);

            Dictionary<string, string> dicMailSubject = new Dictionary<string, string>();
            foreach (var vendor in lstVendor)
            {
                var lstInfoPoOfVendor = lstPo.Where(x => x.Vendor == vendor).Select(x => x.MaPo + " giờ giao: " + x.GioGiao + " Lý do từ chối: " + x.GhiChuTuChoi).ToList();
                string thongBaoChoVendor = "Kính gửi " + dicVendor[vendor] + "<br>Chúng tôi xin thông báo thông tin đơn hàng chưa được chấp nhận:" + "<br>" + string.Join("<br>", lstInfoPoOfVendor) + "<br>Vui lòng kiểm tra lại thông tin trên web và đặt lại lịch giao hàng đến kho.";
                dicMailSubject.Add(vendor, thongBaoChoVendor);
            }
            List<string> lstVendorKhongGuiDuocMail = new List<string>();
            foreach (var vendor in lstVendor)
            {
                if (dicEmail.ContainsKey(vendor))
                {
                    string to = dicEmail[vendor];
                    string subject = "Thông báo Từ chối lịch giao";
                    string body = dicMailSubject[vendor];
                    if (!string.IsNullOrWhiteSpace(to))
                        SendEmailTuDong(to, subject, body);
                    else if (!lstVendorKhongGuiDuocMail.Contains(vendor)) lstVendorKhongGuiDuocMail.Add(vendor);
                }
                else
                {
                    if (!lstVendorKhongGuiDuocMail.Contains(vendor)) lstVendorKhongGuiDuocMail.Add(vendor);
                }
            }
            if (lstVendorKhongGuiDuocMail.Count > 0)
                throw new Exception("Danh sách NCC không gửi được mail do không tìm thấy địa chỉ mail" + Environment.NewLine + string.Join(Environment.NewLine, lstVendorKhongGuiDuocMail));

        }

        public IEnumerable<MyRow> getThongTinDonHangTheoMaPO(IDbConnection connection, List<string> maDonHang)
        {
            string sqlData = string.Format(@"SELECT  mt.MA_PO AS MaPo ,
        NGAY_GIAO AS NgayGiao ,
        mt.Vendor ,
        mt.Vendor_SupplyingSite AS VendorSupplyingSite ,
        mt.GHI_CHU GhiChu ,
        mt.TRANG_THAI AS TrangThai ,
        mt.GIO_GIAO AS GioGiao ,
        mt.GHI_CHU_HEN_GIAO AS GhiChuHenGiao ,
        mt.GHI_CHU_TU_CHOI AS GhiChuTuChoi ,
        mt.TEN_TRANG_THAI AS TenTrangThai ,
        mt.NV_LAI_XE AS NvLaiXe ,
        mt.SDT_NV_LAI_XE AS SdtNvLaiXe ,
        mt.BIEN_SO_XE AS BienSoXe ,
        mt.NGAY_NHAN_THUC_TE AS NgayNhanThucTe ,
        mt.GIO_NHAN_THUC_TE AS GioNhanThucTe ,
        ( SELECT    SUM(det.OrderQuantity)
          FROM      dbo.CSS_VCM_DANH_SACH_PO_DET det WITH ( NOLOCK )
          WHERE     det.MA_PO = mt.MA_PO
        ) AS Quantity
FROM    dbo.CSS_VCM_DANH_SACH_PO mt WITH ( NOLOCK )
WHERE   mt.MA_PO IN ('{0}')", string.Join("','", maDonHang));
            //var connection = SqlConnections.NewByKey("Default");
            return connection.Query<MyRow>(sqlData);
        }

        public Dictionary<string, string> getDicEmailTheoMaNCC(IDbConnection connection, List<string> lstVendor)
        {
            string vendors = "NCC" + string.Join("','NCC", lstVendor);
            string sqlEmail = string.Format(@"SELECT  Username AS Vendor,
                                                        Email AS GhiChu
                                                FROM    dbo.Users WITH ( NOLOCK )
                                                WHERE   Username IN ( '{0}' )", vendors);
            //var connection = SqlConnections.NewByKey("Default");
            var lstEmail = connection.Query<MyRow>(sqlEmail);
            Dictionary<string, string> dicEmail = lstEmail.ToDictionary(x => x.Vendor.Replace("NCC", ""), x => x.GhiChu);

            //dùng để test
            //foreach (var vendor in lstVendor)
            //{
            //    dicEmail.Add(vendor,"quydn@sagawa.vn");
            //}
            return dicEmail;
        }
    }
}
