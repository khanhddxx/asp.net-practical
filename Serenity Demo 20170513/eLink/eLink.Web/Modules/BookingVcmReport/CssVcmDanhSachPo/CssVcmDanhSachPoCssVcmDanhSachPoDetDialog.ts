
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CssVcmDanhSachPoCssVcmDanhSachPoDetDialog extends Serenity.EntityDialog<CssVcmDanhSachPoDetRow, any> {
        protected getFormKey() { return CssVcmDanhSachPoDetForm.formKey; }
        protected getIdProperty() { return CssVcmDanhSachPoDetRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmDanhSachPoDetRow.localTextPrefix; }
        protected getNameProperty() { return CssVcmDanhSachPoDetRow.nameProperty; }
        protected getService() { return CssVcmDanhSachPoDetService.baseUrl; }

        protected form = new CssVcmDanhSachPoDetForm(this.idPrefix);


        constructor() {
            super();
        }
    }
}