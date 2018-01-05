using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.CatsUI.Common
{
    public enum APIResponseType
    {
        Json
    }

    public static class AppHelper
    {
        public static async Task<string> APIGetData(string mediaType, string dataUrl, APIResponseType responseType)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Request Configuration                
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaType));

                HttpResponseMessage httpResponse = new HttpResponseMessage();
                httpResponse = httpClient.GetAsync(dataUrl).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    // TODO: Implement other types of responses not just JSON
                    switch (responseType)
                    {
                        case APIResponseType.Json:
                            string jsonStringResponse = await httpResponse.Content.ReadAsStringAsync();                                
                            return jsonStringResponse;
                        default:
                            throw new Exception("API response type not implemented");
                    }                                          
                }

                throw new Exception($"API call error: {httpResponse.StatusCode}");
            }
        }
    }
}
