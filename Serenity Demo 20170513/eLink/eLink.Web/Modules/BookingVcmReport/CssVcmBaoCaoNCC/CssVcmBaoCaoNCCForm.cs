
namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("BookingVcmReport.CssVcmBaoCaoNCC")]
    [BasedOnRow(typeof(Entities.CssVcmBaoCaoNCCRow))]
    public class CssVcmBaoCaoNCCForm
    {
        public String Vendor { get; set; }
        public String Vendor_SupplyingSite { get; set; }
    }
}