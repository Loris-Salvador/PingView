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
            }
        }

        public void Save(string filename)
        {
            MyData dataToSave = new MyData
            {
                Index = Index,
                Notes = new ObservableCollection<Note>(Notes)
            };

            string jsonData = JsonConvert.SerializeObject(dataToSave);
            File.WriteAllText(filename, jsonData);


        }

    }
}
