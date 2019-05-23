using Eorzea_Gatherer.Models;
using Eorzea_Gatherer.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrackingView : ContentPage
	{
        public TrackingView()
		{
			InitializeComponent();

            try
            {
                //Load the tracking list from the disk
                TrackingViewModel.ReadTrackingList();
            }
            catch (Exception)
            {

            }

            //Set and refresh the ListView source
            trackingListView.ItemsSource = TrackingList.Items;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #region Events
        public void RemoveTracking(object sender, EventArgs e)
        {
            //Retrieve the object bound to the cell raising the event
            var mi = (MenuItem)sender;
            var item = (Item)mi.BindingContext;

            //Remove node to the tracking list view
            TrackingList.Items.Remove(item);

            //Save the tracking list on the disk
            TrackingViewModel.SaveTrackingList();
        }
        #endregion
    }
}