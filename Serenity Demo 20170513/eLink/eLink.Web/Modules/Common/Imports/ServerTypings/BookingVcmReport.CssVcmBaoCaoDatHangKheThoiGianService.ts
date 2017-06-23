namespace eLink.BookingVcmReport {
    export namespace CssVcmBaoCaoDatHangKheThoiGianService {
        export const baseUrl = 'BookingVcmReport/CssVcmBaoCaoDatHangKheThoiGian';

        export declare function Create(request: Serenity.SaveRequest<CssVcmBaoCaoDatHangKheThoiGianRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<CssVcmBaoCaoDatHangKheThoiGianRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CssVcmBaoCaoDatHangKheThoiGianRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CssVcmBaoCaoDatHangKheThoiGianRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getListKheThoiGianAll(request: Serenity.ServiceRequest, onSuccess?: (response: System.Collections.Generic.IEnumerable<CssVcmBaoCaoDatHangKheThoiGianRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getListKheThoiGian(request: System.DateTime, onSuccess?: (response: System.Collections.Generic.IEnumerable<CssVcmBaoCaoDatHangKheThoiGianRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getKheThoiGian(request: System.DateTime, onSuccess?: (response: CssVcmBaoCaoDatHangKheThoiGianRow) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export namespace Methods {
            export declare const Create: string;
            export declare const Update: string;
            export declare const Delete: string;
            export declare const Retrieve: string;
            export declare const List: string;
            export declare const getListKheThoiGianAll: string;
            export declare const getListKheThoiGian: string;
            export declare const getKheThoiGian: string;
        }

        ['Create', 'Update', 'Delete', 'Retrieve', 'List', 'getListKheThoiGianAll', 'getListKheThoiGian', 'getKheThoiGian'].forEach(x => {
            (<any>CssVcmBaoCaoDatHangKheThoiGianService)[x] = function (r, s, o) { return Q.serviceRequest(baseUrl + '/' + x, r, s, o); };
            (<any>Methods)[x] = baseUrl + '/' + x;
        });
    }
}

