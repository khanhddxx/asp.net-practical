namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class KhoHuyLichDonHangDialog extends Serenity.PropertyDialog<any, any> {

      private form: KhoHuyLichDonHangForm;
    private po: string[]

    constructor(po: string[]) {
      super();
      this.po = po;
      this.form = new KhoHuyLichDonHangForm(this.idPrefix);      
    }

    protected getDialogTitle(): string {
      return "Hủy lịch";
    }   
    
    protected getDialogButtons(): Serenity.DialogButton[] {
      return [       
        {
          text: 'Hủy lịch',
          click: () => {
            if (!this.validateBeforeSave())
                  return;
            
            CssVcmDanhSachPoService.KhoHuyLichDonHang({
              Keys: this.po,
              Note: this.form.Note.value
            }, response => {
              
              if (response.ErrorList != null && response.ErrorList.length > 0) {
                Q.alert(`Các đơn hàng sau có trạng thái đã nhận hàng! Không được hủy.\r\n${response.ErrorList.join("\r\n")}`);
              }
              else {
                  Q.notifyInfo(
                      "Đã hủy lịch thành công cho " + (response.Updated || 0) + " PO");
              }
              this.dialogClose();
            });
          }
        },
      ];
    }
  }
}