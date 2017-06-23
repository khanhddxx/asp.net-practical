

namespace eLink.QuanLyHocSinh.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("QUAN_LY_HOC_SINH"), InstanceName("QUAN_LY_HOC_SINH"), TwoLevelCached]
    [ReadPermission("Adminstration")]
    [ModifyPermission("Adminstration")]
    public sealed class QuanLyHocSinhRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Ma Hs"), Column("MA_HS"), Size(50), QuickSearch]
        public String MaHs
        {
            get { return Fields.MaHs[this]; }
            set { Fields.MaHs[this] = value; }
        }

        [DisplayName("Ten Hs"), Column("TEN_HS"), Size(250)]
        public String TenHs
        {
            get { return Fields.TenHs[this]; }
            set { Fields.TenHs[this] = value; }
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

        [DisplayName("Insert User"), Column("INSERT_USER"), Size(20)]
        public String InsertUser
        {
            get { return Fields.InsertUser[this]; }
            set { Fields.InsertUser[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MaHs; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public QuanLyHocSinhRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField MaHs;
            public StringField TenHs;
            public DateTimeField InsertDate;
            public DateTimeField InsertTime;
            public StringField InsertUser;

            public RowFields()
                : base("[dbo].[QUAN_LY_HOC_SINH]")
            {
                LocalTextPrefix = "QuanLyHocSinh.QuanLyHocSinh";
            }
        }
    }
}