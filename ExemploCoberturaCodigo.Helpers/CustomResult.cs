using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Mvc;

namespace ExemploCoberturaCodigo.Helpers
{
    public class CustomResult : JsonResult
    {
        public CustomResult(HttpStatusCode statusCode, object data) : base(data) =>
           StatusCode = (int)statusCode;

        public CustomResult(HttpStatusCode statusCode) : base(null) =>
            StatusCode = (int)statusCode;
    }
}
