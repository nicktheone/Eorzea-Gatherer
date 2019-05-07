using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eorzea_Gatherer
{
    class Nodes
    {
        #region JSON
        public class Reduce
        {
            public string item { get; set; }
            public int icon { get; set; }
        }

        public class Item
        {
            public string item { get; set; }
            //public int icon { get; set; }

            private string ico;
            public string icon
            {
                get { return ico; }
                set { ico = "Icons/" + value + ".png"; }
            }

            public int id { get; set; }
            public string slot { get; set; }
            public string scrip { get; set; }
            public Reduce reduce { get; set; }
            public int lvl { get; set; }
            public string zone { get; set; }
            public int time { get; set; }
        }

        public class Node
        {
            public string type { get; set; }
            public string func { get; set; }
            public List<Item> items { get; set; }
            public int stars { get; set; }
            public List<int> time { get; set; }
            public string title { get; set; }
            public string zone { get; set; }
            public List<int> coords { get; set; }
            public string name { get; set; }
            public int uptime { get; set; }
            public int lvl { get; set; }
            public int id { get; set; }
            public double patch { get; set; }
            public string condition { get; set; }
            public string bonus { get; set; }
        }
        #endregion

        #region Methods
        //Get the nodes from the JSON file and return a list of nodes 
        public static List<Node> GetNodes()
        {
            string s = File.ReadAllText("Nodes.json");
            List<Node> nodes = JsonConvert.DeserializeObject<List<Node>>(s);

            return nodes;
        }

        //Compiles a list of gatherable items from the nodes list
        public static List<Nodes.Item> GetItems(List<Node> nodes)
        {
            List<Nodes.Item> items = new List<Item>();

            foreach (var node in nodes)
            {
                foreach (var time in node.time)
                {
                    foreach (var item in node.items)
                    {
                        item.time = time;
                        item.lvl = node.lvl;
                        item.zone = String.Format("{0} ({1}, {2})", node.zone, node.coords[0], node.coords[1]);
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        //Compiles a list of gatherable items from the nodes list
        public static List<Nodes.Item> GetUniqueItems(List<Node> nodes)
        {
            List<Nodes.Item> uniqueItems = new List<Item>();

            foreach (var node in nodes)
            {
                foreach (var item in node.items)
                {
                    //https://stackoverflow.com/a/2629303/10617365
                    if (!uniqueItems.Any(x => x.id == item.id))
                    {
                        uniqueItems.Add(item);
                    }
                }
            }

            return uniqueItems;
        }
        #endregion
    }
}
