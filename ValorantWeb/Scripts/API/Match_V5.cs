using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using LOLWeb.Scripts.Data;

namespace LOLWeb.Scripts.API
{
    public class Match_V5 : Api
    {

        public Match_V5(string region) : base(region)
        {
        }

        public List<string> MatchList(string puuid)
        {
            string path = "match/v5/matches/by-puuid/" + puuid + "/ids";

            var response = GET(GetURL(path));
            //Get Return Type As String
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
            else
            {
                return null;
            }
        }

        public MatchDto MatchData(string matchId)
        {
            string path = "match/v5/matches/" + matchId;

            var response = GET(GetURL(path));
            //Get Return Type As String
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MatchDto>(content);
            }
            else
            {
                return null;
            }
        }
    }
}