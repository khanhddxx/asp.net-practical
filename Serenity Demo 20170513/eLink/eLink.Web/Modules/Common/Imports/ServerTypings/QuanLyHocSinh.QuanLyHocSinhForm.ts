namespace eLink.QuanLyHocSinh {
    export class QuanLyHocSinhForm extends Serenity.PrefixedContext {
        static formKey = 'QuanLyHocSinh.QuanLyHocSinh';

    }

    export interface QuanLyHocSinhForm {
        MaHs: Serenity.StringEditor;
        TenHs: Serenity.StringEditor;
        InsertDate: Serenity.DateEditor;
        InsertTime: Serenity.DateEditor;
        InsertUser: Serenity.StringEditor;
    }

    [['MaHs', () => Serenity.StringEditor], ['TenHs', () => Serenity.StringEditor], ['InsertDate', () => Serenity.DateEditor], ['InsertTime', () => Serenity.DateEditor], ['InsertUser', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(QuanLyHocSinhForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

