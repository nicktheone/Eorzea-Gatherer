using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Eorzea_Gatherer.ViewModels;

namespace Eorzea_Gatherer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
        public HomeView()
		{
			InitializeComponent();

            HomeViewModel homeViewModel = new HomeViewModel();
            BindingContext = homeViewModel;            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}