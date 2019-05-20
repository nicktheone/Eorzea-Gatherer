using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        #region BindableProperty
        //https://forums.xamarin.com/discussion/comment/375451#Comment_375451
        public static readonly BindableProperty EorzeaTimeNowProperty = BindableProperty.Create(
            nameof(EorzeaTimeNow),
            typeof(DateTime),
            typeof(HomePage),
            default(DateTime));

        public DateTime EorzeaTimeNow
        {
            get => (DateTime)GetValue(EorzeaTimeNowProperty);
            set => SetValue(EorzeaTimeNowProperty, value);
        }
        #endregion

        public HomePage()
		{
			InitializeComponent ();;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //https://xamarinhelp.com/xamarin-forms-timer/
            //Start the timer that calculates Eorzea Time
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                //https://stackoverflow.com/a/7875351/10617365
                EorzeaTimeNow = DateTime.Now.ToEorzeaTime();

                return true;
            });
        }
    }

    public static class Extension
    {
        public static DateTime ToEorzeaTime(this DateTime date)
        {
            //https://www.reddit.com/r/ffxiv/comments/2pbl8p/eorzea_time_formula/cmvijkz?utm_source=share&utm_medium=web2x
            //https://olitee.com/2015/01/c-convert-current-time-ffxivs-eorzea-time/

            const double EorzeaMultiplier = 3600d / 175d;

            // Calculate how many ticks have elapsed since 1/1/1970
            long epochTicks = date.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1).Ticks);

            // Multiply those ticks by the Eorzea multipler (approx 20.5x)
            long eorzeaTicks = (long)Math.Round(epochTicks * EorzeaMultiplier);

            return new DateTime(eorzeaTicks);
        }
    }
}