using Serenity.Services;
using System;
using System.Collections.Generic;

namespace Serenity
{
    public class ListSelectedRequest : ListRequest
    {
        public string[] ListKeySelected { get; set; }
    }

    public class ListKeysRequest : ServiceRequest
    {
        public string[] Keys { get; set; }
    }

    public class GetDateTimeServerByTypeRequest : ServiceRequest
    {
        public string Type { get; set; }
    }

    public class GetDateTimeServerByTypeResponse : ServiceResponse
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }

    public class GetContactByGroupRequest : ServiceRequest
    {
        public string GroupCode { get; set; }
    }


    public class GetDateTimeServerRequest : ServiceRequest
    {
    }

    public class GetDateTimeServerResponse : ServiceResponse
    {
        public DateTime DateTimeNow { get; set; }
        public DateTime DateTimeTomorow { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateTomorow { get; set; }
    }

    public class ListCustomRequest : ListRequest
    {
        public string Type { get; set; }
    }

    public class POUpdateDeliveryDateRequest : ServiceRequest
    {
        public DateTime DeliveryDate { get; set; }
        public string[] Keys { get; set; }
        public String Note { get; set; }
    }

    public class BaseUpdateResponse : ServiceResponse
    {
        public int Updated { get; set; }
        public List<string> ErrorList { get; set; }
    }

    public class ExcelUpdateRequest : ServiceRequest
    {    
        public String FileName { get; set; }
    }

    public class CssVcmDanhSachPoResponse : ServiceResponse
    {
        public List<Dictionary<string, object>> Values { get; set; }
  
    }

    public class CssVcmDanhSachPoRequest : ServiceRequest
    {

    }
    public class ListKeysExRequest : ListRequest
    {
        public string[] Keys { get; set; }
    }
}