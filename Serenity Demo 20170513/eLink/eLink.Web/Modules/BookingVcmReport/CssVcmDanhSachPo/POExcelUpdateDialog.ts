namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class POExcelUpdateDialog extends Serenity.PropertyDialog<any, any> {

      private form: POExcelUpdateForm;

    constructor() {
      super();
      this.form = new POExcelUpdateForm(this.idPrefix);
    }

    protected getDialogTitle(): string {
      return "Cập nhật từ Excel";
    }

    protected getDialogButtons(): Serenity.DialogButton[] {
      return [
        {
          text: "Nhập",
          click: () => {
            if (!this.validateBeforeSave())
              return;

            if (this.form.FileName.value == null ||
              Q.isEmptyOrNull(this.form.FileName.value.Filename)) {
              Q.notifyError("Bạn phải chọn file Excel cần nhập!");
              return;
            }

            CssVcmDanhSachPoService.ExcelUpdate({
              FileName: this.form.FileName.value.Filename
            },
              response => {
                Q.notifyInfo(
                  `Inserted: ${response.Inserted || 0}`);
                if (response.ErrorList != null && response.ErrorList.length > 0) {
                  Q.notifyError(response.ErrorList.join(",\r\n "));
                }
                this.dialogClose();
              });
          }
        }
      ];
    }
  }
}