namespace eLink.BookingVcmReport.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName(""), InstanceName("CSS_VCM_DANH_SACH_PO"), TwoLevelCached]
    //[ReadPermission("Administration")]
    //[ModifyPermission("Administration")]
    public sealed class CssVcmDanhSachPoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity, Visible(false)]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Mã PO"), Column("MA_PO"), Size(50), NotNull, QuickSearch]
        public String MaPo
        {
            get { return Fields.MaPo[this]; }
            set { Fields.MaPo[this] = value; }
        }

        [DisplayName("Ngày giao"), Column("NGAY_GIAO")]
        public DateTime? NgayGiao
        {
            get { return Fields.NgayGiao[this]; }
            set { Fields.NgayGiao[this] = value; }
        }

        [DisplayName("Mã NCC"), Size(50)]
        public String Vendor
        {
            get { return Fields.Vendor[this]; }
            set { Fields.Vendor[this] = value; }
        }

        [DisplayName("Tên NCC"), Column("Vendor_SupplyingSite"), Size(500)]
        public String VendorSupplyingSite
        {
            get { return Fields.VendorSupplyingSite[this]; }
            set { Fields.VendorSupplyingSite[this] = value; }
        }

        [DisplayName("Ghi chú"), Column("GHI_CHU"), Size(250)]
        public String GhiChu
        {
            get { return Fields.GhiChu[this]; }
            set { Fields.GhiChu[this] = value; }
        }

        [DisplayName("Ngày tạo"), Column("INSERT_DATE"), DisplayFormat("dd/MM/yyyy")]
        public DateTime? InsertDate
        {
            get { return Fields.InsertDate[this]; }
            set { Fields.InsertDate[this] = value; }
        }

        [DisplayName("Thời gian tạo"), Column("INSERT_TIME"), DisplayFormat("dd/MM/yyyy HH:mm"), Size(200)]
        public DateTime? InsertTime
        {
            get { return Fields.InsertTime[this]; }
            set { Fields.InsertTime[this] = value; }
        }

        [DisplayName("NV tạo"), Column("INSERT_USER"), Width(100)]
        public String InsertUser
        {
            get { return Fields.InsertUser[this]; }
            set { Fields.InsertUser[this] = value; }
        }

        [DisplayName("Tên NV tạo"), Column("INSERT_USER_NAME"), Size(50)]
        public String InsertUserName
        {
            get { return Fields.InsertUserName[this]; }
            set { Fields.InsertUserName[this] = value; }
        }

        [DisplayName("Ngày cập nhật"), Column("UPDATE_DATE"), DisplayFormat("dd/MM/yyyy"), Size(200)]
        public DateTime? UpdateDate
        {
            get { return Fields.UpdateDate[this]; }
            set { Fields.UpdateDate[this] = value; }
        }

        [DisplayName("TG cập nhật"), Column("UPDATE_TIME"), DisplayFormat("dd/MM/yyyy HH:mm"), Width(150)]
        public DateTime? UpdateTime
        {
            get { return Fields.UpdateTime[this]; }
            set { Fields.UpdateTime[this] = value; }
        }

        [DisplayName("NV cập nhật"), Column("UPDATE_USER"), Size(20)]
        public String UpdateUser
        {
            get { return Fields.UpdateUser[this]; }
            set { Fields.UpdateUser[this] = value; }
        }

        [DisplayName("Tên NV cập nhật"), Column("UPDATE_USER_NAME"), Size(200)]
        public String UpdateUserName
        {
            get { return Fields.UpdateUserName[this]; }
            set { Fields.UpdateUserName[this] = value; }
        }

        [DisplayName("Trạng thái"), Column("TRANG_THAI"), Size(50)]
        public String TrangThai
        {
            get { return Fields.TrangThai[this]; }
            set { Fields.TrangThai[this] = value; }
        }

        [DisplayName("Giờ giao"), Column("GIO_GIAO"), DisplayFormat("HH:mm"), Size(20)]
        public DateTime? GioGiao
        {
            get { return Fields.GioGiao[this]; }
            set { Fields.GioGiao[this] = value; }
        }

        [DisplayName("Ghi chú hẹn giao"), Column("GHI_CHU_HEN_GIAO"), Size(500)]
        public String GhiChuHenGiao
        {
            get { return Fields.GhiChuHenGiao[this]; }
            set { Fields.GhiChuHenGiao[this] = value; }
        }

        [DisplayName("Ghi chú từ chối"), Column("GHI_CHU_TU_CHOI"), Size(500)]
        public String GhiChuTuChoi
        {
            get { return Fields.GhiChuTuChoi[this]; }
            set { Fields.GhiChuTuChoi[this] = value; }
        }

        [DisplayName("Tên trạng thái"), Column("TEN_TRANG_THAI"), Size(350)]
        public String TenTrangThai
        {
            get { return Fields.TenTrangThai[this]; }
            set { Fields.TenTrangThai[this] = value; }
        }
        [DisplayName("NV lái xe"), Column("NV_LAI_XE"), Size(100)]
        public String NvLaiXe
        {
            get { return Fields.NvLaiXe[this]; }
            set { Fields.NvLaiXe[this] = value; }
        }

        [DisplayName("Sđt NV lái xe"), Column("SDT_NV_LAI_XE"), Size(300)]
        public String SdtNvLaiXe
        {
            get { return Fields.SdtNvLaiXe[this]; }
            set { Fields.SdtNvLaiXe[this] = value; }
        }

        [DisplayName("Biển số xe"), Column("BIEN_SO_XE"), Size(350)]
        public String BienSoXe
        {
            get { return Fields.BienSoXe[this]; }
            set { Fields.BienSoXe[this] = value; }
        }

        [DisplayName("Số lượng")]
        public Decimal? Quantity
        {
            get { return Fields.Quantity[this]; }
            set { Fields.Quantity[this] = value; }
        }
        [DisplayName("Ngày nhận thực tế"), Column("NGAY_NHAN_THUC_TE"), DisplayFormat("dd/MM/yyyy"), Width(150)]
        public DateTime? NgayNhanThucTe
        {
            get { return Fields.NgayNhanThucTe[this]; }
            set { Fields.NgayNhanThucTe[this] = value; }
        }
        [DisplayName("Giờ nhận thực tế"), Column("GIO_NHAN_THUC_TE"), DisplayFormat("HH:mm"), Width(150)]
        public DateTime? GioNhanThucTe
        {
            get { return Fields.GioNhanThucTe[this]; }
            set { Fields.GioNhanThucTe[this] = value; }
        }
        [DisplayName("SL khung thời gian đã xác nhận"), Column("SL_KHUNG_TG_XAC_NHAN"), Width(250)]
        public Decimal? SLKhungThoiGianDaXacNhan
        {
            get { return Fields.SLKhungThoiGianDaXacNhan[this]; }
            set { Fields.SLKhungThoiGianDaXacNhan[this] = value; }
        }

        [DisplayName("Site"), Width(50)]
        public String Site
        {
            get { return Fields.Site[this]; }
            set { Fields.Site[this] = value; }
        }

        [DisplayName("Ngày giao hàng"), Width(100)]
        public DateTime? DeliveryDate
        {
            get { return Fields.DeliveryDate[this]; }
            set { Fields.DeliveryDate[this] = value; }
        }

        [DisplayName("Chiến lược phát hành"), Width(100)]
        public string ReleaseStrategy
        {
            get { return Fields.ReleaseStrategy[this]; }
            set { Fields.ReleaseStrategy[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MaPo; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MaPo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CssVcmDanhSachPoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField MaPo;
            public DateTimeField NgayGiao;
            public StringField Vendor;
            public StringField VendorSupplyingSite;
            public StringField GhiChu;
            public DateTimeField InsertDate;
            public DateTimeField InsertTime;
            public StringField InsertUser;
            public StringField InsertUserName;
            public DateTimeField UpdateDate;
            public DateTimeField UpdateTime;
            public StringField UpdateUser;
            public StringField UpdateUserName;
            public StringField TrangThai;
            public DateTimeField GioGiao;
            public StringField GhiChuHenGiao;
            public StringField GhiChuTuChoi;
            public StringField TenTrangThai;
            public StringField NvLaiXe;
            public StringField SdtNvLaiXe;
            public StringField BienSoXe;
            public DecimalField Quantity;
            public DateTimeField NgayNhanThucTe;
            public DateTimeField GioNhanThucTe;
            public DecimalField SLKhungThoiGianDaXacNhan;
            public StringField Site;
            public DateTimeField DeliveryDate;
            public StringField ReleaseStrategy;
            public RowFields()
                : base("[dbo].[CSS_VCM_DANH_SACH_PO]")
            {
                LocalTextPrefix = "BookingVcmReport.CssVcmDanhSachPo";
            }
        }
    }
}