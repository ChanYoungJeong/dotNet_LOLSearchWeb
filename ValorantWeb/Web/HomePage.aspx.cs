using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using LOLWeb.Scripts.API;
using LOLWeb.Scripts.Data;
using System.Drawing;

namespace ValorantWeb.Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        string name = "Null";
        string region = "Null";
        List<string> matches;
        string history = "";
        double trollScore = 0;  //Y val
        double trollPoint = 0;  //X val

        //Apis
        Match_V5 matchV5;

        //Models
        SummonerDTO summonerDTO;
        LeagueEntryDTO leagueEntryDTO;
        MatchDto matchDTO;
        InfoDto infoDTO;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Component Region           
            region = Request.QueryString["region"];
            name = Request.QueryString["inputField"];

            if (name != null && region != null)
            {
                Summoner_V4 sumV4 = new Summoner_V4(region);

                if (sumV4.SearchSummonerByName(name) != null)
                {
                    //Set SummonerDTO
                    summonerDTO = sumV4.SearchSummonerByName(name);
                    //Set LeagureEntryDTO
                    leagueEntryDTO = GetLeague(region, summonerDTO.id);
                    //Change Summoners' data
                    icon.Attributes["src"] = ResolveUrl(getIcons(summonerDTO.profileIconId));   //Icon
                    userName.InnerHtml = summonerDTO.name;                                      //Name
                    System.Diagnostics.Debug.WriteLine(leagueEntryDTO);
                    level.InnerText = "Lv." + summonerDTO.summonerLevel.ToString();


                    if (leagueEntryDTO != null)
                    {
                        rank.InnerText = leagueEntryDTO.tier + " " + leagueEntryDTO.rank + " " + leagueEntryDTO.leaguePoints;
                        emblem.Attributes["src"] = "../Assets/emblems/Emblem_" + leagueEntryDTO.tier + ".png";
                        winLose.InnerText = "Wins : " + leagueEntryDTO.wins + " / " + "Loses : " + leagueEntryDTO.losses;
                        GetMatchData();
                    }
                    else
                    {
                        rank.InnerText = "Unranked";
                        trollProb.InnerText = "Unknown";
                    }


                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("NotFound.");
                }
            }



        }

        protected string getIcons(int iconCode)
        {

            var url = "https://ddragon.leagueoflegends.com/cdn/13.9.1/img/profileicon/";
            var ext = ".png";

            return url + iconCode + ext;
        }

        protected LeagueEntryDTO GetLeague(string region, string id)
        {
            League_V4 lgV4 = new League_V4(region);
            var data = lgV4.SearchById(id).Where(p => p.queueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault(); ;

            return data;

        }

        protected List<string> GetMatches(string puuid, string region)
        {
            string route = "Null";

            if (region == "NA1" || region == "BR1")
                route = "AMERICAS";
            else if (region == "KR" || region == "JP1")
                route = "ASIA";
            else if (region == "EUN1" || region == "EUW1")
                route = "EUROPE";

            matchV5 = new Match_V5(route);
            List<string> match = matchV5.MatchList(puuid);

            return match;
        }

        protected void GetMatchData()
        {
            int playerIndex = -1;
            trollPoint = 0;
            history = "";
            matches = GetMatches(summonerDTO.puuid, region);

            //Calculate trollPoint by Losses and Wins
            if (leagueEntryDTO.losses - leagueEntryDTO.wins > 0)
            {
                trollPoint += leagueEntryDTO.wins - leagueEntryDTO.losses;
            }


            for (int i = 0; i < matches.Count; i++)
            {
                matchDTO = matchV5.MatchData(matches[i]);
                if (matchDTO.info.gameMode != "CLASSIC")
                    continue;

                //find current player's index number from match data's participant list
                playerIndex = matchDTO.metaData.participants.IndexOf(summonerDTO.puuid);
                AnalyzePlayerByMatchData(playerIndex);
            }
            CalculateTrollScore(trollPoint);    
        }

        protected void AnalyzePlayerByMatchData(int playerIndex)
        {
            
            InfoDto.ParticipantDto currentPlayer = new InfoDto.ParticipantDto();
            currentPlayer = matchDTO.info.participants[playerIndex];

            double kda;
            if (currentPlayer.deaths == 0)
                kda = (double)(currentPlayer.kills + currentPlayer.assists) / (double)(currentPlayer.deaths + 1);
            else
                kda = (double)(currentPlayer.kills + currentPlayer.assists) / (double)(currentPlayer.deaths);

            if (kda < 2.5)
            {
                trollPoint += (2.5 - kda) * 10;
            }
            else
            {
                trollPoint -= (kda - 2.5);
            }

            string strKDA = string.Format("{0: 0.00#}", kda);

            history += "Lane : " + currentPlayer.lane + " , KDA : " + strKDA + "<br />";
        }

        public void CalculateTrollScore(double trollPoint)
        {
            string output;
            trollScore += 100 * (1 - Math.Pow(2, (-trollPoint) / 200));
            output = string.Format("{0: 0.00#}", trollScore);
            trollProb.InnerText = output + "%";
            matchHistory.InnerHtml = history;
        }

    }
}