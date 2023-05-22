using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AccesDB.TabTAPI;
using Model;

namespace AccesDB
{
    public static class AccesJoueur
    {
        public static Joueur getMainJoueur(string id)
        {
            TabTAPI_PortTypeClient client = new TabTAPI_PortTypeClient();

            string xmlRequest = "<GetMembersRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <UniqueIndex xmlns=\"http://api.frenoy.net/TabTAPI\">150121</UniqueIndex>\r\n  <RankingPointsInformation xmlns=\"http://api.frenoy.net/TabTAPI\">1</RankingPointsInformation>\r\n</GetMembersRequest>";

            GetMembersRequest requestJoueur = new GetMembersRequest();

            XmlSerializer serializer3 = new XmlSerializer(typeof(GetMembersRequest));
            using (StringReader reader = new StringReader(xmlRequest))
            {
                requestJoueur = (GetMembersRequest)serializer3.Deserialize(reader);
            }

            GetMembersResponse response = client.GetMembers(requestJoueur);


            Joueur joueur = new Joueur();

            joueur.Nom = response.MemberEntries[0].LastName;
            joueur.Prenom = response.MemberEntries[0].FirstName;
            joueur.Club = response.MemberEntries[0].Club;
            joueur.Classement = response.MemberEntries[0].Ranking;
            joueur.NbVictoires = 0; //a faire
            joueur.NbDefaites = 0; //a faire
            joueur.Points = int.Parse(response.MemberEntries[0].RankingPointsEntries[1].Value);
            joueur.Position = int.Parse(response.MemberEntries[0].RankingPointsEntries[2].Value);


            return joueur;

        }

        public static int test()
        {
            return 3;
        }

    }
}
