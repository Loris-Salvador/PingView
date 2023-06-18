using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Model
{
    public class MyData
    {

        private ObservableCollection<Note> _notes;

        public ObservableCollection<Note> Notes
        {
            get
            {
                return _notes;
            }
            set { _notes = value; }
        }

        private ObservableCollection<Rencontre> _rencontres;

        public ObservableCollection<Rencontre> Rencontres
        {
            get
            {
                return _rencontres;
            }
            set { _rencontres = value; }
        }


        private string _index;

        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private MyData()
        {
            Notes = new ObservableCollection<Note>();
            Rencontres = new ObservableCollection<Rencontre>();
        }

        private static MyData Instance = new MyData();

        public static MyData getInstance()
        {
            return Instance;
        }


        public void Load(string filename)
        {
            string jsonData = File.ReadAllText(filename);
            MyData loadedData = JsonConvert.DeserializeObject<MyData>(jsonData);

            if (loadedData != null)
            {
                Index = loadedData.Index;
                Notes.Clear();
                foreach (Note note in loadedData.Notes)
                {
                    Notes.Add(note);
                }
                Rencontres.Clear();
                foreach (Rencontre r in loadedData.Rencontres)
                {
                    Rencontres.Add(r);
                }
            }
        }

        public void Save(string filename)
        {
            MyData dataToSave = MyData.getInstance(); // Utiliser l'instance existante

            dataToSave.Index = Index;
            dataToSave.Notes = new ObservableCollection<Note>(Notes);
            //
            dataToSave.Rencontres = new ObservableCollection<Rencontre>(Rencontres);
            //

            string jsonData = JsonConvert.SerializeObject(dataToSave);
            File.WriteAllText(filename, jsonData);
        }


    }
}
