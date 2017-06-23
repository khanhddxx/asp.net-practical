
namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.PODenyWarehouseStatus")]
    public class PODenyWarehouseStatusForm
    {
        [DisplayName("Ghi chú"), Required]
        public String Note { get; set; }
    }
}
