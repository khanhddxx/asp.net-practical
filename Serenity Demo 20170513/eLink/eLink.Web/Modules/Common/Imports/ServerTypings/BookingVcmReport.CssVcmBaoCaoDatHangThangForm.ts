namespace eLink.BookingVcmReport {
    export class CssVcmBaoCaoDatHangThangForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.CssVcmBaoCaoDatHangThang';

    }

    export interface CssVcmBaoCaoDatHangThangForm {
        NgayDatHang: Serenity.DateEditor;
        NgayThucNhan: Serenity.DateEditor;
        SkuKeHoach: Serenity.IntegerEditor;
        UnitKeHoach: Serenity.IntegerEditor;
        SkuThucNhan: Serenity.IntegerEditor;
        UnitThucNhan: Serenity.IntegerEditor;
        SkuChenhLech: Serenity.IntegerEditor;
        UnitChenhLech: Serenity.IntegerEditor;
        SkuTiLe: Serenity.DecimalEditor;
        UnitTiLe: Serenity.DecimalEditor;
        DeliveryInFullGrade: Serenity.StringEditor;
        DeliveryInTimeGrade: Serenity.StringEditor;
        GioGiao: Serenity.DateEditor;
        GioNhanThucTe: Serenity.DateEditor;
        ThoiGianTre: Serenity.StringEditor;
        GhiChuHenGiao: Serenity.StringEditor;
    }

    [['NgayDatHang', () => Serenity.DateEditor], ['NgayThucNhan', () => Serenity.DateEditor], ['SkuKeHoach', () => Serenity.IntegerEditor], ['UnitKeHoach', () => Serenity.IntegerEditor], ['SkuThucNhan', () => Serenity.IntegerEditor], ['UnitThucNhan', () => Serenity.IntegerEditor], ['SkuChenhLech', () => Serenity.IntegerEditor], ['UnitChenhLech', () => Serenity.IntegerEditor], ['SkuTiLe', () => Serenity.DecimalEditor], ['UnitTiLe', () => Serenity.DecimalEditor], ['DeliveryInFullGrade', () => Serenity.StringEditor], ['DeliveryInTimeGrade', () => Serenity.StringEditor], ['GioGiao', () => Serenity.DateEditor], ['GioNhanThucTe', () => Serenity.DateEditor], ['ThoiGianTre', () => Serenity.StringEditor], ['GhiChuHenGiao', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CssVcmBaoCaoDatHangThangForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

