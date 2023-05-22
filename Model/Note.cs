using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Note
    {
        private string _nom;

        public string Nom
        {
            set { _nom = value; }
            get { return _nom; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public Note()
        {
            _nom = "pas de nom";
            _description = "pas de description";
        }

    }
}
