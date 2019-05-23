using Eorzea_Gatherer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NodesView : ContentPage
	{
		public NodesView()
		{
			InitializeComponent();

            //Load the list of unique items
            nodesListView.ItemsSource = SortedItem.SortedItems;
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
            var item = (Item)mi.BindingContext;

            //Add node to the tracking list view
            TrackingList.Items.Add(item);

            //Save the tracking list on the disk
            Nodes.SaveTrackingList();
        }
        #endregion
    }
}