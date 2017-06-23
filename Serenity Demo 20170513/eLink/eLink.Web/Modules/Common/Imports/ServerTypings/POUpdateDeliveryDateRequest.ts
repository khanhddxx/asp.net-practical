namespace Serenity {
    export interface POUpdateDeliveryDateRequest extends Serenity.ServiceRequest {
        DeliveryDate?: string;
        Keys?: string[];
        Note?: string;
    }
}

