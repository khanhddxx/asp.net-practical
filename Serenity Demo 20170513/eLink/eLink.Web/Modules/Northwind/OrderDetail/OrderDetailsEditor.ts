/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace eLink.Northwind {

    @Serenity.Decorators.registerClass()
    export class OrderDetailsEditor extends Common.GridEditorBase<OrderDetailRow> {
        protected getColumnsKey() { return "Northwind.OrderDetail"; }
        protected getDialogType() { return OrderDetailDialog; }
        protected getLocalTextPrefix() { return OrderDetailRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

    
    }
}