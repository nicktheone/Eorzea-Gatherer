﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrackingPage : ContentPage
	{
        public TrackingPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Set and refresh the ListView source
            trackingListView.ItemsSource = null;
            trackingListView.ItemsSource = Nodes.TrackingList.Items;
        }
    }
}