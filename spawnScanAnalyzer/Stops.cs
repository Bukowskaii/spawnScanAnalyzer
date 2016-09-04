using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spawnScanAnalyzer
{

    class StopList
    {
        List<Stop> stops;

        public StopList()
        {
            this.stops = new List<Stop>();
        }

        public void Add(IEnumerable<Stop> _stops)
        {
            foreach(Stop stop in _stops)
            {
                this.stops.Add(stop);
            }
        }
        public void Add(Stop stop)
        {
            this.Add(stop);
        }
        public void Unique()
        {
            List<string> ids = new List<string>();
            for (int i = this.stops.Count() - 1; i >= 0; i--)
            {
                if (ids.Contains(this.stops[i].id))
                {
                    this.stops.Remove(this.stops[i]);
                }
                else
                {
                    ids.Add(this.stops[i].id);
                }
            }
        }
        public void WriteAll(string filePath)
        {
            string headers = "StopId,Latitude,Longitude,Lured\n";

            using (StreamWriter w = new StreamWriter(filePath, false))
            {
                w.Write(headers);

                foreach (Stop stop in this.stops)
                {
                    w.Write(stop.WriteLine());
                }
            }

        }
    }

    class Stop
    {
        double lat;
        double lng;
        long lure;
        public string id;

        public Stop(dynamic stop)
        {
            this.lat = stop["lat"];
            this.lng = stop["lng"];
            this.lure = stop["lure"];
            this.id = stop["id"];
        }

        public string WriteLine()
        {
            return string.Format("{0},{1},{2},{3}\n", this.id, this.lat, this.lng, this.lure);
        }
    }
}
