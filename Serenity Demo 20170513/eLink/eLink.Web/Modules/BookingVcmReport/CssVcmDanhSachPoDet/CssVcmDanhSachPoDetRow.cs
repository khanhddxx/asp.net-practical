namespace eLink.BookingVcmReport.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Default"), DisplayName(""), InstanceName("Chi tiết PO"), TwoLevelCached]
    //[ReadPermission("Administration")]
    //[ModifyPermission("Administration")]
    public sealed class CssVcmDanhSachPoDetRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Mã PO"), Column("MA_PO"), Width(100), NotNull, QuickSearch, ForeignKey("[dbo].[CSS_VCM_DANH_SACH_PO]", "MA_PO"), LeftJoin("c")]
        public String MaPo
        {
            get { return Fields.MaPo[this]; }
            set { Fields.MaPo[this] = value; }
        }

        [DisplayName("Ngày đặt hàng"), Width(100), DisplayFormat("dd/MM/yyyy")]
        public DateTime? DocumentDate
        {
            get { return Fields.DocumentDate[this]; }
            set { Fields.DocumentDate[this] = value; }
        }

        [DisplayName("Mã NCC"), Width(100)]
        public String Vendor
        {
            get { return Fields.Vendor[this]; }
            set { Fields.Vendor[this] = value; }
        }

        [DisplayName("Tên NCC"), Column("Vendor_SupplyingSite"), Width(300)]
        public String VendorSupplyingSite
        {
            get { return Fields.VendorSupplyingSite[this]; }
            set { Fields.VendorSupplyingSite[this] = value; }
        }

        [DisplayName("Số TT")]
        public Int32? Item
        {
            get { return Fields.Item[this]; }
            set { Fields.Item[this] = value; }
        }

        [DisplayName("Mã hàng"), Width(100)]
        public String Article
        {
            get { return Fields.Article[this]; }
            set { Fields.Article[this] = value; }
        }

        [DisplayName("Đơn vị tính"), Width(100)]
        public String OrderUnit
        {
            get { return Fields.OrderUnit[this]; }
            set { Fields.OrderUnit[this] = value; }
        }

        [DisplayName("Mã Barcode"), Width(100)]
        public String GTIN
        {
            get { return Fields.GTIN[this]; }
            set { Fields.GTIN[this] = value; }
        }

        [DisplayName("Tên hàng"), Width(100)]
        public String ShortText
        {
            get { return Fields.ShortText[this]; }
            set { Fields.ShortText[this] = value; }
        }


        [DisplayName("Ngành hàng"), Width(100)]
        public string MerchandiseCategory
        {
            get { return Fields.MerchandiseCategory[this]; }
            set { Fields.MerchandiseCategory[this] = value; }
        }

        [DisplayName("Số lượng kho yêu cầu"), Column("SO_LUONG_UPLOAD"), Width(150)]
        public Decimal? SoLuongUpload
        {
            get { return Fields.SoLuongUpload[this]; }
            set { Fields.SoLuongUpload[this] = value; }
        }

        [DisplayName("Số lượng giao"), Width(100), Scale(3)]
        public Decimal? OrderQuantity
        {
            get { return Fields.OrderQuantity[this]; }
            set { Fields.OrderQuantity[this] = value; }
        }

    

        [DisplayName("Số thùng"), Width(100)]
        public String Ctns
        {
            get { return Fields.Ctns[this]; }
            set { Fields.Ctns[this] = value; }
        }

        [DisplayName("Khối lượng"), Width(100), Scale(3)]
        public Decimal? Weight
        {
            get { return Fields.Weight[this]; }
            set { Fields.Weight[this] = value; }
        }

        [DisplayName("Gói"), Column("CBM"), Width(50)]
        public String Cbm
        {
            get { return Fields.Cbm[this]; }
            set { Fields.Cbm[this] = value; }
        }

        [DisplayName("Người Upload"), Width(100)]
        public String NameOfUploader
        {
            get { return Fields.NameOfUploader[this]; }
            set { Fields.NameOfUploader[this] = value; }
        }

        [DisplayName("Số ĐT"), Width(100)]
        public String TelofUploader
        {
            get { return Fields.TelofUploader[this]; }
            set { Fields.TelofUploader[this] = value; }
        }

   


        [DisplayName("Ghi chú"), Width(100)]
        public String Note
        {
            get { return Fields.Note[this]; }
            set { Fields.Note[this] = value; }
        }

        [DisplayName("Insert Date"), Column("INSERT_DATE")]
        public DateTime? InsertDate
        {
            get { return Fields.InsertDate[this]; }
            set { Fields.InsertDate[this] = value; }
        }

        [DisplayName("Insert Time"), Column("INSERT_TIME")]
        public DateTime? InsertTime
        {
            get { return Fields.InsertTime[this]; }
            set { Fields.InsertTime[this] = value; }
        }

        [DisplayName("Insert User"), Column("INSERT_USER"), Width(100)]
        public String InsertUser
        {
            get { return Fields.InsertUser[this]; }
            set { Fields.InsertUser[this] = value; }
        }

        [DisplayName("Update Date"), Column("UPDATE_DATE")]
        public DateTime? UpdateDate
        {
            get { return Fields.UpdateDate[this]; }
            set { Fields.UpdateDate[this] = value; }
        }

        [DisplayName("Update Time"), Column("UPDATE_TIME")]
        public DateTime? UpdateTime
        {
            get { return Fields.UpdateTime[this]; }
            set { Fields.UpdateTime[this] = value; }
        }

        [DisplayName("Update User"), Column("UPDATE_USER"), Width(100)]
        public String UpdateUser
        {
            get { return Fields.UpdateUser[this]; }
            set { Fields.UpdateUser[this] = value; }
        }
        [DisplayName("NV lái xe"), Expression("c.[NV_LAI_XE]")]
        public String NvLaiXe
        {
            get { return Fields.NvLaiXe[this]; }
            set { Fields.NvLaiXe[this] = value; }
        }
        [DisplayName("Sđt NV lái xe"), Expression("c.[SDT_NV_LAI_XE]")]
        public String SdtNvLaiXe
        {
            get { return Fields.SdtNvLaiXe[this]; }
            set { Fields.SdtNvLaiXe[this] = value; }
        }
        [DisplayName("Biển số xe"), Expression("c.[BIEN_SO_XE]")]
        public String BienSoXe
        {
            get { return Fields.BienSoXe[this]; }
            set { Fields.BienSoXe[this] = value; }
        }
  
        [DisplayName("Ngày sản xuất"), Column("NGAY_SAN_XUAT"), Width(100), DisplayFormat("dd/MM/yyyy")]
        public DateTime? NgaySanXuat
        {
            get { return Fields.NgaySanXuat[this]; }
            set { Fields.NgaySanXuat[this] = value; }
        }

        [DisplayName("Ngày hết hạn"), Column("NGAY_HET_HAN"), Width(100), DisplayFormat("dd/MM/yyyy")]
        public DateTime? NgayHetHan
        {
            get { return Fields.NgayHetHan[this]; }
            set { Fields.NgayHetHan[this] = value; }
        }
        [DisplayName("Số lượng NCC hẹn giao"), Column("SO_LUONG_NCC_HEN_GIAO"), Width(150)]
        public Decimal? SoLuongNccHenGiao
        {
            get { return Fields.SoLuongNccHenGiao[this]; }
            set { Fields.SoLuongNccHenGiao[this] = value; }
        }
        [DisplayName("Số lượng thực nhận"), Column("SO_LUONG_THUC_NHAN"), Width(150)]
        public Decimal? SoLuongThucNhan
        {
            get { return Fields.SoLuongThucNhan[this]; }
            set { Fields.SoLuongThucNhan[this] = value; }
        }
        [DisplayName("Ngày nhận thực tế"), Expression("c.[NGAY_NHAN_THUC_TE]")]
        public DateTime? NgayNhanThucTe
        {
            get { return Fields.NgayNhanThucTe[this]; }
            set { Fields.NgayNhanThucTe[this] = value; }
        }
        [DisplayName("Giờ nhận thực tế"), Expression("c.[GIO_NHAN_THUC_TE]")]
        public DateTime? GioNhanThucTe
        {
            get { return Fields.GioNhanThucTe[this]; }
            set { Fields.GioNhanThucTe[this] = value; }
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

        public CssVcmDanhSachPoDetRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField MaPo;
            public DateTimeField DocumentDate;
            public StringField Vendor;
            public StringField VendorSupplyingSite;
            public Int32Field Item;
            public StringField Article;
            public StringField ShortText;
            public DecimalField OrderQuantity;
            public StringField OrderUnit;
            public StringField Ctns;
            public DecimalField Weight;
            public StringField Cbm;
            public StringField NameOfUploader;
            public StringField TelofUploader;
            public StringField Note;
            public DateTimeField InsertDate;
            public DateTimeField InsertTime;
            public StringField InsertUser;
            public DateTimeField UpdateDate;
            public DateTimeField UpdateTime;
            public StringField UpdateUser;
            public StringField NvLaiXe;
            public StringField SdtNvLaiXe;
            public StringField BienSoXe;
            public DecimalField SoLuongUpload;
            public DateTimeField NgaySanXuat;
            public DateTimeField NgayHetHan;
            public DecimalField SoLuongNccHenGiao;
            public DecimalField SoLuongThucNhan;
            public DateTimeField NgayNhanThucTe;
            public DateTimeField GioNhanThucTe;

            public StringField GTIN;
            public StringField MerchandiseCategory;
            public RowFields()
                : base("[dbo].[CSS_VCM_DANH_SACH_PO_DET]")
            {
                LocalTextPrefix = "BookingVcmReport.CssVcmDanhSachPoDet";
            }
        }
    }
}