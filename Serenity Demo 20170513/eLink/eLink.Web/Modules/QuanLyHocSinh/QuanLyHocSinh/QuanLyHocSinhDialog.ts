
namespace eLink.QuanLyHocSinh {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class QuanLyHocSinhDialog extends Serenity.EntityDialog<QuanLyHocSinhRow, any> {
        protected getFormKey() { return QuanLyHocSinhForm.formKey; }
        protected getIdProperty() { return QuanLyHocSinhRow.idProperty; }
        protected getLocalTextPrefix() { return QuanLyHocSinhRow.localTextPrefix; }
        protected getNameProperty() { return QuanLyHocSinhRow.nameProperty; }
        protected getService() { return QuanLyHocSinhService.baseUrl; }

        protected form = new QuanLyHocSinhForm(this.idPrefix);
        protected getDialogTitle(): string {
            return "Thêm học sinh";
        }
        getToolbarButtons() {
            var buttons = [];
            buttons.pop();
            return buttons;
        }
    }
}