using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using AccesDB;
using FonctionUtil;
using TestUtilitaire.TabTAPI;

namespace TestUtilitaire
{
    public class Program
    {
        static void Main(string[] args)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            GetMatchesRequest request = new GetMatchesRequest();

            request.Club = "L264";
            request.Season = "23";
            request.WeekName = "1";
            //request.DivisionId = "6428";

            List<Rencontre> rencontres = new List<Rencontre>();

            GetMatchesResponse response = client.GetMatches(request);

            for (int i = 0; i < int.Parse(response.MatchCount); i++)
            {
                Rencontre rencontre = new Rencontre();


                rencontre.Score = response.TeamMatchesEntries[i].Score;
                rencontre.EquipeDom = response.TeamMatchesEntries[i].HomeTeam;
                rencontre.EquipeExt = response.TeamMatchesEntries[i].AwayTeam;
                string division = response.TeamMatchesEntries[i].DivisionId;


                rencontres.Add(rencontre);

                Console.WriteLine(rencontre + "Division : " + division);
            }

            Console.ReadKey();
        }
    }
}
