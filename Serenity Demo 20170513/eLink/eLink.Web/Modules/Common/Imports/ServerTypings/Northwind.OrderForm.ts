namespace eLink.Northwind {
    export class OrderForm extends Serenity.PrefixedContext {
        static formKey = 'Northwind.Order';

    }

    export interface OrderForm {
        DetailList: OrderDetailsEditor;
    }

    [['DetailList', () => OrderDetailsEditor]].forEach(x => Object.defineProperty(OrderForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

