using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jeu_1
{
    public class Zone
    {   //Variables
        private string _name;
        private int position;
        private int _minLvl;
        private int _maxLvl;

        //Getters / Setters
        public string Name { get { return _name; } set { _name = value; } }
        public int Position { get { return position; } set { position = value; } }
        public int MinLvl { get { return _minLvl; } set { _minLvl = value; } }
        public int MaxLvl { get { return _maxLvl; } set { _maxLvl = value; } }

        //Methods
        public static List<Zone> GetZoneData()
        {
            string CurrentDirectory = Environment.CurrentDirectory;
            string path = @"/ZoneData.json";
            string fullPath = CurrentDirectory + path;
            StreamReader r = new StreamReader(fullPath);
            string jsonString = r.ReadToEnd();
            List<Zone> ZoneList = JsonConvert.DeserializeObject<List<Zone>>(jsonString);
            return ZoneList;
        }
    }
}
