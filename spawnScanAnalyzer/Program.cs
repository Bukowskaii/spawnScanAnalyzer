using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using System.Threading;

namespace spawnScanAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Desktop\Poke\spawnScan\results";

            GymList gyms = new GymList();
            gyms.Add(GetGyms(path));

            StopList stops = new StopList();
            stops.Add(GetStops(path));

            PokeList pokes = new PokeList();
            pokes.Add(GetPokes(path));

            SpawnList spawns = new SpawnList();
            spawns.Add(GetSpawns(path));

            //gyms.Unique();
            //stops.Unique();

            gyms.WriteAll(Path.Combine(path, "gyms.csv"));
            stops.WriteAll(Path.Combine(path, "stops.csv"));
            pokes.WriteAll(Path.Combine(path, "pokes.csv"));
            spawns.WriteAll(Path.Combine(path, "spawns.csv"));

            Thread.Sleep(1);
        }

        
        static IEnumerable<Gym> GetGyms(string root)
        {
            foreach (string gymFile in Directory.GetFiles(root, "gyms.json", SearchOption.AllDirectories))
            {
                using (StreamReader r = new StreamReader(gymFile))
                {
                    string json = r.ReadToEnd();
                    dynamic gyms = JsonConvert.DeserializeObject(json);
                    foreach(dynamic gym in gyms) {
                        yield return new Gym(gym);
                    }
                }
            }

        }

        static IEnumerable<Stop> GetStops(string root)
        {
            foreach (string stopFile in Directory.GetFiles(root, "stops.json", SearchOption.AllDirectories))
            {
                using (StreamReader r = new StreamReader(stopFile))
                {
                    string json = r.ReadToEnd();
                    dynamic stops = JsonConvert.DeserializeObject(json);
                    foreach (dynamic stop in stops)
                    {
                        yield return new Stop(stop);
                    }
                }
            }
        }

        static IEnumerable<Poke> GetPokes(string root)
        {
            foreach (string pokeFile in Directory.GetFiles(root, "pokes.json", SearchOption.AllDirectories))
            {
                using (StreamReader r = new StreamReader(pokeFile))
                {
                    string json = r.ReadToEnd();
                    dynamic pokes = JsonConvert.DeserializeObject(json);
                    foreach (dynamic poke in pokes)
                    {
                        yield return new Poke(poke);
                    }
                }
            }
        }

        static IEnumerable<Spawn> GetSpawns(string root)
        {
            foreach (string spawnFile in Directory.GetFiles(root, "spawns.json", SearchOption.AllDirectories))
            {
                using (StreamReader r = new StreamReader(spawnFile))
                {
                    string json = r.ReadToEnd();
                    dynamic spawns = JsonConvert.DeserializeObject(json);
                    foreach (dynamic spawn in spawns)
                    {
                        yield return new Spawn(spawn);
                    }
                }
            }
        }

    }
}
