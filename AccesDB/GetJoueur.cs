using AccesDB.TabTAPI;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccesDB
{
    public static class GetJoueur
    {
        public static Joueur getJoueurWithIndex(string id)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            string xmlRequest = "<GetMembersRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <UniqueIndex xmlns=\"http://api.frenoy.net/TabTAPI\">" + id + "</UniqueIndex>\r\n  <RankingPointsInformation xmlns=\"http://api.frenoy.net/TabTAPI\">1</RankingPointsInformation>\r\n  <WithResults xmlns=\"http://api.frenoy.net/TabTAPI\">1</WithResults>\r\n</GetMembersRequest>";

            GetMembersRequest requestJoueur = new GetMembersRequest();

            XmlSerializer serializer3 = new XmlSerializer(typeof(GetMembersRequest));
            using (StringReader reader = new StringReader(xmlRequest))
            {
                requestJoueur = (GetMembersRequest)serializer3.Deserialize(reader);
            }

            requestJoueur.Season = "23";

            GetMembersResponse response = client.GetMembers(requestJoueur);

            Joueur joueur = new Joueur();

            int victoires = 0;
            int defaites = 0;

            for(int i=0; i< int.Parse(response.MemberEntries[0].ResultCount);i++)
            {
                if (response.MemberEntries[0].ResultEntries[i].Result == ResultType.V)
                    victoires++;
                else
                    defaites++;

            }


            joueur.Nom = response.MemberEntries[0].LastName;
            joueur.Prenom = response.MemberEntries[0].FirstName;
            joueur.Club = GetClub.GetClubWithIndex(response.MemberEntries[0].Club);
            joueur.Classement = response.MemberEntries[0].Ranking;
            joueur.NbVictoires = victoires;
            joueur.NbDefaites = defaites;
            joueur.Points = int.Parse(response.MemberEntries[0].RankingPointsEntries[1].Value);
            joueur.Position = int.Parse(response.MemberEntries[0].RankingPointsEntries[2].Value);

            return joueur;
        }
    }
}
