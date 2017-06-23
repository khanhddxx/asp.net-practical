namespace eLink.BookingVcmReport {
    export class POExcelImportForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.POExcelImport';

    }

    export interface POExcelImportForm {
        FileName: Serenity.ImageUploadEditor;
    }

    [['FileName', () => Serenity.ImageUploadEditor]].forEach(x => Object.defineProperty(POExcelImportForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

