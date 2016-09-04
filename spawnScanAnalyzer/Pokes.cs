using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace spawnScanAnalyzer
{
    class PokeList
    {
        List<Poke> pokes;

        public PokeList()
        {
            this.pokes = new List<Poke>();
        }

        public void Add(IEnumerable<Poke> _pokes)
        {
            foreach (Poke poke in _pokes)
            {
                this.pokes.Add(poke);
            }

        }
        public void Add(Poke poke)
        {
            this.pokes.Add(poke);
        }

        public void WriteAll(string filePath)
        {
            string headers = "Name,Dex#,SpawnID,CellId,Latitude,Longitude,Time\n";
            
            using(StreamWriter w = new StreamWriter(filePath,false))
            {
                w.Write(headers);

                foreach(Poke poke in this.pokes)
                {
                    w.Write(poke.WriteLine());
                }
            }

        }

    }
        class Poke
    {
        DateTime time;
        Species name;
        long id;
        string cell;
        string sid;
        double lat;
        double lng;

        public Poke(dynamic poke)
        {
            this.time = Helpers.FromUnixTime(poke["time"].Value).ToLocalTime();
            this.name = (Species)poke["pid"]-1;
            this.id = poke["pid"];
            this.cell = poke["cell"];
            this.sid = poke["sid"];
            this.lat = poke["lat"];
            this.lng = poke["lng"];
        }

        public string WriteLine()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}\n", this.name, this.id, this.sid, this.cell, this.lat, this.lng, this.time);
        }
    }
}
