using System.Net;
using System.Net.Http;

namespace deredactie.windows.api.Base
{
    public class ResponseState
    {
        public HttpStatusCode StatusCode { get; set; } 
        public string Message { get; set; } 
        
    }
}