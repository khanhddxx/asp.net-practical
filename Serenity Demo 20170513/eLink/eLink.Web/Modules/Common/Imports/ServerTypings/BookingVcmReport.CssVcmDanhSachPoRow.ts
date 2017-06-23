namespace eLink.BookingVcmReport {
    export interface CssVcmDanhSachPoRow {
        Id?: number;
        MaPo?: string;
        NgayGiao?: string;
        Vendor?: string;
        VendorSupplyingSite?: string;
        GhiChu?: string;
        InsertDate?: string;
        InsertTime?: string;
        InsertUser?: string;
        InsertUserName?: string;
        UpdateDate?: string;
        UpdateTime?: string;
        UpdateUser?: string;
        UpdateUserName?: string;
        TrangThai?: string;
        GioGiao?: string;
        GhiChuHenGiao?: string;
        GhiChuTuChoi?: string;
        TenTrangThai?: string;
        NvLaiXe?: string;
        SdtNvLaiXe?: string;
        BienSoXe?: string;
        Quantity?: number;
        NgayNhanThucTe?: string;
        GioNhanThucTe?: string;
        SLKhungThoiGianDaXacNhan?: number;
        Site?: string;
        DeliveryDate?: string;
        ReleaseStrategy?: string;
    }

    export namespace CssVcmDanhSachPoRow {
        export const idProperty = 'MaPo';
        export const nameProperty = 'MaPo';
        export const localTextPrefix = 'BookingVcmReport.CssVcmDanhSachPo';

        export namespace Fields {
            export declare const Id: string;
            export declare const MaPo: string;
            export declare const NgayGiao: string;
            export declare const Vendor: string;
            export declare const VendorSupplyingSite: string;
            export declare const GhiChu: string;
            export declare const InsertDate: string;
            export declare const InsertTime: string;
            export declare const InsertUser: string;
            export declare const InsertUserName: string;
            export declare const UpdateDate: string;
            export declare const UpdateTime: string;
            export declare const UpdateUser: string;
            export declare const UpdateUserName: string;
            export declare const TrangThai: string;
            export declare const GioGiao: string;
            export declare const GhiChuHenGiao: string;
            export declare const GhiChuTuChoi: string;
            export declare const TenTrangThai: string;
            export declare const NvLaiXe: string;
            export declare const SdtNvLaiXe: string;
            export declare const BienSoXe: string;
            export declare const Quantity: string;
            export declare const NgayNhanThucTe: string;
            export declare const GioNhanThucTe: string;
            export declare const SLKhungThoiGianDaXacNhan: string;
            export declare const Site: string;
            export declare const DeliveryDate: string;
            export declare const ReleaseStrategy: string;
        }

        ['Id', 'MaPo', 'NgayGiao', 'Vendor', 'VendorSupplyingSite', 'GhiChu', 'InsertDate', 'InsertTime', 'InsertUser', 'InsertUserName', 'UpdateDate', 'UpdateTime', 'UpdateUser', 'UpdateUserName', 'TrangThai', 'GioGiao', 'GhiChuHenGiao', 'GhiChuTuChoi', 'TenTrangThai', 'NvLaiXe', 'SdtNvLaiXe', 'BienSoXe', 'Quantity', 'NgayNhanThucTe', 'GioNhanThucTe', 'SLKhungThoiGianDaXacNhan', 'Site', 'DeliveryDate', 'ReleaseStrategy'].forEach(x => (<any>Fields)[x] = x);
    }
}

