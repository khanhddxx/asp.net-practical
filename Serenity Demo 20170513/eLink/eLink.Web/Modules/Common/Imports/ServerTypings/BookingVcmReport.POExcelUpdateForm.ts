namespace eLink.BookingVcmReport {
    export class POExcelUpdateForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.POExcelUpdate';

    }

    export interface POExcelUpdateForm {
        FileName: Serenity.ImageUploadEditor;
    }

    [['FileName', () => Serenity.ImageUploadEditor]].forEach(x => Object.defineProperty(POExcelUpdateForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

