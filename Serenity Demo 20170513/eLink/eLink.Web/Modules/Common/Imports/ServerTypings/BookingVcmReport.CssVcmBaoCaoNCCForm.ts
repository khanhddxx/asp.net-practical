namespace eLink.BookingVcmReport {
    export class CssVcmBaoCaoNCCForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.CssVcmBaoCaoNCC';

    }

    export interface CssVcmBaoCaoNCCForm {
        Vendor: Serenity.StringEditor;
        Vendor_SupplyingSite: Serenity.StringEditor;
    }

    [['Vendor', () => Serenity.StringEditor], ['Vendor_SupplyingSite', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CssVcmBaoCaoNCCForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

