namespace Serenity {
    export interface BaseUpdateResponse extends Serenity.ServiceResponse {
        Updated?: number;
        ErrorList?: string[];
    }
}

