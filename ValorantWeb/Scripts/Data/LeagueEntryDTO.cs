using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOLWeb.Scripts.Data
{
    public class LeagueEntryDTO
    {
        public string leagueId { get; set; }
        public string summonerId { get; set; } //Player's encrypted summonerId
        public string summonerName { get; set; }
        public string queueType { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
    }
}