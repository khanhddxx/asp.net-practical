declare var Morris: any;

namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.resizable()
    @Serenity.Decorators.maximizable()
    export class CssVcmDanhSachPoChartInPanel extends Serenity.TemplatedPanel<any> {

        private areaChart: any;

        constructor(container: JQuery) {
            super(container);
            CssVcmDanhSachPoChartService.CssVcmDanhSachPoGetDataChart({}, response => {
                this.areaChart = new Morris.Bar({
                    element: this.idPrefix + 'Chart',
                    resize: true, parseTime: false,
                    data: response.Values,
                    xkey: 'Day',
                    ykeys: 's', labels: 'SL', hideHover: 'false'
                });
            });
        }

        protected arrange() {
            super.arrange();

            this.areaChart && this.areaChart.redraw();
        }

        protected getTemplate() {
            // you could also put this in a ChartInDialog.Template.html file. it's here for simplicity.
            return "<div id='~_Chart'></div>";
        }
    }
}