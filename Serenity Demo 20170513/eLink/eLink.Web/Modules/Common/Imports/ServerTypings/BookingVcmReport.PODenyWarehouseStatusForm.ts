namespace eLink.BookingVcmReport {
    export class PODenyWarehouseStatusForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.PODenyWarehouseStatus';

    }

    export interface PODenyWarehouseStatusForm {
        Note: Serenity.StringEditor;
    }

    [['Note', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(PODenyWarehouseStatusForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

