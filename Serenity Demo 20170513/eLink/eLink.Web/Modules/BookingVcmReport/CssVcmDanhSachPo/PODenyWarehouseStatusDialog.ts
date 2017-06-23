namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class PODenyWarehouseStatusDialog extends Serenity.PropertyDialog<any, any> {

    private form: PODenyWarehouseStatusForm;
    private po: string[]

    constructor(po: string[]) {
      super();
      this.po = po;
      this.form = new PODenyWarehouseStatusForm(this.idPrefix);
    }

    protected getDialogTitle(): string {
      return "Kho từ chối giao hàng";
    }

    protected getDialogButtons(): Serenity.DialogButton[] {
      return [
        {
          text: "Cập nhật",
          click: () => {
            if (!this.validateBeforeSave())
              return;
            CssVcmDanhSachPoService.DenyWarehouseStatus({
              Keys: this.po,
              Note: this.form.Note.value
            },
              response => {
                if (response.ErrorList != null && response.ErrorList.length > 0) {
                  Q.alert(`Các đơn hàng sau phải cập nhật thời gian hẹn giao trước khi thực hiện\r\n${response.ErrorList.join("\r\n")}`);
                } else {
                    Q.notifySuccess("Cập nhật thành công!");
                    
                  this.dialogClose();
                }
              });
          }
        },
      ];
    }
  }
}