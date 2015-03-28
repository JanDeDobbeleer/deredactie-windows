using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using deredactie.windows.api.Base;
using deredactie.windows.api.Model;

namespace deredactie.windows.api.Service
{
    public class NewsService : RequestBase
    {
        protected override string GetBaseAddress()
        {
            return "http://csclient.vrt.be";
        }

        public async Task<Tuple<ContentRoot, ResponseState>> GetContentAsync()
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "channel", Value = "vrtnieuws" },
                new Parameter {Name = "descending", Value = "true" },
                new Parameter {Name = "page", Value = "0" }
            };
            return await RequestAsync<ContentRoot>("/client/mvc/apps/contents", HttpMethod.Get, parameters);
        } 
    }
}
