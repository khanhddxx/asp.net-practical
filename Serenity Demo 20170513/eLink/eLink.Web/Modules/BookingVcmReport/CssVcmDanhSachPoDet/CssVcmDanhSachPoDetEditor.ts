
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace eLink.BookingVcmReport {

    @Serenity.Decorators.registerClass()
    export class CssVcmDanhSachPoDetEditor extends Common.GridEditorBase<CssVcmDanhSachPoDetRow> {
        protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPoDet'; }
        protected getDialogType() { return CssVcmDanhSachPoDetDialog; }
        protected getLocalTextPrefix() { return CssVcmDanhSachPoDetRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getButtons() {
            return [];
        }
    }
}