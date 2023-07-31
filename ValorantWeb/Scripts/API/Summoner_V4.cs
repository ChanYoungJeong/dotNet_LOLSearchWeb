using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using LOLWeb.Scripts.Data;

namespace LOLWeb.Scripts.API
{
    public class Summoner_V4 : Api
    {
        //Call Api.Api(region)
        public Summoner_V4(string region) : base(region)
        {
        }

        public SummonerDTO SearchSummonerByName(string SummonerName)
        {
            string path = "summoner/v4/summoners/by-name/" + SummonerName;

            var response = GET(GetURL(path));
            //Get Return Type As String
            string content = response.Content.ReadAsStringAsync().Result;

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SummonerDTO>(content);               
            }
            else
            {
                return null;
            }
        }
    }
}