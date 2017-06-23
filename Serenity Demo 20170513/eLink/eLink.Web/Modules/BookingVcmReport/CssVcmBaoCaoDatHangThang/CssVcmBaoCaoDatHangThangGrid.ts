
namespace eLink.BookingVcmReport {
    
    @Serenity.Decorators.registerClass()
    export class CssVcmBaoCaoDatHangThangGrid extends Serenity.EntityGrid<CssVcmBaoCaoDatHangThangRow, any> {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmBaoCaoDatHangThang'; }
        protected getDialogType() { return CssVcmBaoCaoDatHangThangDialog; }
        protected getIdProperty() { return CssVcmBaoCaoDatHangThangRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmBaoCaoDatHangThangRow.localTextPrefix; }
        protected getService() { return CssVcmBaoCaoDatHangThangService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getButtons(): Serenity.ToolButton[] {

            const buttons = [];
            
            buttons.push(eLink.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'BookingVcmReport/CssVcmBaoCaoDatHangThang/ListExcel',
                separator: true
            }));

            //buttons.push(eLink.Common.PdfExportHelper.createToolButton({
            //    grid: this,
            //    onViewSubmit: () => this.onViewSubmit()
            //}));
            return buttons;
        }
        protected createQuickSearchInput() { return null }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            var myDate = new Date(), y = myDate.getFullYear(), m = myDate.getMonth();
            var firstDay = new Date(y, m, 1);
            var lastDay = new Date(y, m + 1, 0);
            

            let filters = super.getQuickFilters();
            let fld = CssVcmBaoCaoDatHangThangRow.Fields;
            Q.first(filters, x => x.field == fld.NgayDatHang).init = w => {
                (w as Serenity.DateEditor).valueAsDate = firstDay;

                let endDate = w.element.nextAll(".s-DateEditor").getWidget(Serenity.DateEditor);
                endDate.valueAsDate = lastDay;
            };

            return filters;
        }
    }
}