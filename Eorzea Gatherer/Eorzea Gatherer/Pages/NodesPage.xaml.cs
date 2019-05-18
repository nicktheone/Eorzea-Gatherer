using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

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
            //DisplayAlert(item.id.ToString(), item.item, item.GetType().ToString());

            //Add node to the tracking list view
            Nodes.TrackingList.Items.Add(item);
        }
        #endregion
    }
}