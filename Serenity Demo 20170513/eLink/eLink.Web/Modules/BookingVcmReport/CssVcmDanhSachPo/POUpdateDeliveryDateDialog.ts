namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class POUpdateDeliveryDateDialog extends Serenity.PropertyDialog<any, any> {

    private form: POUpdateDeliveryDateForm;
    private po: string[]

    constructor(po: string[]) {
      super();
      this.po = po;
      this.form = new POUpdateDeliveryDateForm(this.idPrefix);
      this.form.DeliveryDate.value = Date.now().toString();
    }

    protected getDialogTitle(): string {
      return "Cập nhật ngày phát";
    }   
    
    protected getDialogButtons(): Serenity.DialogButton[] {
      return [
        {
          text: "Kiểm tra",
          click: () => {
            CssVcmDanhSachPoService.GetNumberOfPoDeliveryOnThisDay({
              DeliveryDate: this.form.DeliveryDate.value,
              Keys: []
            }, response => {
              this.form.PODeliveryOnDay.value = String(response);
            })
          }
        },
        {
          text: 'Cập nhật',
          click: () => {
            if (!this.validateBeforeSave())
                  return;
            
            CssVcmDanhSachPoService.UpdateDeliveryDate({
              DeliveryDate: this.form.DeliveryDate.value,
              Keys: this.po,
              Note: this.form.Note.value
            }, response => {
              Q.notifyInfo(
                "Đã cập nhật thành công ngày phát cho " + (response.Updated || 0) + " PO");
              if (response.ErrorList != null && response.ErrorList.length > 0) {
                Q.alert(`Các đơn hàng sau phải được xác nhận hoặc kho từ chối giao trước khi cập nhật giờ giao\r\n${response.ErrorList.join("\r\n")}`);
              }
              this.dialogClose();
            });
          }
        },
      ];
    }
  }
}