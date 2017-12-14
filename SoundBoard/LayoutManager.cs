using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace SoundBoard
{
    class LayoutManager
    {
        public static void SaveLayoutToFile(Uri[] fileLocations)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string json = JsonConvert.SerializeObject(fileLocations);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
        public static void LoadLayoutFromFile(ref Uri[] fileLocations)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string layoutRaw = File.ReadAllText(openFileDialog.FileName);
                Uri[] layoutArray = JsonConvert.DeserializeObject<Uri[]>(layoutRaw);
                for (int i = 0; i < layoutArray.Length; i++)
                {
                    fileLocations[i] = layoutArray[i];
                }
            }
        }
    }
}
