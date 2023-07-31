using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LOLWeb.Scripts.Data
{
    public class SummonerDTO
    {
        public string accountId { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string puuid { get; set; }
        public long summonerLevel { get; set; }

        /*
        public SummonerDTO(string _accountId, int _profileIconId, long _revisionDate, 
                           string _name, string _id, string _puuid, long _summonerLevel)
        {
            accountId = _accountId;
            profileIconId = _profileIconId;
            revisionDate = _revisionDate;
            name = _name;
            id = _id;
            puuid = _puuid;
            summonerLevel = _summonerLevel;
        }
        */

        public SummonerDTO(string _name)
        {
            name = _name;
        }
    }
}