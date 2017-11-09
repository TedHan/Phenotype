using System;

namespace Phenotype.Models
{
    public class RequestResult
    {
        public RequestStatus Stat { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }

    public enum RequestStatus
    {
        NotAuth = -1,
        Success = 0,
        FormatInvalid = 1,
        DataInvalid = 2,
        DataExisted = 3,
        NotFound = 4,
        Failed = 5
    }
}