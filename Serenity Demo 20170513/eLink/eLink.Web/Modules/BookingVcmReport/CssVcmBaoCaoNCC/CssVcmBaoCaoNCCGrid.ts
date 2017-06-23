
namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class CssVcmBaoCaoNCCGrid extends Serenity.EntityGrid<CssVcmBaoCaoNCCRow, any> {
    protected getColumnsKey() { return 'BookingVcmReport.CssVcmBaoCaoNCC'; }
    protected getDialogType() { return CssVcmBaoCaoNCCDialog; }
    protected getIdProperty() { return CssVcmBaoCaoNCCRow.idProperty; }
    protected getLocalTextPrefix() { return CssVcmBaoCaoNCCRow.localTextPrefix; }
    protected getService() { return CssVcmBaoCaoNCCService.baseUrl; }

    constructor(container: JQuery) {
      super(container);
    }

    protected getButtons(): Serenity.ToolButton[] {
      const buttons = [];
      return buttons;
    }
  }
}