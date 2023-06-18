using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct joueurxResult
    {
        public string result;
        public Joueur joueur;
    }
    public class DetailsRencontre
    {
        private List<joueurxResult> _joueursDom;

        public List<joueurxResult> JoueursDom
        {
            get { return _joueursDom; }
            set { _joueursDom = value; }
        }

        private List<joueurxResult> _joueursExt;

        public List<joueurxResult> JoueursExt
        {
            get { return _joueursExt; }
            set { _joueursExt = value; }
        }

        public DetailsRencontre()
        {
            _joueursDom = new List<joueurxResult>();
            _joueursExt= new List<joueurxResult>();
        }
    }
}
