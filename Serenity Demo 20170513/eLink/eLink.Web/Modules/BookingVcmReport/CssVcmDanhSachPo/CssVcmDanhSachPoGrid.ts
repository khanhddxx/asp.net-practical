
namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class CssVcmDanhSachPoGrid extends Serenity.EntityGrid<CssVcmDanhSachPoRow, any> {
    protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPo'; }
    protected getDialogType() { return <any>CssVcmDanhSachPoDialog; }
    protected getIdProperty() { return CssVcmDanhSachPoRow.idProperty; }
    protected getLocalTextPrefix() { return CssVcmDanhSachPoRow.localTextPrefix; }
    protected getService() { return CssVcmDanhSachPoService.baseUrl; }
    protected rowSelection: Serenity.GridRowSelectionMixin;

    constructor(container: JQuery) {
      super(container);
    }

    protected createToolbarExtensions() {
      super.createToolbarExtensions();
      this.rowSelection = new Serenity.GridRowSelectionMixin(this);
    }

    protected getButtons(): Serenity.ToolButton[] {
      const buttons = [];
      buttons.push({
        title: "Nhập từ Excel",
        cssClass: "export-xlsx-button",
        onClick: () => {
          var dialog = new POExcelImportDialog();
          dialog.element.on("dialogclose", () => {
            this.refresh();
            dialog = null;
          });
          dialog.dialogOpen();
        }
      });
      buttons.push({
        title: "Hủy",
        cssClass: "delete-button",
        onClick: () => {
          if (!this.onViewSubmit()) {
            return;
          }

          if (this.rowSelection.getSelectedKeys().length === 0) {
            Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
            return;
          }

          Q.confirm(
            "Bạn có muốn hủy các đơn hàng này!",
            () => {
              CssVcmDanhSachPoService.DeletePO({
                Keys: this.rowSelection.getSelectedKeys()
              },
                response => {
                  if (response.ErrorList != null && response.ErrorList.length > 0) {
                    Q.alert(`Các đơn sau đã được giao hàng. Không thể hủy!\r\n${response.ErrorList.join("\r\n")}`);
                  } else {
                    Q.notifySuccess("Hủy đơn hàng thành công!");
                    this.refresh();
                  }
                });
            },
            {
              onNo: () => {
                return;
              }
            });
        }
      });
      buttons.push({
        title: "Xác nhận",
        cssClass: "send-button",
        onClick: () => {
          if (!this.onViewSubmit()) {
            return;
          }
          if (this.rowSelection.getSelectedKeys().length === 0) {
            Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
            return;
          }

          Q.confirm(
            "Bạn có muốn xác nhận các đơn hàng này!",
            () => {
              CssVcmDanhSachPoService.UpdateStatus({
                Keys: this.rowSelection.getSelectedKeys()
              },
                response => {
                  if (response.ErrorList != null && response.ErrorList.length > 0) {
                    Q.alert(`Phải xác nhận đơn hàng trước khi thực hiện\r\n${response.ErrorList.join("\r\n")}`);
                  } else {
                    Q.notifySuccess("Xác nhận thành công!");
                    this.refresh();
                  }
                });
            },
            {
              onNo: () => {
                return;
              }
            });
        }
      });
      buttons.push({
        title: "Cập nhật ngày giao",
        cssClass: "edit-button",
        onClick: () => {
          // open import dialog, let it handle rest
          var dialog = new POUpdateDeliveryDateDialog(this.rowSelection.getSelectedKeys());
          dialog.element.on("dialogclose", () => {
            this.refresh();
            dialog = null;
          });
          dialog.dialogOpen();
        }
      });
      buttons.push({
        title: "Kho xác nhận giao",
        cssClass: "send-button",
        onClick:
        () => {
          if (!this.onViewSubmit()) {
            return;
          }

          if (this.rowSelection.getSelectedKeys().length === 0) {
            Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
            return;
          }

          Q.confirm(
            "Bạn có muốn xác nhận giao các đơn hàng này!",
            () => {
              CssVcmDanhSachPoService.ConfirmWarehouseStatus({
                Keys: this.rowSelection.getSelectedKeys()
              },
                response => {
                  if (response.ErrorList != null && response.ErrorList.length > 0) {
                    Q.alert(`Phải xác nhận đơn hàng trước khi thực hiện\r\n${response.ErrorList.join("\r\n")}`);
                  } else {
                    Q.notifySuccess("Cập nhật thành công!");
                    this.refresh();
                  }
                });
            },
            {
              onNo: () => {
                return;
              }
            });
        }
      });
      buttons.push({
        title: "Kho từ chối giao",
        cssClass: "delete-button",
        onClick: () => {
          if (!this.onViewSubmit()) {
            return;
          }
          if (this.rowSelection.getSelectedKeys().length === 0) {
            Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
            return;
          }
          // open import dialog, let it handle rest
          var dialog = new PODenyWarehouseStatusDialog(this.rowSelection.getSelectedKeys());
          dialog.element.on("dialogclose", () => {
            this.refresh();
            dialog = null;
          });
          dialog.dialogOpen();
        }
      });

    
      return buttons;
    }

    protected getColumns() {
      const columns = super.getColumns();
      columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));
      return columns;
    }

    protected getViewOptions() {
      const opt = super.getViewOptions();
      opt.rowsPerPage = 2500;
      return opt;
    }

    protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
        var myDate = new Date();
        
        var firstDay = new Date();
        firstDay.setDate(myDate.getDate() - 14);
        var lastDay = new Date();
        lastDay.setDate(myDate.getDate() + 14);

        let filters = super.getQuickFilters();
        let fld = CssVcmDanhSachPoRow.Fields;
        Q.first(filters, x => x.field == fld.InsertDate).init = w => {
            (w as Serenity.DateEditor).valueAsDate = firstDay;

            let endDate = w.element.nextAll(".s-DateEditor").getWidget(Serenity.DateEditor);
            endDate.valueAsDate = lastDay;
        };

        return filters;
    }
  }
}