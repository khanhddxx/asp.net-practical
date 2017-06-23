namespace eLink.BookingVcmReport {
    export class CssVcmBaoCaoDatHangKheThoiGianForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian';

    }

    export interface CssVcmBaoCaoDatHangKheThoiGianForm {
        NgayGiao: Serenity.DateEditor;
        KheThoiGian: Serenity.StringEditor;
        SoLuong: Serenity.IntegerEditor;
        SoLuongToiDa: Serenity.IntegerEditor;
        ChenhLech: Serenity.IntegerEditor;
        GioGiao: Serenity.DateEditor;
    }

    [['NgayGiao', () => Serenity.DateEditor], ['KheThoiGian', () => Serenity.StringEditor], ['SoLuong', () => Serenity.IntegerEditor], ['SoLuongToiDa', () => Serenity.IntegerEditor], ['ChenhLech', () => Serenity.IntegerEditor], ['GioGiao', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(CssVcmBaoCaoDatHangKheThoiGianForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

