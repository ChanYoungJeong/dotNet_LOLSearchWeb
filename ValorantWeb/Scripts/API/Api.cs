using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;

namespace LOLWeb.Scripts.API
{
    public class Api
    {
        private string key;
        public string region;

        public Api(string _region)
        {
            region = _region;
            key = "RGAPI-d9b41b17-cf1b-427f-8ba8-623f7daf714e";
        }

        protected HttpResponseMessage GET(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url);
                result.Wait();

                return result.Result;
            }
        }

        public string GetURL(string path)
        {
            return "https://" + region + ".api.riotgames.com/lol/" + path + "?api_key=" + key;
        }

        //Will use for key for path text
        public string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}