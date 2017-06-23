
namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmBaoCaoDatHangKheThoiGianGrid extends Serenity.EntityGrid<CssVcmBaoCaoDatHangKheThoiGianRow, any> {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian'; }
        //protected getDialogType() { return CssVcmBaoCaoDatHangKheThoiGianDialog; }
        protected getIdProperty() { return CssVcmBaoCaoDatHangKheThoiGianRow.idProperty; }
        protected getLocalTextPrefix() { return CssVcmBaoCaoDatHangKheThoiGianRow.localTextPrefix; }
        protected getService() { return CssVcmBaoCaoDatHangKheThoiGianService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getButtons(): Serenity.ToolButton[] {
            const buttons = [];
            buttons.push(eLink.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: 'BookingVcmReport/CssVcmBaoCaoDatHangKheThoiGian/ListExcel',
                separator: true
            }));

            //buttons.push(eLink.Common.PdfExportHelper.createToolButton({
            //    grid: this,
            //    onViewSubmit: () => this.onViewSubmit()
            //}));

            buttons.push({
                title: 'Nhóm Ngày giao',
                cssClass: 'expand-all-button',
                onClick: () => this.view.setGrouping(
                    [{
                        formatter: x => String(x.value),
                        getter: 'NgayGiao'
                    }])
            });
            buttons.push({
                title: 'Bỏ Nhóm',
                cssClass: 'collapse-all-button',
                onClick: () => this.view.setGrouping([])
            }
            );
            return buttons;
        }


        protected createSlickGrid() {
            var grid = super.createSlickGrid();

            // need to register this plugin for grouping or you'll have errors
            grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());

            this.view.setSummaryOptions({
                aggregators: [
                    new Slick.Aggregators.Sum('SoLuong'),
                ]
            });
            return grid;
        }

        protected getSlickOptions() {
            var opt = super.getSlickOptions();
            opt.showFooterRow = true;
            return opt;
        }

        protected createQuickSearchInput() { return null }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            var myDate = new Date();
            myDate.setDate(myDate.getDate() + 7)

            let filters = super.getQuickFilters();
            let fld = CssVcmBaoCaoDatHangKheThoiGianRow.Fields;
            Q.first(filters, x => x.field == fld.GioGiao).init = w => {
                (w as Serenity.DateEditor).valueAsDate = new Date();

                let endDate = w.element.nextAll(".s-DateEditor").getWidget(Serenity.DateEditor);
                endDate.valueAsDate = myDate;
            };
            
            return filters;
        }
    }
}