using System;
using Xamarin.Forms;

namespace Greetings
{
    public class GreetingPage : ContentPage
    {
        public GreetingPage()
        {
            var Mylabel = new Label();
            Mylabel.Text = "Greetings, xamarin.forms!";
            this.Content = Mylabel;

            Mylabel.HorizontalOptions = LayoutOptions.Center;
            Mylabel.VerticalOptions = LayoutOptions.Center;

            Mylabel.HorizontalTextAlignment = TextAlignment.Center;
            Mylabel.VerticalTextAlignment = TextAlignment.Center;

            Mylabel.TextColor = Color.Aqua;
        }
    }
}
