namespace eLink.BookingVcmReport {
    export namespace CssVcmDanhSachPoChartService {
        export const baseUrl = 'BookingVcmReport/CssVcmDanhSachPoChart';

        export declare function CssVcmDanhSachPoGetDataChart(request: Serenity.CssVcmDanhSachPoRequest, onSuccess?: (response: Serenity.CssVcmDanhSachPoResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export namespace Methods {
            export declare const CssVcmDanhSachPoGetDataChart: string;
        }

        ['CssVcmDanhSachPoGetDataChart'].forEach(x => {
            (<any>CssVcmDanhSachPoChartService)[x] = function (r, s, o) { return Q.serviceRequest(baseUrl + '/' + x, r, s, o); };
            (<any>Methods)[x] = baseUrl + '/' + x;
        });
    }
}

