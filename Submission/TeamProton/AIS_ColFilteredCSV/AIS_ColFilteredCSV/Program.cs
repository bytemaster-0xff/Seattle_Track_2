using System;
using System.Collections.Generic;
using System.Text;

namespace AIS_ColFilteredCSV
{
    class Program
    {
        private struct Geo
        {
            public string TimeStamp;
            public string Lat;
            public string Lon;
            public string Status;
        }


        //ITU Org

        /* This utility will be used to develop track files for vessels within a specific AIS file */
        
        static void Main(string[] args)
        {
            var vessels = new Dictionary<int, List<Geo>>();
            var idx = 0;
            
            var lines = System.IO.File.ReadLines(inputFile);
            foreach(var line in lines)
            {
                if (idx > 1)
                {
                    var parts = line.Split(",");
                    var mmsi = Convert.ToInt32(parts[0]);
                    var geo = new Geo();
                    geo.TimeStamp = parts[1];
                    geo.Lat = parts[2];
                    geo.Lon = parts[3];
                    geo.Status = parts[10];

                    if (vessels.ContainsKey(mmsi))
                        vessels[mmsi].Add(geo);
                    else
                        vessels.Add(mmsi, new List<Geo>() { geo });

                    if (idx % 1000 == 0)
                        Console.WriteLine(idx);
                }

                ++idx;
            }

            Console.WriteLine("Writing Vessels");

            foreach(var key in vessels.Keys)
            {
                var vessel = vessels[key];
                var bldr = new StringBuilder();
                foreach(var points in vessel)
                {
                    bldr.AppendLine($"{points.TimeStamp},{points.Lat},{points.Lon},{points.Status}");
                }

                System.IO.File.WriteAllText($@"S:\Zone17\{key}.csv", bldr.ToString());
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
