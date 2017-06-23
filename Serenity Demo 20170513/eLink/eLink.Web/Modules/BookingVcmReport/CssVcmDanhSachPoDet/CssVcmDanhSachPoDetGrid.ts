
namespace eLink.BookingVcmReport {
    
    @Serenity.Decorators.registerClass()
    export class CssVcmDanhSachPoDetGrid extends Serenity.EntityGrid<CssVcmDanhSachPoDetRow, any> {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPoDet'; }
        protected getDialogType() { return CssVcmDanhSachPoDetDialog; }
        protected getIdProperty() { return CssVcmDanhSachPoDetRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmDanhSachPoDetRow.localTextPrefix; }
        protected getService() { return CssVcmDanhSachPoDetService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
            
        }
    }
}