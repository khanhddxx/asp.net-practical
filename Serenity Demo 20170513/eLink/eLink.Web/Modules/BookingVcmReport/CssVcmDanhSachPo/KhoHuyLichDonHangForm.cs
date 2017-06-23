
namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.KhoHuyLichDonHang")]
    public class KhoHuyLichDonHangForm
    {        
        [DisplayName("Ghi chú")]
        public String Note { get; set; }
    }
}
