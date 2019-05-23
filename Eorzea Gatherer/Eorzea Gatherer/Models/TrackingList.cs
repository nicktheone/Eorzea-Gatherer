using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Eorzea_Gatherer.Models
{
    public class TrackingList
    {
        public static ObservableCollection<Item> Items { get; set; }

        static TrackingList()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
