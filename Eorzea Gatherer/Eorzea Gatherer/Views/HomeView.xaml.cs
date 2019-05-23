using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Eorzea_Gatherer.ViewModels;

namespace Eorzea_Gatherer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
        #region BindableProperty
        //https://forums.xamarin.com/discussion/comment/375451#Comment_375451
        public static readonly BindableProperty EorzeaTimeNowProperty = BindableProperty.Create(
            nameof(EorzeaTimeNow),
            typeof(DateTime),
            typeof(HomeView),
            default(DateTime));

        public DateTime EorzeaTimeNow
        {
            get => (DateTime)GetValue(EorzeaTimeNowProperty);
            set => SetValue(EorzeaTimeNowProperty, value);
        }
        #endregion

        public HomeView()
		{
			InitializeComponent();

            //https://xamarinhelp.com/xamarin-forms-timer/
            //Start the timer that calculates Eorzea Time
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                DateTime eorzeaTime = DateTime.Now.ToEorzeaTime();

                //Create a fake date and assign to it the hour and the minute of the day
                DateTime fakeEorzeaTime = new DateTime(1970, 1, 1, eorzeaTime.Hour, eorzeaTime.Minute, 0);
                EorzeaTimeNow = fakeEorzeaTime;

                return true;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}