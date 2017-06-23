
namespace eLink.QuanLyHocSinh {

    @Serenity.Decorators.registerClass()
    export class QuanLyHocSinhGrid extends Serenity.EntityGrid<QuanLyHocSinhRow, any> {
        protected getColumnsKey() { return 'QuanLyHocSinh.QuanLyHocSinh'; }
        protected getDialogType() { return QuanLyHocSinhDialog; }
        protected getIdProperty() { return QuanLyHocSinhRow.idProperty; }
        protected getLocalTextPrefix() { return QuanLyHocSinhRow.localTextPrefix; }
        protected getService() { return QuanLyHocSinhService.baseUrl; }
        protected rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
        }
        protected getButtons(): Serenity.ToolButton[] {
            const buttons = [];
            buttons.push({
                title: "Thêm học sinh", cssClass: "add-button",
                onClick: () => { var dialog = new QuanLyHocSinhDialog(); dialog.dialogOpen(); }
            });
            return buttons;

        }
    }
}