
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CssVcmDanhSachPoDialog extends Serenity.EntityDialog<CssVcmDanhSachPoRow, any> {
        protected getFormKey() { return CssVcmDanhSachPoForm.formKey; }
        protected getIdProperty() { return CssVcmDanhSachPoRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmDanhSachPoRow.localTextPrefix; }
        protected getNameProperty() { return CssVcmDanhSachPoRow.nameProperty; }
        protected getService() { return CssVcmDanhSachPoService.baseUrl; }

        protected form = new CssVcmDanhSachPoForm(this.idPrefix);

        private CssVcmDanhSachPoDetGrid: CssVcmDanhSachPoCssVcmDanhSachPoDetGrid;
        private loadedState: string;
        constructor() {
            super();

            this.CssVcmDanhSachPoDetGrid = new CssVcmDanhSachPoCssVcmDanhSachPoDetGrid(this.byId('CssVcmDanhSachPoCssVcmDanhSachPoDetGrid'));
            this.tabs.bind('tabsactivate', () => this.arrange());
            
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            this.CssVcmDanhSachPoDetGrid.maPo = this.entityId;
        }
        getToolbarButtons() {
            var buttons = [];
            return buttons;
        }
    }
}