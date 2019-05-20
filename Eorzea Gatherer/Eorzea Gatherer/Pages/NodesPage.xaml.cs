using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NodesPage : ContentPage
	{
		public NodesPage()
		{
			InitializeComponent();

            //Load the list of unique items
            nodesListView.ItemsSource = Nodes.SortedItem.SortedItems;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #region Events
        public void AddTracking(object sender, EventArgs e)
        {
            //Retrieve the object bound to the cell raising the event
            var mi = (MenuItem)sender;
            var item = (Nodes.Item)mi.BindingContext;

            //Add node to the tracking list view
            Nodes.TrackingList.Items.Add(item);

            //Save the tracking list on the disk
            Nodes.SaveTrackingList();
        }
        #endregion
    }
}