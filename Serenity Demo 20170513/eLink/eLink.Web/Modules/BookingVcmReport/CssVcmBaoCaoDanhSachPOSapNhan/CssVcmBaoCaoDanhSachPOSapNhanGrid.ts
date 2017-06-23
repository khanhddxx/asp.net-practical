
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmBaoCaoDanhSachPOSapNhanGrid extends Serenity.EntityGrid<CssVcmDanhSachPoRow, any> {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmBaoCaoDanhSachPOSapNhan'; }
        protected getDialogType() { return <any>CssVcmDanhSachPoDialog; }
        protected getIdProperty() { return CssVcmDanhSachPoRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmDanhSachPoRow.localTextPrefix; }
        protected getService() { return 'BookingVcmReport/CssVcmBaoCaoDanhSachPOSapNhan'; }
        protected rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            //this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

       
        protected getButtons(): Serenity.ToolButton[] {
            const buttons = [];            
            return buttons;
        }

        protected createQuickSearchInput() { return null }



    }
}