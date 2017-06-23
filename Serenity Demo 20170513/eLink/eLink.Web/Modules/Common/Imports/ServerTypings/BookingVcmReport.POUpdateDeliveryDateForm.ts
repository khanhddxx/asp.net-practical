namespace eLink.BookingVcmReport {
    export class POUpdateDeliveryDateForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.POUpdateDeliveryDate';

    }

    export interface POUpdateDeliveryDateForm {
        DeliveryDate: Serenity.DateTimeEditor;
        PODeliveryOnDay: Serenity.StringEditor;
        Note: Serenity.StringEditor;
    }

    [['DeliveryDate', () => Serenity.DateTimeEditor], ['PODeliveryOnDay', () => Serenity.StringEditor], ['Note', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(POUpdateDeliveryDateForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

