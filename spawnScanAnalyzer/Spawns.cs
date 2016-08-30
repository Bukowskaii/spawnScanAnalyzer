using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spawnScanAnalyzer
{
    class SpawnList
    {
        List<Spawn> spawns;

        public SpawnList()
        {
            this.spawns = new List<Spawn>();
        }

        public void Add(IEnumerable<Spawn> _spawns)
        {
            foreach (Spawn spawn in _spawns)
            {
                this.spawns.Add(spawn);
            }

        }
        public void Add(Spawn spawn)
        {
            this.spawns.Add(spawn);
        }

        public void WriteAll(string filePath)
        {
            string headers = "SpawnID,CellId,Latitude,Longitude,Time\n";

            using (StreamWriter w = new StreamWriter(filePath, false))
            {
                w.Write(headers);

                foreach (Spawn spawn in this.spawns)
                {
                    w.Write(spawn.WriteLine());
                }
            }

        }

    }
    class Spawn
    {
        double lat;
        double lng;
        string cell;
        string sid;
        int time;

        public Spawn(dynamic spawn)
        {
            this.lat = spawn["lat"];
            this.lng = spawn["lng"];
            this.cell = spawn["cell"];
            this.sid = spawn["sid"];
            this.time = spawn["time"];
        }

        public string WriteLine()
        {
            return string.Format("{0},{1},{2},{3},{4}\n", this.sid, this.cell, this.lat, this.lng, this.time);
        }
    }
}
