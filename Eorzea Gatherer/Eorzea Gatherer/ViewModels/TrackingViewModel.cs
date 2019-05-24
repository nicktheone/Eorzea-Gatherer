using Eorzea_Gatherer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Eorzea_Gatherer.ViewModels
{
    class TrackingViewModel
    {
        public static ObservableCollection<Item> Items { get; set; }

        //Read the tracking list from the disk
        public static void ReadTrackingList()
        {
            string s = null;

            using (StreamReader streamReader = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tracking.json")))
            {
                s = streamReader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(s);
        }

        //Write the tracking list to the disk
        public static void SaveTrackingList()
        {
            using (StreamWriter streamWriter = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tracking.json")))
            {
                JsonSerializer jsonSerializer = new JsonSerializer()
                {
                    Formatting = Formatting.Indented
                };

                jsonSerializer.Serialize(streamWriter, Items);
            }
        }
    }
}
