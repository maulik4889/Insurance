using System;
using System.Net;
using System.Runtime.Serialization;

namespace Insurance.Domain.Exceptions
{
    [Serializable]
    public partial class InsuranceException : System.Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public int Code { get; private set; }

        private InsuranceException(string message, int code = 1000, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Code = code;
        }
    }
}
