namespace eLink.BookingVcmReport {
    export namespace CssVcmDanhSachPoService {
        export const baseUrl = 'BookingVcmReport/CssVcmDanhSachPo';

        export declare function Create(request: Serenity.SaveRequest<CssVcmDanhSachPoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<CssVcmDanhSachPoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CssVcmDanhSachPoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CssVcmDanhSachPoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ExcelImport(request: ExcelImportRequest, onSuccess?: (response: ExcelImportResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ExcelUpdate(request: Serenity.ExcelUpdateRequest, onSuccess?: (response: ExcelImportResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ExcelUpdateThongTinKhoXacNhan(request: Serenity.ExcelUpdateRequest, onSuccess?: (response: ExcelImportResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function UpdateStatus(request: Serenity.ListKeysRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetNumberOfPo(request: System.String, onSuccess?: (response: System.Decimal) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetNumberOfPoDeliveryOnThisDay(request: Serenity.POUpdateDeliveryDateRequest, onSuccess?: (response: System.Decimal) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function UpdateDeliveryDate(request: Serenity.POUpdateDeliveryDateRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ValidateXacNhanKhoXacNhanLichGiao(request: Serenity.ListKeysRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ConfirmWarehouseStatus(request: Serenity.ListKeysRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function DenyWarehouseStatus(request: Serenity.POUpdateDeliveryDateRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function DeletePO(request: Serenity.ListKeysRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function KhoHuyLichDonHang(request: Serenity.POUpdateDeliveryDateRequest, onSuccess?: (response: Serenity.BaseUpdateResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getListStringColumnsThuTuXapXep(request: Serenity.ServiceRequest, onSuccess?: (response: System.Collections.Generic.List<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getThongTinDonHangTheoMaPO(request: System.Collections.Generic.List<string>, onSuccess?: (response: System.Collections.Generic.IEnumerable<CssVcmDanhSachPoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function getDicEmailTheoMaNCC(request: System.Collections.Generic.List<string>, onSuccess?: (response: System.Collections.Generic.Dictionary<string, string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export namespace Methods {
            export declare const Create: string;
            export declare const Update: string;
            export declare const Delete: string;
            export declare const Retrieve: string;
            export declare const List: string;
            export declare const ExcelImport: string;
            export declare const ExcelUpdate: string;
            export declare const ExcelUpdateThongTinKhoXacNhan: string;
            export declare const UpdateStatus: string;
            export declare const GetNumberOfPo: string;
            export declare const GetNumberOfPoDeliveryOnThisDay: string;
            export declare const UpdateDeliveryDate: string;
            export declare const ValidateXacNhanKhoXacNhanLichGiao: string;
            export declare const ConfirmWarehouseStatus: string;
            export declare const DenyWarehouseStatus: string;
            export declare const DeletePO: string;
            export declare const KhoHuyLichDonHang: string;
            export declare const getListStringColumnsThuTuXapXep: string;
            export declare const getThongTinDonHangTheoMaPO: string;
            export declare const getDicEmailTheoMaNCC: string;
        }

        ['Create', 'Update', 'Delete', 'Retrieve', 'List', 'ExcelImport', 'ExcelUpdate', 'ExcelUpdateThongTinKhoXacNhan', 'UpdateStatus', 'GetNumberOfPo', 'GetNumberOfPoDeliveryOnThisDay', 'UpdateDeliveryDate', 'ValidateXacNhanKhoXacNhanLichGiao', 'ConfirmWarehouseStatus', 'DenyWarehouseStatus', 'DeletePO', 'KhoHuyLichDonHang', 'getListStringColumnsThuTuXapXep', 'getThongTinDonHangTheoMaPO', 'getDicEmailTheoMaNCC'].forEach(x => {
            (<any>CssVcmDanhSachPoService)[x] = function (r, s, o) { return Q.serviceRequest(baseUrl + '/' + x, r, s, o); };
            (<any>Methods)[x] = baseUrl + '/' + x;
        });
    }
}

