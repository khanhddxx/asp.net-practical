
namespace eLink.BookingVcmReport.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("BookingVcmReport.CssVcmDanhSachPoDet")]
    [BasedOnRow(typeof(Entities.CssVcmDanhSachPoDetRow))]
    public class CssVcmDanhSachPoDetForm
    {
        //public String MaPo { get; set; }
        //public DateTime DocumentDate { get; set; }
        //public String Vendor { get; set; }
        //public String VendorSupplyingSite { get; set; }
        //public Int32 Item { get; set; }
        //public String Article { get; set; }
        //public String ShortText { get; set; }
        //public String Site { get; set; }
        public Decimal OrderQuantity { get; set; }
        //public String OrderUnit { get; set; }
        //public String Ctns { get; set; }
        //public Decimal Weight { get; set; }
        //public String Cbm { get; set; }
        //public String NameOfUploader { get; set; }
        //public String TelofUploader { get; set; }
        //public String Note { get; set; }
        //public DateTime InsertDate { get; set; }
        //public DateTime InsertTime { get; set; }
        //public String InsertUser { get; set; }
        //public DateTime UpdateDate { get; set; }
        //public DateTime UpdateTime { get; set; }
        //public String UpdateUser { get; set; }
    }
}