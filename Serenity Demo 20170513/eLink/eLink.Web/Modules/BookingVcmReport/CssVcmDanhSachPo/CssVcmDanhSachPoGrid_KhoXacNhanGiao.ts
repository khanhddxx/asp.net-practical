
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmDanhSachPoGrid_KhoXacNhanGiao extends CssVcmDanhSachPoGrid {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPoGrid_KhoXacNhanGiao'; }

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
                title: "Xác nhận lịch giao",
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
                            CssVcmDanhSachPoService.ValidateXacNhanKhoXacNhanLichGiao({
                                Keys: this.rowSelection.getSelectedKeys(),
                            }, response => {
                                if (response.ErrorList != null && response.ErrorList.length > 0) {
                                    Q.confirm(`\r\n${response.ErrorList.join("\r\n")}` + `\r\nBạn có muốn xác nhận không?`,
                                        () => {
                                            CssVcmDanhSachPoService.ConfirmWarehouseStatus({
                                                Keys: this.rowSelection.getSelectedKeys(),
                                            },
                                                response => {
                                                    if (response.ErrorList != null && response.ErrorList.length > 0) {
                                                        Q.alert(`Phải xác nhận đơn hàng trước khi thực hiện\r\n${response.ErrorList.join("\r\n")}`);
                                                    } else {
                                                        Q.notifySuccess("Cập nhật thành công!");

                                                        this.rowSelection.clear();
                                                        this.refresh();
                                                    }
                                                });

                                        },
                                        {
                                            onNo: () => { return; }
                                        });
                                }
                                else {
                                    CssVcmDanhSachPoService.ConfirmWarehouseStatus({
                                        Keys: this.rowSelection.getSelectedKeys(),
                                    },
                                        response => {
                                            if (response.ErrorList != null && response.ErrorList.length > 0) {
                                                Q.alert(`Phải xác nhận đơn hàng trước khi thực hiện\r\n${response.ErrorList.join("\r\n")}`);
                                            } else {
                                                Q.notifySuccess("Cập nhật thành công!");

                                                this.rowSelection.clear();
                                                this.refresh();
                                            }
                                        });
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
                title: "Từ chối lịch giao",
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
                        dialog = null;
                        this.refresh();
                        this.rowSelection.clear();
                    });
                    dialog.dialogOpen();


                }
            });

            return buttons;
        }

    }
}