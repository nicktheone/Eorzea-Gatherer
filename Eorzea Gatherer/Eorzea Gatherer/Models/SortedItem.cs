using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Eorzea_Gatherer.Models
{
    public class SortedItem : ObservableCollection<Item>
    {
        public string Header { get; set; }
        public static List<SortedItem> SortedItems { get; set; }

        static SortedItem()
        {
            SortedItems = Nodes.GetSortedItems();
        }

        //https://stackoverflow.com/questions/56158133/populating-a-grouped-listview-from-a-list
        public SortedItem(List<Item> items) : base(items)
        {

        }
    }
}
