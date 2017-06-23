namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.POExcelImport")]
    public class POExcelImportForm
    {
        [DisplayName("Chọn file"), FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}
