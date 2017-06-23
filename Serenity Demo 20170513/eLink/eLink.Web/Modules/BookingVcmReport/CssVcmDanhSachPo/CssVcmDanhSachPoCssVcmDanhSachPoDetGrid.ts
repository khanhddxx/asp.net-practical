
namespace eLink.BookingVcmReport {

  @Serenity.Decorators.registerClass()
  export class CssVcmDanhSachPoCssVcmDanhSachPoDetGrid extends Serenity.EntityGrid<CssVcmDanhSachPoDetRow, any> {
    protected getColumnsKey() { return 'BookingVcmReport.CssVcmDanhSachPoDet'; }
    protected getIdProperty() { return CssVcmDanhSachPoDetRow.idProperty; }
    protected getLocalTextPrefix() { return CssVcmDanhSachPoDetRow.localTextPrefix; }
    protected getService() { return CssVcmDanhSachPoDetService.baseUrl; }

    constructor(container: JQuery) {
      super(container);
    }
    protected getButtons() {
      return null;
    }

    protected getGridCanLoad() {
      return this.maPo != null;
    }

    private _maPo: number;

    get maPo() {
      return this._maPo;
    }

    set maPo(value: number) {
      if (this._maPo != value) {
        this._maPo = value;
        this.setEquality(CssVcmDanhSachPoDetRow.Fields.MaPo, value);
        this.refresh();
      }
    }
  }
}