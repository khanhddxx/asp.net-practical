
namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.POUpdateDeliveryDate")]
    public class POUpdateDeliveryDateForm
    {
        [DisplayName("Ngày giao"), DateTimeEditor, Required]
        public String DeliveryDate { get; set; }

        [DisplayName("Đơn giao trong ngày"), ReadOnly(true)]
        public String PODeliveryOnDay { get; set; }

        [DisplayName("Ghi chú")]
        public String Note { get; set; }
    }
}
