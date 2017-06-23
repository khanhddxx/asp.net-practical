namespace eLink.BookingVcmReport {
    export class POExcelUpdateThongTinKhoXacNhanForm extends Serenity.PrefixedContext {
        static formKey = 'BookingVcmReport.POExcelUpdateThongTinKhoXacNhan';

    }

    export interface POExcelUpdateThongTinKhoXacNhanForm {
        FileName: Serenity.ImageUploadEditor;
    }

    [['FileName', () => Serenity.ImageUploadEditor]].forEach(x => Object.defineProperty(POExcelUpdateThongTinKhoXacNhanForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

