using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eorzea_Gatherer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
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
    }
}