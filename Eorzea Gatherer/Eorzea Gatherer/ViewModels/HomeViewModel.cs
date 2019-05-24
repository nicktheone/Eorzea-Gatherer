using Eorzea_Gatherer.Models;
using Eorzea_Gatherer.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Eorzea_Gatherer.ViewModels
{
    public class HomeViewModel : BindableObject
    {
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

        public HomeViewModel()
        {
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



        public static ObservableCollection<Item> Items { get; set; }
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
