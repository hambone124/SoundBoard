using System;
using System.IO;
using System.Windows;
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
                try
                {
                    Uri[] layoutArray = JsonConvert.DeserializeObject<Uri[]>(layoutRaw);
                    for (int i = 0; i < 8; i++)
                    {
                        if (layoutArray[i] != null && File.Exists(layoutArray[i].LocalPath))
                        {
                            fileLocations[i] = layoutArray[i];
                        } else {
                            fileLocations[i] = null;
                        }
                    }
                } 
                catch (Newtonsoft.Json.JsonReaderException e)
                {
                    MessageBox.Show("Not a valid layout file.");
                }
            }
        }
    }
}
