using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOLWeb.Scripts.Data
{
    public class InfoDto
    {
        
        public List<ParticipantDto> participants { get; set; }
        public class ParticipantDto
        {
            public string lane { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int goldEarned { get; set; }
            public int goldSpent { get; set; }
            public int totalDamageDealtToChampions { get; set; }
            public int totalDamageTaken { get; set; }
            public int visionScore { get; set; }
            public int longestTimeSpentLiving { get; set; }
            public int timePlayed { get; set; }
            public int totalTimeSpendDead { get; set; }
        }
        
        public string gameMode { get; set; }


    }
}