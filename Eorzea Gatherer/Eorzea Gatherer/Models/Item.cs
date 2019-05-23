using System;
using System.Collections.Generic;
using System.Text;

namespace Eorzea_Gatherer.Models
{
    public class Item : JSON.Item
    {
        public int lvl { get; set; }
        public string zone { get; set; }
        public DateTime time { get; set; }

        public Item()
        {

        }

        public Item(JSON.Item item)
        {
            this.item = item.item;
            this.icon = item.icon;
            this.id = item.id;
            this.slot = item.slot;
        }
    }
}
