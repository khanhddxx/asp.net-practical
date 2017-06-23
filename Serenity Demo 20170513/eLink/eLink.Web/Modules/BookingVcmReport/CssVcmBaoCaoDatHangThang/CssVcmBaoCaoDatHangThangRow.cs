

namespace eLink.BookingVcmReport.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName(""), InstanceName("CSS_VCM_BAO_CAO_DAT_HANG_THANG"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class CssVcmBaoCaoDatHangThangRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity, Visible(false)]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Đơn hàng (PO)"), Column("MA_PO"), Size(50)]
        public String MaPo
        {
            get { return Fields.MaPo[this]; }
            set { Fields.MaPo[this] = value; }
        }

        [DisplayName("Ngày đặt hàng"), Column("NGAY_DAT_HANG"), Width(150)]
        public DateTime? NgayDatHang
        {
            get { return Fields.NgayDatHang[this]; }
            set { Fields.NgayDatHang[this] = value; }
        }

        [DisplayName("Ngày thực nhận"), Column("NGAY_THUC_NHAN"), Width(150)]
        public DateTime? NgayThucNhan
        {
            get { return Fields.NgayThucNhan[this]; }
            set { Fields.NgayThucNhan[this] = value; }
        }

        [DisplayName("Tổng kế hoạch SKU"), Column("SKU_KE_HOACH"), Width(150), Scale(3)]
        public Decimal? SkuKeHoach
        {
            get { return Fields.SkuKeHoach[this]; }
            set { Fields.SkuKeHoach[this] = value; }
        }

        [DisplayName("Tổng kế hoạch Unit"), Column("UNIT_KE_HOACH"), Width(150), Scale(3)]
        public Decimal? UnitKeHoach
        {
            get { return Fields.UnitKeHoach[this]; }
            set { Fields.UnitKeHoach[this] = value; }
        }

        [DisplayName("Tổng thực nhận SKU"), Column("SKU_THUC_NHAN"), Width(150), Scale(3)]
        public Decimal? SkuThucNhan
        {
            get { return Fields.SkuThucNhan[this]; }
            set { Fields.SkuThucNhan[this] = value; }
        }

        [DisplayName("Tổng thực nhận Unit"), Column("UNIT_THUC_NHAN"), Width(150), Scale(3)]
        public Decimal? UnitThucNhan
        {
            get { return Fields.UnitThucNhan[this]; }
            set { Fields.UnitThucNhan[this] = value; }
        }

        [DisplayName("Chênh lệch SKU"), Column("SKU_CHENH_LECH"), Width(150), Scale(3)]
        public Decimal? SkuChenhLech
        {
            get { return Fields.SkuChenhLech[this]; }
            set { Fields.SkuChenhLech[this] = value; }
        }

        [DisplayName("Chênh lệch Unit"), Column("UNIT_CHENH_LECH"), Width(150), Scale(3)]
        public Decimal? UnitChenhLech
        {
            get { return Fields.UnitChenhLech[this]; }
            set { Fields.UnitChenhLech[this] = value; }
        }

        [DisplayName("Tỉ lệ SKU"), Column("SKU_TI_LE"), Size(18), Scale(3)]
        public Decimal? SkuTiLe
        {
            get { return Fields.SkuTiLe[this]; }
            set { Fields.SkuTiLe[this] = value; }
        }

        [DisplayName("Tỉ lệ Unit"), Column("UNIT_TI_LE"), Size(18), Scale(3)]
        public Decimal? UnitTiLe
        {
            get { return Fields.UnitTiLe[this]; }
            set { Fields.UnitTiLe[this] = value; }
        }

        [DisplayName("Grade in Full"), Column("DELIVERY_IN_FULL_GRADE"), Size(3), Width(50)]
        public String DeliveryInFullGrade
        {
            get { return Fields.DeliveryInFullGrade[this]; }
            set { Fields.DeliveryInFullGrade[this] = value; }
        }

        [DisplayName("Thời gian giao hàng theo Booking"), Column("GIO_GIAO"), DisplayFormat("HH:mm:ss"), Width(220)]
        public DateTime? GioGiao
        {
            get { return Fields.GioGiao[this]; }
            set { Fields.GioGiao[this] = value; }
        }

        [DisplayName("Thời gian nhận chứng từ"), Column("GIO_NHAN_THUC_TE"), DisplayFormat("HH:mm:ss"), Width(200)]
        public DateTime? GioNhanThucTe
        {
            get { return Fields.GioNhanThucTe[this]; }
            set { Fields.GioNhanThucTe[this] = value; }
        }

        [DisplayName("Thời giao trễ/giao sớm theo Booking"), Column("THOI_GIAN_TRE"), Width(250)]
        public TimeSpan? ThoiGianTre
        {
            get { return Fields.ThoiGianTre[this]; }
            set { Fields.ThoiGianTre[this] = value; }
        }

        [DisplayName("Ghi Chú"), Column("GHI_CHU_HEN_GIAO"), Width(300)]
        public String GhiChuHenGiao
        {
            get { return Fields.GhiChuHenGiao[this]; }
            set { Fields.GhiChuHenGiao[this] = value; }
        }

        [DisplayName("Grade in Time"), Column("DELIVERY_IN_TIME_GRADE"), Size(3), Width(50)]
        public String DeliveryInTimeGrade
        {
            get { return Fields.DeliveryInTimeGrade[this]; }
            set { Fields.DeliveryInTimeGrade[this] = value; }
        }
        [DisplayName("Mã NCC"), Column("Vendor"), Width(100)]
        public String Vendor
        {
            get { return Fields.Vendor[this]; }
            set { Fields.Vendor[this] = value; }
        }
        [DisplayName("Tên NCC"), Column("Vendor_SupplyingSite"), Width(200)]
        public String Vendor_SupplyingSite
        {
            get { return Fields.Vendor_SupplyingSite[this]; }
            set { Fields.Vendor_SupplyingSite[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MaPo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CssVcmBaoCaoDatHangThangRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField MaPo;
            public DateTimeField NgayDatHang;
            public DateTimeField NgayThucNhan;
            public DecimalField SkuKeHoach;
            public DecimalField UnitKeHoach;
            public DecimalField SkuThucNhan;
            public DecimalField UnitThucNhan;
            public DecimalField SkuChenhLech;
            public DecimalField UnitChenhLech;
            public DecimalField SkuTiLe;
            public DecimalField UnitTiLe;
            public StringField DeliveryInFullGrade;
            public DateTimeField GioGiao;
            public DateTimeField GioNhanThucTe;
            public TimeSpanField ThoiGianTre;
            public StringField GhiChuHenGiao;
            public StringField DeliveryInTimeGrade;
            public StringField Vendor;
            public StringField Vendor_SupplyingSite;

            public RowFields()
                : base("[dbo].[CSS_VCM_BAO_CAO_DAT_HANG_THANG]")
            {
                LocalTextPrefix = "BookingVcmReport.CssVcmBaoCaoDatHangThang";
            }
        }
    }
}