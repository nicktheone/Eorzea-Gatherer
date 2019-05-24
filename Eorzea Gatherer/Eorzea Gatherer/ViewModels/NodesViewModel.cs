using Eorzea_Gatherer.Models;
using System.Collections.Generic;

namespace Eorzea_Gatherer.ViewModels
{
    class NodesViewModel
    {
        public static List<SortedItem> SortedItems { get; set; } = Nodes.GetSortedItems();
    }
}
