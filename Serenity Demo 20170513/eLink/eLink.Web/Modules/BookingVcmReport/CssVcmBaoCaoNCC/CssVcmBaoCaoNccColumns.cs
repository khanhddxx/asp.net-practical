namespace eLink.BookingVcmReport.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("BookingVcmReport.CssVcmBaoCaoNCC")]
    [BasedOnRow(typeof(Entities.CssVcmBaoCaoNCCRow))]
    public class CssVcmBaoCaoNCCColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public string Vendor { get; set; }
        public string Vendor_SupplyingSite { get; set; }
    }
}