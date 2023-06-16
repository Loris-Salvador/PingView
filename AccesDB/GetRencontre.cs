using AccesDB.TabTAPI;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccesDB
{
    public static class GetRencontre
    {
        public static ObservableCollection<Rencontre> GetRencontresJoueur(Joueur joueur)
        {
            List<string> _divisions = GetDivision.GetDivisionsWithClub(joueur.ClubIndex);

            ObservableCollection<Rencontre> rencontres = new ObservableCollection<Rencontre>();

            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            string xmlRequest = "<GetMatchesRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <WithDetails xmlns=\"http://api.frenoy.net/TabTAPI\">1</WithDetails>\r\n</GetMatchesRequest>";

            GetMatchesRequest request = new GetMatchesRequest();

            XmlSerializer serializer3 = new XmlSerializer(typeof(GetMatchesRequest));
            using (StringReader reader = new StringReader(xmlRequest))
            {
                request = (GetMatchesRequest)serializer3.Deserialize(reader);
            }

            request.Season = "23";
            request.Club = joueur.ClubIndex;    


            for(int i = 0; i < _divisions.Count; i++)
            {
                request.DivisionId = _divisions[i];
                for(int j = 1; j <20; j++)
                {
                    
                    request.WeekName = j.ToString();

                    GetMatchesResponse response = client.GetMatches(request);


                    if (response.MatchCount != "0")
                    {
                        for (int k = 0; response.TeamMatchesEntries[0].IsValidated && !response.TeamMatchesEntries[0].IsAwayForfeited && !response.TeamMatchesEntries[0].IsHomeForfeited && k < int.Parse(response.TeamMatchesEntries[0].MatchDetails.HomePlayers.PlayerCount); k++)
                        {
                            if (response.TeamMatchesEntries[0].MatchDetails.HomePlayers.Players[k].UniqueIndex == "150121" || response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.Players[k].UniqueIndex == "150121")
                            {
                                Rencontre rencontre = new Rencontre();


                                rencontre.Score = response.TeamMatchesEntries[0].Score;
                                rencontre.EquipeDom = response.TeamMatchesEntries[0].HomeTeam;
                                rencontre.EquipeExt = response.TeamMatchesEntries[0].AwayTeam;

                                rencontres.Add(rencontre);

                                break;
                            }
                        }
                    }
                }
            }

            return rencontres;

            
        }
    }
}
