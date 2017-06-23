namespace eLink.BookingVcmReport {
    export interface CssVcmDanhSachPoDetRow {
        Id?: number;
        MaPo?: string;
        DocumentDate?: string;
        Vendor?: string;
        VendorSupplyingSite?: string;
        Item?: number;
        Article?: string;
        ShortText?: string;
        OrderQuantity?: number;
        OrderUnit?: string;
        Ctns?: string;
        Weight?: number;
        Cbm?: string;
        NameOfUploader?: string;
        TelofUploader?: string;
        Note?: string;
        InsertDate?: string;
        InsertTime?: string;
        InsertUser?: string;
        UpdateDate?: string;
        UpdateTime?: string;
        UpdateUser?: string;
        NvLaiXe?: string;
        SdtNvLaiXe?: string;
        BienSoXe?: string;
        SoLuongUpload?: number;
        NgaySanXuat?: string;
        NgayHetHan?: string;
        SoLuongNccHenGiao?: number;
        SoLuongThucNhan?: number;
        NgayNhanThucTe?: string;
        GioNhanThucTe?: string;
        GTIN?: string;
        MerchandiseCategory?: string;
    }

    export namespace CssVcmDanhSachPoDetRow {
        export const idProperty = 'Id';
        export const nameProperty = 'MaPo';
        export const localTextPrefix = 'BookingVcmReport.CssVcmDanhSachPoDet';

        export namespace Fields {
            export declare const Id: string;
            export declare const MaPo: string;
            export declare const DocumentDate: string;
            export declare const Vendor: string;
            export declare const VendorSupplyingSite: string;
            export declare const Item: string;
            export declare const Article: string;
            export declare const ShortText: string;
            export declare const OrderQuantity: string;
            export declare const OrderUnit: string;
            export declare const Ctns: string;
            export declare const Weight: string;
            export declare const Cbm: string;
            export declare const NameOfUploader: string;
            export declare const TelofUploader: string;
            export declare const Note: string;
            export declare const InsertDate: string;
            export declare const InsertTime: string;
            export declare const InsertUser: string;
            export declare const UpdateDate: string;
            export declare const UpdateTime: string;
            export declare const UpdateUser: string;
            export declare const NvLaiXe: string;
            export declare const SdtNvLaiXe: string;
            export declare const BienSoXe: string;
            export declare const SoLuongUpload: string;
            export declare const NgaySanXuat: string;
            export declare const NgayHetHan: string;
            export declare const SoLuongNccHenGiao: string;
            export declare const SoLuongThucNhan: string;
            export declare const NgayNhanThucTe: string;
            export declare const GioNhanThucTe: string;
            export declare const GTIN: string;
            export declare const MerchandiseCategory: string;
        }

        ['Id', 'MaPo', 'DocumentDate', 'Vendor', 'VendorSupplyingSite', 'Item', 'Article', 'ShortText', 'OrderQuantity', 'OrderUnit', 'Ctns', 'Weight', 'Cbm', 'NameOfUploader', 'TelofUploader', 'Note', 'InsertDate', 'InsertTime', 'InsertUser', 'UpdateDate', 'UpdateTime', 'UpdateUser', 'NvLaiXe', 'SdtNvLaiXe', 'BienSoXe', 'SoLuongUpload', 'NgaySanXuat', 'NgayHetHan', 'SoLuongNccHenGiao', 'SoLuongThucNhan', 'NgayNhanThucTe', 'GioNhanThucTe', 'GTIN', 'MerchandiseCategory'].forEach(x => (<any>Fields)[x] = x);
    }
}

