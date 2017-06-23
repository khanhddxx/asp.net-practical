namespace Serenity {
    export interface GetDateTimeServerResponse extends Serenity.ServiceResponse {
        DateTimeNow?: string;
        DateTimeTomorow?: string;
        Date?: string;
        DateTomorow?: string;
    }
}

