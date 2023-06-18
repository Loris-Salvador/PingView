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
                for(int j = 1; j <23; j++)
                {
                    
                    request.WeekName = j.ToString();

                    GetMatchesResponse response = client.GetMatches(request);


                    if (response.MatchCount != "0")
                    {
                        for (int k = 0; response.TeamMatchesEntries[0].IsValidated && !response.TeamMatchesEntries[0].IsAwayForfeited && !response.TeamMatchesEntries[0].IsHomeForfeited && k < int.Parse(response.TeamMatchesEntries[0].MatchDetails.HomePlayers.PlayerCount); k++)
                        {
                            try
                            {
                                if (!response.TeamMatchesEntries[0].MatchDetails.HomePlayers.Players[k].IsForfeited && response.TeamMatchesEntries[0].MatchDetails.HomePlayers.Players[k].UniqueIndex == "150121")
                                {
                                    Rencontre rencontre = new Rencontre();


                                    rencontre.Score = response.TeamMatchesEntries[0].Score;
                                    rencontre.EquipeDom = response.TeamMatchesEntries[0].HomeTeam;
                                    rencontre.EquipeExt = response.TeamMatchesEntries[0].AwayTeam;
                                    rencontre.WeekNumber = int.Parse(response.TeamMatchesEntries[0].WeekName);
                                    rencontre.UniqueMatchId = response.TeamMatchesEntries[0].MatchUniqueId;

                                    rencontres.Add(rencontre);

                                    break;
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        for (int k = 0; response.TeamMatchesEntries[0].IsValidated && !response.TeamMatchesEntries[0].IsAwayForfeited && !response.TeamMatchesEntries[0].IsHomeForfeited && k < int.Parse(response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.PlayerCount); k++)
                        { 
                            try
                            {
                                if (!response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.Players[k].IsForfeited && response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.Players[k].UniqueIndex == "150121")
                                {
                                    Rencontre rencontre = new Rencontre();


                                    rencontre.Score = response.TeamMatchesEntries[0].Score;
                                    rencontre.EquipeDom = response.TeamMatchesEntries[0].HomeTeam;
                                    rencontre.EquipeExt = response.TeamMatchesEntries[0].AwayTeam;
                                    rencontre.WeekNumber = int.Parse(response.TeamMatchesEntries[0].WeekName);
                                    rencontre.UniqueMatchId = response.TeamMatchesEntries[0].MatchUniqueId;


                                    rencontres.Add(rencontre);

                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                }
            }

            return rencontres;
        }

        public static Rencontre GetDetailsRencontre(Rencontre r)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            string xmlRequest = "<GetMatchesRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <WithDetails xmlns=\"http://api.frenoy.net/TabTAPI\">1</WithDetails>\r\n</GetMatchesRequest>";

            GetMatchesRequest request = new GetMatchesRequest();

            XmlSerializer serializer3 = new XmlSerializer(typeof(GetMatchesRequest));
            using (StringReader reader = new StringReader(xmlRequest))
            {
                request = (GetMatchesRequest)serializer3.Deserialize(reader);
            }

            request.Season = "23";
            request.MatchUniqueId = r.UniqueMatchId;

            Console.WriteLine(r.UniqueMatchId);

            GetMatchesResponse response = new GetMatchesResponse();

            response = client.GetMatches(request);

            //GERER les details LET's GOOOOOOOO



            for(int i=0; i < int.Parse(response.TeamMatchesEntries[0].MatchDetails.HomePlayers.PlayerCount); i++)
            {
                joueurxResult joueurxResult = new joueurxResult();

                Joueur j = new Joueur();
                j = GetJoueur.getJoueurWithIndex(response.TeamMatchesEntries[0].MatchDetails.HomePlayers.Players[i].UniqueIndex);

                joueurxResult.result = response.TeamMatchesEntries[0].MatchDetails.HomePlayers.Players[i].VictoryCount;

                joueurxResult.joueur = j;

                
                r.Details.JoueursDom.Add(joueurxResult);
                Console.WriteLine(r.Details.JoueursDom[i].joueur.Nom);
            }

            for (int i = 0; i < int.Parse(response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.PlayerCount); i++)
            {
                joueurxResult joueurxResult = new joueurxResult();

                Joueur j = new Joueur();
                j = GetJoueur.getJoueurWithIndex(response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.Players[i].UniqueIndex);

                joueurxResult.result = response.TeamMatchesEntries[0].MatchDetails.AwayPlayers.Players[i].VictoryCount;

                joueurxResult.joueur = j;

                r.Details.JoueursDom.Add(joueurxResult);

            }

            return r;

        }
    }
}
