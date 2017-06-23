

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

    [ConnectionKey("Default"), DisplayName(""), InstanceName(""), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class CssVcmBaoCaoDatHangKheThoiGianRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity, Visible(false)]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Ngày giao"), Column("NGAY_GIAO"), Width(100)]
        public string NgayGiao
        {
            get { return Fields.NgayGiao[this]; }
            set { Fields.NgayGiao[this] = value; }
        }

        [DisplayName("Gio giao"), Column("GIO_GIAO"), Visible(false)]
        public DateTime? GioGiao
        {
            get { return Fields.GioGiao[this]; }
            set { Fields.GioGiao[this] = value; }
        }

        [DisplayName("Khe Thời Gian"), Column("KHE_THOI_GIAN"), Width(150), QuickSearch]
        public String KheThoiGian
        {
            get { return Fields.KheThoiGian[this]; }
            set { Fields.KheThoiGian[this] = value; }
        }

        [DisplayName("Số Lượng"), Column("SO_LUONG"), Width(150),DisplayFormat("#,##0.####")]
        public Int32? SoLuong
        {
            get { return Fields.SoLuong[this]; }
            set { Fields.SoLuong[this] = value; }
        }

        [DisplayName("Số lượng tối đa"), Column("SO_LUONG_TOI_DA"), Width(150),DisplayFormat("#,##0.####")]
        public Int32? SoLuongToiDa
        {
            get { return Fields.SoLuongToiDa[this]; }
            set { Fields.SoLuongToiDa[this] = value; }
        }

        [DisplayName("Chênh lệch"), Column("CHENH_LECH"), Width(150), DisplayFormat("#,##0.####")]
        public Int32? ChenhLech
        {
            get { return Fields.ChenhLech[this]; }
            set { Fields.ChenhLech[this] = value; }
        }

        [DisplayName(""), Column("FROM_TIME"), Visible(false)]
        public DateTime? FromTime
        {
            get { return Fields.FromTime[this]; }
            set { Fields.FromTime[this] = value; }
        }

        [DisplayName(""), Column("TO_TIME"), Visible(false)]
        public DateTime? ToTime
        {
            get { return Fields.ToTime[this]; }
            set { Fields.ToTime[this] = value; }
        }

        [DisplayName(""), Column("DAY_OF_WEEK"), Width(150), QuickSearch]
        public String DayOfWeek
        {
            get { return Fields.DayOfWeek[this]; }
            set { Fields.DayOfWeek[this] = value; }
        }
        [DisplayName(""), Column("EQUAL_FROM_TIME") ]
        public Boolean? EqualFromTime
        {
            get { return Fields.EqualFromTime[this]; }
            set { Fields.EqualFromTime[this] = value; }
        }
        [DisplayName(""), Column("EQUAL_TO_TIME")]
        public Boolean? EqualToTime
        {
            get { return Fields.EqualToTime[this]; }
            set { Fields.EqualToTime[this] = value; }
        }
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.KheThoiGian; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CssVcmBaoCaoDatHangKheThoiGianRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField NgayGiao;
            public DateTimeField GioGiao;
            public StringField KheThoiGian;
            public Int32Field SoLuong;
            public Int32Field SoLuongToiDa;
            public Int32Field ChenhLech;
            public DateTimeField FromTime;
            public DateTimeField ToTime;
            public StringField DayOfWeek;
            public BooleanField EqualFromTime;
            public BooleanField EqualToTime;
            public RowFields()
                : base("[dbo].[CSS_VCM_BAO_CAO_DAT_HANG_KHE_THOI_GIAN]")
            {
                LocalTextPrefix = "BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian";
            }
        }
    }
}