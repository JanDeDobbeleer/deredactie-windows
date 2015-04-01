using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using deredactie.windows.api.Base;
using deredactie.windows.api.Model;

namespace deredactie.windows.api.Service
{
    public class NewsService : RequestBase
    {
          /*  
          @GET("/client/mvc/config/{channel}")
          public abstract void getConfig(@Header("platform") String paramString1, @Header("appversion") String paramString2, @Path("channel") String paramString3, Callback<ApplicationConfiguration> paramCallback);

          @GET("/client/mvc/apps/detail/{storyId}/{id}")
          public abstract void getDetail(@Path("storyId") String paramString1, @Path("id") String paramString2, @QueryMap Map<String, Object> paramMap, Callback<DetailResult> paramCallback);

          @GET("/client/mvc/apps/detail/{type}/{id}")
          public abstract void getDetail(@Path("id") String paramString1, @Path("type") String paramString2, Callback<ExtendedBundleDecorator> paramCallback);

          @GET("/client/mvc/apps/detail/{ids}")
          public abstract void getDetails(@Path("ids") String paramString, Callback<List<ExtendedBundleDecorator>> paramCallback);

          @GET("/client/mvc/apps/contents")
          public abstract void getFeed(@QueryMap Map<String, Object> paramMap, Callback<SearchResult> paramCallback);

          @GET("/client/mvc/apps/detail/StoryBundle/{id}")
          public abstract void getStoryDetail(@Path("id") String paramString, @QueryMap Map<String, Object> paramMap, Callback<BundleDecorator> paramCallback);
          */

        protected override string GetBaseAddress()
        {
            return "http://csclient.vrt.be";
        }

        public async Task<Tuple<ContentRoot, ResponseState>> GetFeedAsync()
        {
            var parameters = new Dictionary<string, string>
            {
                {"channel", "vrtnieuws"},
                {"descending", "true"},
                {"page", "0"}
            };
            return await RequestAsync<ContentRoot>("/client/mvc/apps/contents", HttpMethod.Get, parameters);
        } 
        
        public async Task<Tuple<ContentRoot, ResponseState>> GetConfigAsync()
        {
            //TODO: find the channel to complete the endpoint for this call
            return await RequestAsync<ContentRoot>(string.Format("/client/mvc/config/{0}", ""), HttpMethod.Get, null);
        } 
        
        public async Task<Tuple<ContentRoot, ResponseState>> GetDetail(long storyId, long id)
        {
            return await RequestAsync<ContentRoot>(string.Format("/client/mvc/apps/detail/{0}/{1}", storyId, id), HttpMethod.Get, null);
        }

        public async Task<Tuple<ContentRoot, ResponseState>> GetDetail(string type, long id, int numberOfSiblings, string function)
        {
            var parameters = new Dictionary<string, string>
            {
                {"numberOfSiblings", numberOfSiblings.ToString()},
                {"function", function}
            };
            return await RequestAsync<ContentRoot>(string.Format("/client/mvc/apps/detail/{0}/{1}", type, id), HttpMethod.Get, parameters);
        } 
        
        public async Task<Tuple<ContentRoot, ResponseState>> GetDetails(List<long> ids)
        {
            return await RequestAsync<ContentRoot>(string.Format("/client/mvc/apps/detail/{0}", string.Join(",", ids.ToArray())), HttpMethod.Get, null);
        } 
        
        public async Task<Tuple<ContentRoot, ResponseState>> GetStoryDetail(long id, int pageId)
        {
            var parameters = new Dictionary<string, string>
            {
                {"page", pageId.ToString()}
            };
            return await RequestAsync<ContentRoot>(string.Format("/client/mvc/apps/detail/StoryBundle/{0}", id), HttpMethod.Get, parameters);
        } 
    }
}
