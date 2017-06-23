namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.POExcelUpdate")]
    public class POExcelUpdateForm
    {
        [DisplayName("Chọn file"), FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}
