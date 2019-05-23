﻿using Eorzea_Gatherer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrackingPage : ContentPage
	{
        public TrackingPage()
		{
			InitializeComponent();

            try
            {
                //Load the tracking list from the disk
                Nodes.ReadTrackingList();
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
            var item = (Models.Item)mi.BindingContext;

            //Remove node to the tracking list view
            TrackingList.Items.Remove(item);

            //Save the tracking list on the disk
            Nodes.SaveTrackingList();
        }
        #endregion
    }
}