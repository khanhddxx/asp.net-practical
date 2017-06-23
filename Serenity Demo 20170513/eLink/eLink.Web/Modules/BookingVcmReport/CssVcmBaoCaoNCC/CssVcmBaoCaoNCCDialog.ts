namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CssVcmBaoCaoNCCDialog extends Serenity.EntityDialog<CssVcmBaoCaoNCCRow, any> {
        protected getFormKey() { return CssVcmBaoCaoNCCForm.formKey; }
        protected getIdProperty() { return CssVcmBaoCaoNCCRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmBaoCaoNCCRow.localTextPrefix; }
        protected getNameProperty() { return CssVcmBaoCaoNCCRow.nameProperty; }
        protected getService() { return CssVcmBaoCaoNCCService.baseUrl; }

        protected form = new CssVcmBaoCaoNCCForm(this.idPrefix);

    }
}