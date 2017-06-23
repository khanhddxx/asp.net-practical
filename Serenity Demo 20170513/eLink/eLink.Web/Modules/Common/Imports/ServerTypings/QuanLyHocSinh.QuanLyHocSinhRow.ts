namespace eLink.QuanLyHocSinh {
    export interface QuanLyHocSinhRow {
        Id?: number;
        MaHs?: string;
        TenHs?: string;
        InsertDate?: string;
        InsertTime?: string;
        InsertUser?: string;
    }

    export namespace QuanLyHocSinhRow {
        export const idProperty = 'Id';
        export const nameProperty = 'MaHs';
        export const localTextPrefix = 'QuanLyHocSinh.QuanLyHocSinh';

        export namespace Fields {
            export declare const Id: string;
            export declare const MaHs: string;
            export declare const TenHs: string;
            export declare const InsertDate: string;
            export declare const InsertTime: string;
            export declare const InsertUser: string;
        }

        ['Id', 'MaHs', 'TenHs', 'InsertDate', 'InsertTime', 'InsertUser'].forEach(x => (<any>Fields)[x] = x);
    }
}

