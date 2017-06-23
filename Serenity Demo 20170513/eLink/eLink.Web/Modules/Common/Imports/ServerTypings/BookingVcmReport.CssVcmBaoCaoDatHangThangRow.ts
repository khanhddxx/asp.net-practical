namespace eLink.BookingVcmReport {
    export interface CssVcmBaoCaoDatHangThangRow {
        Id?: number;
        MaPo?: string;
        NgayDatHang?: string;
        NgayThucNhan?: string;
        SkuKeHoach?: number;
        UnitKeHoach?: number;
        SkuThucNhan?: number;
        UnitThucNhan?: number;
        SkuChenhLech?: number;
        UnitChenhLech?: number;
        SkuTiLe?: number;
        UnitTiLe?: number;
        DeliveryInFullGrade?: string;
        GioGiao?: string;
        GioNhanThucTe?: string;
        ThoiGianTre?: string;
        GhiChuHenGiao?: string;
        DeliveryInTimeGrade?: string;
        Vendor?: string;
        Vendor_SupplyingSite?: string;
    }

    export namespace CssVcmBaoCaoDatHangThangRow {
        export const idProperty = 'Id';
        export const nameProperty = 'MaPo';
        export const localTextPrefix = 'BookingVcmReport.CssVcmBaoCaoDatHangThang';

        export namespace Fields {
            export declare const Id: string;
            export declare const MaPo: string;
            export declare const NgayDatHang: string;
            export declare const NgayThucNhan: string;
            export declare const SkuKeHoach: string;
            export declare const UnitKeHoach: string;
            export declare const SkuThucNhan: string;
            export declare const UnitThucNhan: string;
            export declare const SkuChenhLech: string;
            export declare const UnitChenhLech: string;
            export declare const SkuTiLe: string;
            export declare const UnitTiLe: string;
            export declare const DeliveryInFullGrade: string;
            export declare const GioGiao: string;
            export declare const GioNhanThucTe: string;
            export declare const ThoiGianTre: string;
            export declare const GhiChuHenGiao: string;
            export declare const DeliveryInTimeGrade: string;
            export declare const Vendor: string;
            export declare const Vendor_SupplyingSite: string;
        }

        ['Id', 'MaPo', 'NgayDatHang', 'NgayThucNhan', 'SkuKeHoach', 'UnitKeHoach', 'SkuThucNhan', 'UnitThucNhan', 'SkuChenhLech', 'UnitChenhLech', 'SkuTiLe', 'UnitTiLe', 'DeliveryInFullGrade', 'GioGiao', 'GioNhanThucTe', 'ThoiGianTre', 'GhiChuHenGiao', 'DeliveryInTimeGrade', 'Vendor', 'Vendor_SupplyingSite'].forEach(x => (<any>Fields)[x] = x);
    }
}

