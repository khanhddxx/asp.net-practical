namespace eLink.BookingVcmReport {
    export interface CssVcmBaoCaoDatHangKheThoiGianRow {
        Id?: number;
        NgayGiao?: string;
        GioGiao?: string;
        KheThoiGian?: string;
        SoLuong?: number;
        SoLuongToiDa?: number;
        ChenhLech?: number;
        FromTime?: string;
        ToTime?: string;
        DayOfWeek?: string;
        EqualFromTime?: boolean;
        EqualToTime?: boolean;
    }

    export namespace CssVcmBaoCaoDatHangKheThoiGianRow {
        export const idProperty = 'Id';
        export const nameProperty = 'KheThoiGian';
        export const localTextPrefix = 'BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian';

        export namespace Fields {
            export declare const Id: string;
            export declare const NgayGiao: string;
            export declare const GioGiao: string;
            export declare const KheThoiGian: string;
            export declare const SoLuong: string;
            export declare const SoLuongToiDa: string;
            export declare const ChenhLech: string;
            export declare const FromTime: string;
            export declare const ToTime: string;
            export declare const DayOfWeek: string;
            export declare const EqualFromTime: string;
            export declare const EqualToTime: string;
        }

        ['Id', 'NgayGiao', 'GioGiao', 'KheThoiGian', 'SoLuong', 'SoLuongToiDa', 'ChenhLech', 'FromTime', 'ToTime', 'DayOfWeek', 'EqualFromTime', 'EqualToTime'].forEach(x => (<any>Fields)[x] = x);
    }
}

