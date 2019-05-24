using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Eorzea_Gatherer.Models;

namespace Eorzea_Gatherer
{
    public class Nodes
    {
        //#region JSON
        //public class Reduce
        //{
        //    public string item { get; set; }
        //    public int icon { get; set; }
        //}

        //public class Item
        //{
        //    public string item { get; set; }
        //    public string icon { get; set; }
        //    public int id { get; set; }
        //    public string slot { get; set; }
        //    public string scrip { get; set; }
        //    public Reduce reduce { get; set; }
        //    public int lvl { get; set; }
        //    public string zone { get; set; }
        //    public DateTime time { get; set; }
        //}

        //public class Node
        //{
        //    public string type { get; set; }
        //    public string func { get; set; }
        //    public List<Item> items { get; set; }
        //    public int stars { get; set; }
        //    public List<int> time { get; set; }
        //    public string title { get; set; }
        //    public string zone { get; set; }
        //    public List<int> coords { get; set; }
        //    public string name { get; set; }
        //    public int uptime { get; set; }
        //    public int lvl { get; set; }
        //    public int id { get; set; }
        //    public double patch { get; set; }
        //    public string condition { get; set; }
        //    public string bonus { get; set; }
        //}
        //#endregion

        //#region Sorted Lists
        //public class SortedItem : ObservableCollection<Models.Item>
        //{
        //    public string Header { get; set; }
        //    public static List<Models.SortedItem> SortedItems { get; set; }

        //    static SortedItem()
        //    {
        //        SortedItems = GetSortedItems();
        //    }

        //    //https://stackoverflow.com/questions/56158133/populating-a-grouped-listview-from-a-list
        //    public SortedItem(List<Models.Item> items) : base(items)
        //    {
                    
        //    }
        //}
        //#endregion

        //#region Tracking List
        //public class TrackingList
        //{
        //    public static ObservableCollection<Models.Item> Items { get; set; }

        //    static TrackingList()
        //    {
        //        Items = new ObservableCollection<Models.Item>();
        //    }
        //}
        //#endregion

        #region Methods
        ////Get the nodes from the JSON file and return a list of nodes 
        //private static List<JSON.Node> GetNodes()
        //{
        //    string s = File.ReadAllText("Nodes.json");
        //    List<JSON.Node> nodes = JsonConvert.DeserializeObject<List<JSON.Node>>(s);

        //    return nodes;
        //}

        ////Compile a list of gatherable items from the nodes list
        //private static List<Item> GetItems()
        //{
        //    List<JSON.Node> nodes = GetNodes();
        //    List<Item> items = new List<Item>();

        //    foreach (var node in nodes)
        //    {
        //        foreach (var time in node.time)
        //        {
        //            foreach (var item in node.items)
        //            {
        //                //Create a fake date and assign the hour of the day
        //                DateTime fakeEorzeaDay = new DateTime(1970, 1, 1, time, 0, 0);

        //                Item singleItem = new Item(item);
        //                singleItem.time = fakeEorzeaDay;
        //                singleItem.lvl = node.lvl;
        //                singleItem.zone = String.Format("{0} ({1}, {2})", node.zone, node.coords[0], node.coords[1]);
        //                items.Add(singleItem);
        //            }
        //        }
        //    }

        //    return items;
        //}

        ////Split the list of gatherable items into different lists to bind into a grouped ListView
        //public static List<SortedItem> GetSortedItems()
        //{
        //    List<Models.Item> items = GetItems();

        //    List<SortedItem> sortedItems = new List<SortedItem>()
        //    {
        //        new SortedItem(items.Where(x => x.lvl == 50).ToList())
        //        {
        //           Header = "50"
        //        },
        //        new SortedItem(items.Where(x => x.lvl == 55).ToList())
        //        {
        //           Header = "55"
        //        },
        //        new SortedItem(items.Where(x => x.lvl == 60).ToList())
        //        {
        //           Header = "60"
        //        },
        //        new SortedItem(items.Where(x => x.lvl == 65).ToList())
        //        {
        //           Header = "65"
        //        },
        //        new SortedItem(items.Where(x => x.lvl == 70).ToList())
        //        {
        //           Header = "70"
        //        }
        //    };

        //    return sortedItems;
        //}

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

        ////Write the tracking list to the disk
        //public static void SaveTrackingList()
        //{
        //    using (StreamWriter streamWriter = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tracking.json")))
        //    {
        //        JsonSerializer jsonSerializer = new JsonSerializer()
        //        {
        //            Formatting = Formatting.Indented
        //        };

        //        jsonSerializer.Serialize(streamWriter, TrackingList.Items);
        //    }
        //}

        ////Read the tracking list from the disk
        //public static void ReadTrackingList()
        //{
        //    string s = null;

        //    using (StreamReader streamReader = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tracking.json")))
        //    {
        //        s = streamReader.ReadToEnd();
        //    }

        //    TrackingList.Items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(s);
        //}
        #endregion
    }
}