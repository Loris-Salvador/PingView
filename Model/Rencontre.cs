using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rencontre
    {
        private string _equipeDom;

        public string EquipeDom
        {
            get { return _equipeDom; }
            set { _equipeDom = value; }
        }

        private string _uniqueMatchId;

        public string UniqueMatchId
        {
            get { return this._uniqueMatchId; }
            set { _uniqueMatchId = value; }
        }

        private int _weekNumber;

        public int WeekNumber
        {
            get { return _weekNumber; }
            set { _weekNumber = value; }
        }

        private string _equipeExt;

        public string EquipeExt
        {
            get { return _equipeExt; }
            set { _equipeExt = value; }
        }


        private string _score;

        public string Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private string _scoreHome;

        public string ScoreHome
        {
            get { return _scoreHome; }
            set { _scoreHome = value; }
        }

        private string _scoreAway;

        public string ScoreAway
        {
            get { return _scoreAway; }
            set { _scoreAway = value; }
        }
        




        private DetailsRencontre _details;

        public DetailsRencontre Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public Rencontre()
        {
            EquipeDom = "";
            EquipeExt = "";
            Score = "";
            Details = new DetailsRencontre();
        }

        public Rencontre(string equipeDom, string equipeExt, string s, DetailsRencontre d)
        {
            EquipeDom = equipeDom;
            EquipeExt = equipeExt;
            Score = s;
            Details = d;
        }

        public override string ToString()
        {
            return EquipeDom + "  " + Score + "  " + EquipeExt;
        }
    }
}
