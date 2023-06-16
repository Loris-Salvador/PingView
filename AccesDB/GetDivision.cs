using AccesDB.TabTAPI;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDB
{
    public static class GetDivision
    {
        public static List<string> GetDivisionsWithClub(string club)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            GetMatchesRequest request = new GetMatchesRequest();

            request.Club = club;
            request.Season = "23";
            request.WeekName = "1";

            List<string> divisions = new List<string>();

            GetMatchesResponse response = client.GetMatches(request);

            for (int i = 0; i < int.Parse(response.MatchCount); i++)
            {
                string division = response.TeamMatchesEntries[i].DivisionId;

                divisions.Add(division);
            }

            return divisions;
        }
    }
}
