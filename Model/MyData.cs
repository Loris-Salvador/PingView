using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyData
    {

        public ObservableCollection<Note> Notes;

        private string _index;

        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private MyData()
        {
            Notes = new ObservableCollection<Note>();
        }

        private static MyData Instance = new MyData();

        public static MyData getInstance()
        {
            return Instance;
        }


        public void Load()
        {
            Console.WriteLine("Load");
        }

        public void Save()
        {

        }

    }
}
