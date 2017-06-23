
namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class CssVcmDanhSachPoGrid_NCCHenGiao extends CssVcmDanhSachPoGrid {

      constructor(container: JQuery) {
      super(container);
    }

    protected createToolbarExtensions() {
      super.createToolbarExtensions();
      //this.rowSelection = new Serenity.GridRowSelectionMixin(this);
    }

    protected getButtons(): Serenity.ToolButton[] {
        const buttons = [];
       
        buttons.push({
            title: "Cập nhật ngày giao",
            cssClass: "edit-button",
            onClick: () => {
                // open import dialog, let it handle rest
                var dialog = new POUpdateDeliveryDateDialog(this.rowSelection.getSelectedKeys());
                dialog.element.on("dialogclose", () => {                   
                    this.refresh();
                    dialog = null;
                    this.rowSelection.clear();
                });
                dialog.dialogOpen();
            }
        });

        buttons.push(eLink.Common.ExcelExportHelper.createToolButton({
            grid: this,
            onViewSubmit: () => this.onViewSubmit(),
            service: 'BookingVcmReport/CssVcmDanhSachPo/ListMauExcelNCCHenLichGiao',
            separator: true,
            hint: "Lấy mẫu upload Excel",
            title: "Lấy mẫu upload Excel",

        }));
        buttons.push({
            title: "Export theo mẫu Excel",
            cssClass: "export-xlsx-button",
            onClick: () => {
                if (this.rowSelection.getSelectedKeys().length === 0) {
                    Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
                    return;
                }
                var request = Q.deepClone(this.getView().params) as Serenity.ListKeysExRequest;
                request.Keys = this.rowSelection.getSelectedKeys();
                request.IncludeColumns = [];
                let columns = this.getGrid().getColumns();
                for (let column of columns) {
                    request.IncludeColumns.push(column.id || column.field);
                }
                Q.postToService({
                    service: 'BookingVcmReport/CssVcmDanhSachPo/ListXuatFileExcelNCCHenLichGiao',
                    request: request, target: '_blank'
                });
        
            }
        });


        buttons.push({
            title: "Cập nhật từ Excel",
            cssClass: "export-xlsx-button",
            onClick: () => {
                var dialog = new POExcelUpdateDialog();
                dialog.element.on("dialogclose", () => {                   
                    this.refresh();
                    dialog = null;
                });
                dialog.dialogOpen();
            }
        });
  
      return buttons;
    }
      
  }
}