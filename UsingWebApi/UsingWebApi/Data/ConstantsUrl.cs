using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebApi.Data
{
    public class ConstantsUrl
    {
        public const String REST_SERVICE_URL = "http://localhost:55556/api/";
        public const String ORDER = REST_SERVICE_URL + "order";
        public const String CUSTOMER = REST_SERVICE_URL + "customer";
        public const String SERVICETYPES = REST_SERVICE_URL + "servicetypes";
        public const String ERROR_MESSAGE = "Unable to connect to server. Please return later!";
    }
}
