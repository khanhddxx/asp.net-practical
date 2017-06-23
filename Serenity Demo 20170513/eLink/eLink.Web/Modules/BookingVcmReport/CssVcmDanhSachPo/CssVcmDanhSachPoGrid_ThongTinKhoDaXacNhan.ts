
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmDanhSachPoGrid_ThongTinKhoDaXacNhan extends CssVcmDanhSachPoGrid {

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
                service: 'BookingVcmReport/CssVcmDanhSachPo/ListMauExcelThongTinKhoXacNhan',
                separator: true,
                hint: "Lấy mẫu upload Excel",
                title: "Lấy mẫu upload Excel",

            }));
            buttons.push({
                title: "Upload dữ liệu nhận thực tế",
                cssClass: "export-xlsx-button",
                onClick: () => {
                    var dialog = new POExcelUpdateThongTinKhoXacNhanDialog();
                    dialog.element.on("dialogclose", () => {                        
                        this.refresh();
                        dialog = null;
                    });
                    dialog.dialogOpen();
                }
            });
            buttons.push({
                title: "Hủy lịch",
                cssClass: "delete-button",
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    if (this.rowSelection.getSelectedKeys().length === 0) {
                        Q.notifyError("Bạn phải chọn đơn hàng cần thao tác!");
                        return;
                    }
                    
                    var dialog = new KhoHuyLichDonHangDialog(this.rowSelection.getSelectedKeys());
                    dialog.element.on("dialogclose", () => {
                        this.rowSelection.clear();
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