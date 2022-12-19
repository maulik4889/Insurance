using System;
using System.Net;

namespace Insurance.Domain.Exceptions
{
    public partial class InsuranceException
    {
        //Note : Range for NotFoundException 5000 < Code < 6000
        private static InsuranceException NotFoundException(string message, int code)
        {
            return new InsuranceException(message, code, HttpStatusCode.NotFound);
        }

        public static readonly InsuranceException NotFound = NotFoundException("Not found", 1001);
    }
}
