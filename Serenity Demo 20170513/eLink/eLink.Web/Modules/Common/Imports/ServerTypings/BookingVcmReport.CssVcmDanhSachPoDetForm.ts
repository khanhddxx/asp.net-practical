namespace eLink.BookingVcmReport {
    export class CssVcmDanhSachPoDetForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.CssVcmDanhSachPoDet';

    }

    export interface CssVcmDanhSachPoDetForm {
        OrderQuantity: Serenity.DecimalEditor;
    }

    [['OrderQuantity', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(CssVcmDanhSachPoDetForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

