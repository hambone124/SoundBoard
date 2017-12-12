using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SoundBoard
{
    class LayoutManager
    {
        public static void SaveLayoutToFile(Uri[] fileLocations)
        {
            // Save dialog box here
            string json = JsonConvert.SerializeObject(fileLocations);
            File.WriteAllText(@"C:\users\ham\Desktop\Layout.txt", json);
        }
        public static void OpenLayoutFromFile(Uri[] fileLocations)
        {
            // Open dialog box here. Currently not working.
            string layoutRaw = File.ReadAllText(@"C:\users\ham\Desktop\Layout.txt");
            Uri[] layoutArray = JsonConvert.DeserializeObject<Uri[]>(layoutRaw);
            Console.WriteLine(layoutArray[1]);
        }
    }
}
