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

        public async Task<Tuple<ContentRoot, ResponseState>> GetContentAsync()
        {
            var parameters = new Dictionary<string, string>
            {
                {"channel", "vrtnieuws"},
                {"descending", "true"},
                {"page", "0"}
            };
            return await RequestAsync<ContentRoot>("/client/mvc/apps/contents", HttpMethod.Get, parameters);
        } 
    }
}
