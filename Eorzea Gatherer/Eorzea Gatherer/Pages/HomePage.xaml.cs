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
		public HomePage()
		{
			InitializeComponent ();

            Griglia.ColumnDefinitions.Add(new ColumnDefinition { });
            var stack = new StackLayout();

            var label = new Label { Text = "Prova", FontSize = 12, FontFamily = "SegoeUI-Semibold", HorizontalTextAlignment = TextAlignment.Center };
            var image = new Image { Source = "", BackgroundColor = Color.Black, HeightRequest = 52, WidthRequest = 52 };
            var label2 = new Label { Text = "Provaaa", FontSize = 12, FontFamily = "SegoeUI", HorizontalTextAlignment = TextAlignment.Center };

            stack.Children.Add(label);
            stack.Children.Add(image);
            stack.Children.Add(label2);

            Griglia.Children.Add(stack, 6, 0);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //https://xamarinhelp.com/xamarin-forms-timer/
            //Start the timer that calculates Eorzea Time
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                //https://stackoverflow.com/a/7875351/10617365
                var eorzeaTimeNow = DateTime.Now.ToEorzeaTime().ToString("hh:mm tt", CultureInfo.InvariantCulture);
                eorzeaTimeLabel.Text = eorzeaTimeNow;

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