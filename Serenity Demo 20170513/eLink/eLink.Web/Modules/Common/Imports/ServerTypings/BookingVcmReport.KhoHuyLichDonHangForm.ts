namespace eLink.BookingVcmReport {
    export class KhoHuyLichDonHangForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.KhoHuyLichDonHang';

    }

    export interface KhoHuyLichDonHangForm {
        Note: Serenity.StringEditor;
    }

    [['Note', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(KhoHuyLichDonHangForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

