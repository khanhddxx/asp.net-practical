
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class CssVcmDanhSachPoEditor extends Common.GridEditorBase<CssVcmDanhSachPoRow> {
    protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPo'; }
    protected getDialogType() { return CssVcmDanhSachPoDialog; }
    protected getLocalTextPrefix() { return CssVcmDanhSachPoRow.localTextPrefix; }

    constructor(container: JQuery) {
        super(container);       
    }
  }
}