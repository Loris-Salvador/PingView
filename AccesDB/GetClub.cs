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
    }
}
