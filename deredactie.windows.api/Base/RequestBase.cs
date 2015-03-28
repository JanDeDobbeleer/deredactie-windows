using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace deredactie.windows.api.Base
{
    public struct Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Trace
    }

    public abstract class RequestBase
    {
        protected async Task<Tuple<T, ResponseState>> RequestAsync<T>(string request, HttpMethod method, List<Parameter> parameters) where T : class, new()
        {
            var client = GetDefaultHttpClient();
            HttpResponseMessage response;
            switch (method)
            {
                case HttpMethod.Get:
                    response = await client.GetAsync(request + GetQueryRequestParameters(parameters));
                    break;
                default:
                    throw new NotImplementedException();
            }
            if(!response.IsSuccessStatusCode)
                return GetErrorTuple<T>("Failure", response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var payLoad = JsonConvert.DeserializeObject<T>(content);
                var state = new ResponseState()
                {
                    Message = "Success",
                    StatusCode = response.StatusCode
                };
                return new Tuple<T, ResponseState>(payLoad, state);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                return GetErrorTuple<T>(e.Message, response.StatusCode);
            }
        }

        private Tuple<T, ResponseState> GetErrorTuple<T>(string message, HttpStatusCode statusCode) where T : class, new()
        {
            return new Tuple<T, ResponseState>(default(T), new ResponseState
            {
                Message = message,
                StatusCode = statusCode
            });
        }

        private HttpClient GetDefaultHttpClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(GetBaseAddress())};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.Add("User-Agent", "deredactie/1.0.0 (Windows Phone; 8.1; Scale/2.00)");
            client.DefaultRequestHeaders.Add("platform", "Windows Phone");
            client.DefaultRequestHeaders.Add("appversion", "1.0.0");
            return client;
        }

        private string GetQueryRequestParameters(IList<Parameter> parameters)
        {
            if (parameters == null || !parameters.Any())
                return string.Empty;
            var sb = new StringBuilder();
            sb.Append("?");
            for (var i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }
            return sb.ToString();
        }

        protected abstract string GetBaseAddress();
    }
}
