
namespace eLink.QuanLyHocSinh.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("QuanLyHocSinh.QuanLyHocSinh")]
    [BasedOnRow(typeof(Entities.QuanLyHocSinhRow))]
    public class QuanLyHocSinhColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String MaHs { get; set; }
        public String TenHs { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime InsertTime { get; set; }
        public String InsertUser { get; set; }
    }
}