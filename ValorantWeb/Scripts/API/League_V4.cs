using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using LOLWeb.Scripts.Data;

namespace LOLWeb.Scripts.API
{
    public class League_V4 : Api
    {
        public League_V4(string region) : base(region)
        {

        }

        public List<LeagueEntryDTO> SearchById(string id)
        {
            string path = "league/v4/entries/by-summoner/" + id;

            var response = GET(GetURL(path));
            //Get Return Type As String
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}