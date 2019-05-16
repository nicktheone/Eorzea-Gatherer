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
            var nodes = Nodes.GetSortedItems();
            nodesListView.ItemsSource = nodes;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}