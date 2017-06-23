
namespace eLink.QuanLyHocSinh.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("QuanLyHocSinh.QuanLyHocSinh")]
    [BasedOnRow(typeof(Entities.QuanLyHocSinhRow))]
    public class QuanLyHocSinhForm
    {
        public String MaHs { get; set; }
        public String TenHs { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime InsertTime { get; set; }
        public String InsertUser { get; set; }
    }
}