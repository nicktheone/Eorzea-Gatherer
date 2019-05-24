using Eorzea_Gatherer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eorzea_Gatherer.ViewModels
{
    class NodesViewModel
    {
        public static List<SortedItem> SortedItems { get; set; } = GetSortedItems();

        #region Methods
        //Get the nodes from the JSON file and return a list of nodes 
        private static List<JSON.Node> GetNodes()
        {
            string s = File.ReadAllText("Nodes.json");
            List<JSON.Node> nodes = JsonConvert.DeserializeObject<List<JSON.Node>>(s);

            return nodes;
        }

        //Compile a list of gatherable items from the nodes list
        private static List<Item> GetItems()
        {
            List<JSON.Node> nodes = GetNodes();
            List<Item> items = new List<Item>();

            foreach (var node in nodes)
            {
                foreach (var time in node.time)
                {
                    foreach (var item in node.items)
                    {
                        //Create a fake date and assign the hour of the day
                        DateTime fakeEorzeaDay = new DateTime(1970, 1, 1, time, 0, 0);

                        Item singleItem = new Item(item);
                        singleItem.time = fakeEorzeaDay;
                        singleItem.lvl = node.lvl;
                        singleItem.zone = String.Format("{0} ({1}, {2})", node.zone, node.coords[0], node.coords[1]);
                        items.Add(singleItem);
                    }
                }
            }

            return items;
        }

        //Split the list of gatherable items into different lists to bind into a grouped ListView
        private static List<SortedItem> GetSortedItems()
        {
            List<Item> items = GetItems();

            List<SortedItem> sortedItems = new List<SortedItem>()
            {
                new SortedItem(items.Where(x => x.lvl == 50).ToList())
                {
                   Header = "50"
                },
                new SortedItem(items.Where(x => x.lvl == 55).ToList())
                {
                   Header = "55"
                },
                new SortedItem(items.Where(x => x.lvl == 60).ToList())
                {
                   Header = "60"
                },
                new SortedItem(items.Where(x => x.lvl == 65).ToList())
                {
                   Header = "65"
                },
                new SortedItem(items.Where(x => x.lvl == 70).ToList())
                {
                   Header = "70"
                }
            };

            return sortedItems;
        }

        //Compile a list of gatherable items from the nodes list (not used)
        private static List<Item> GetUniqueItems(List<JSON.Node> nodes)
        {
            List<Item> uniqueItems = new List<Item>();

            foreach (var node in nodes)
            {
                foreach (var time in node.time)
                {
                    foreach (var item in node.items)
                    {
                        //https://stackoverflow.com/a/2629303/10617365
                        if (!uniqueItems.Any(x => x.id == item.id))
                        {
                            uniqueItems.Add(new Item(item)
                            {
                                lvl = node.lvl,
                                zone = String.Format("{0} ({1}, {2})", node.zone, node.coords[0], node.coords[1]),
                                time = new DateTime(1970, 1, 1, time, 0, 0)
                            });
                        }
                    }
                }
            }

            return uniqueItems;
        }
        #endregion
    }
}
