namespace eLink.BookingVcmReport {
    export class CssVcmDanhSachPoForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.CssVcmDanhSachPo';

    }

    export interface CssVcmDanhSachPoForm {
    }

    [].forEach(x => Object.defineProperty(CssVcmDanhSachPoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

