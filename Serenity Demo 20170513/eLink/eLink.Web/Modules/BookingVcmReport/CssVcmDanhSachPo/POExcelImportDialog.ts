namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class POExcelImportDialog extends Serenity.PropertyDialog<any, any> {

    private form: POExcelImportForm;

    constructor() {
      super();
      this.form = new POExcelImportForm(this.idPrefix);
    }

    protected getDialogTitle(): string {
      return "Nhập liệu Excel";
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

            CssVcmDanhSachPoService.ExcelImport({
              FileName: this.form.FileName.value.Filename
            },
              response => {
                if (response.ErrorList != null && response.ErrorList.length > 0) {
                  Q.alert(response.ErrorList.join(",\r\n "));
                }
                else {
                  Q.notifyInfo(
                    `Upload thành công ${response.Inserted || 0} PO`);
                }
                this.dialogClose();
              });
          }
        }
      ];
    }
  }
}