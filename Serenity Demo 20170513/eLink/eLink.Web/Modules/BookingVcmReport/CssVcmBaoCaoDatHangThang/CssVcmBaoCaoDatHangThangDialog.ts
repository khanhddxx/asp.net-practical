
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CssVcmBaoCaoDatHangThangDialog extends Serenity.EntityDialog<CssVcmBaoCaoDatHangThangRow, any> {
        protected getFormKey() { return CssVcmBaoCaoDatHangThangForm.formKey; }
        protected getIdProperty() { return CssVcmBaoCaoDatHangThangRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmBaoCaoDatHangThangRow.localTextPrefix; }
        protected getNameProperty() { return CssVcmBaoCaoDatHangThangRow.nameProperty; }
        protected getService() { return CssVcmBaoCaoDatHangThangService.baseUrl; }

        protected form = new CssVcmBaoCaoDatHangThangForm(this.idPrefix);

    }
}