using AccesDB.TabTAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesDB
{
    public static class GetClub
    {
        public static string GetClubWithIndex(string indice)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            GetClubs f = new GetClubs();

            f.Club = indice;

            GetClubsResponse response = client.GetClubs(f);

            return response.ClubEntries[0].LongName;

        }

        public static List<string> GetListeClubWithCategory(string category)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            List<string> listeIndice = new List<string>();

            GetClubs request = new GetClubs();

            request.ClubCategory = category;

            GetClubsResponse response = client.GetClubs(request);

            for (int i = 0; i < int.Parse(response.ClubCount); i++)
            {
                Console.WriteLine(response.ClubEntries[i].UniqueIndex + " " +  response.ClubEntries[i].UniqueIndex.Length);
                listeIndice.Add(response.ClubEntries[i].UniqueIndex);
            }

            return listeIndice;
        }
    }
}
