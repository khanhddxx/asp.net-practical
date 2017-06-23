
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmDanhSachPoGrid_KhoUpDS extends CssVcmDanhSachPoGrid {

        constructor(container: JQuery) {
            super(container);
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            //this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

        protected getButtons(): Serenity.ToolButton[] {
            const buttons = [];
            buttons.push(eLink.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'BookingVcmReport/CssVcmDanhSachPo/ListExcel',
                separator: true,
                hint: "Lấy mẫu upload Excel",
                title: "Lấy mẫu upload Excel",
            }));

            buttons.push({
                title: "Nhập từ Excel",
                cssClass: "export-xlsx-button",
                onClick: () => {
                    var dialog = new POExcelImportDialog();
                    dialog.element.on("dialogclose", () => {                        
                        this.refresh();
                        this.rowSelection.clear();
                        dialog = null;
                    });
                    dialog.dialogOpen();
                }
            });
            buttons.push({
                title: "Hủy" ,
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
                                        this.rowSelection.clear();
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
                                        this.rowSelection.clear();
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
          

            return buttons;
        }

    }
}