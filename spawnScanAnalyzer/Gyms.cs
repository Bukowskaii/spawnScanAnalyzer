using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spawnScanAnalyzer
{
    class GymList
    {
        List<Gym> gyms;

        public GymList()
        {
            this.gyms = new List<Gym>();
        }

        public void Add(IEnumerable<Gym> _gyms)
        {
            foreach (Gym gym in _gyms)
            {
                this.gyms.Add(gym);
            }

        }
        public void Add(Gym gym)
        {
            this.gyms.Add(gym);
        }

        public void Unique()
        {
            List<string> ids = new List<string>();
            for (int i = this.gyms.Count() - 1; i >= 0; i--)
            {
                if (ids.Contains(this.gyms[i].id))
                {
                    this.gyms.Remove(this.gyms[i]);
                }
                else
                {
                    ids.Add(this.gyms[i].id);
                }
            }
        }
        public void WriteAll(string filePath)
        {
            string headers = "GymId,Latitude,Longitude,Team\n";

            using (StreamWriter w = new StreamWriter(filePath, false))
            {
                w.Write(headers);

                foreach (Gym gym in this.gyms)
                {
                    w.Write(gym.WriteLine());
                }
            }

        }
    }
    


    class Gym
    {
        double lat;
        double lng;
        public string id;
        TeamColor team;
        public Gym(dynamic gym)
        {
            this.lat = gym["lat"];
            this.lng = gym["lng"];
            this.id = gym["id"];
            this.team = (TeamColor)gym["team"];
        }

        public string WriteLine()
        {
            return string.Format("{0},{1},{2},{3}\n", this.id, this.lat, this.lng, this.team);
        }
    }
}
