using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct joueurxResult
    {
        public int result;
        public Joueur Joueur;
    }
    public class DetailsRencontre
    {
        private List<joueurxResult> _joueursDom = new List<joueurxResult>();

        public List<joueurxResult> JoueursDom
        {
            get { return _joueursDom; }
            set { _joueursDom = value; }
        }

        private List<joueurxResult> _joueursExt = new List<joueurxResult>();

        public List<joueurxResult> JoueursExt
        {
            get { return _joueursExt; }
            set { _joueursExt = value; }
        }

        private List<string[]> _tabResultat = new List<string[]>();

        public List<string[]> TabResultat
        {
            get { return _tabResultat; }
            set { _tabResultat = value; }
        }

        public DetailsRencontre()
        {
            for (int i = 0; i < 4; i++)
            {
                JoueursDom.Add(new joueurxResult());
                JoueursExt.Add(new joueurxResult());
            }

            for (int i = 0; i < 5; i++)
            {
                TabResultat.Add(new string[5]);
            }
        }
    }
}
