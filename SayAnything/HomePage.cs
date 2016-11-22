using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class HomePage : ContentPage
    {
        string name = "tom";

        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //Title = "Say Anything!";
            BackgroundColor = Color.White;

            //background image, place at bottom
            Image image = new Image
            {
                Source = "SA3.jpg",
                Opacity = 0.8,
                //HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };
            //BackgroundImage = "SA3.jpg";


            //show players in the room, at top
            

            var label = new Label
            {
                BackgroundColor = Color.Yellow,
                TextColor = Color.Blue,
                
                Text = "Players in the room: \n" + name,
                HeightRequest = 100,
                WidthRequest = 200,
                FontSize = 20,
                FontAttributes = FontAttributes.Italic
                
               
            };

            Frame frame = new Frame
            {
                
                OutlineColor = Color.Black,
                
                HasShadow = true,
                Padding = 5,
                HeightRequest = 150,
                WidthRequest = 200,
                Content = label
            };


            //entry box for name
            Entry entry = new Entry
            {
                Placeholder = "Please enter your name here"
                

            };
            entry.Completed += Entry_Completed;

            //button for join room
            Button join = new Button
            {
                Text = "Join",
                FontSize = 20,
                
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15

            };
            join.Clicked += Join_Clicked;

            Content = new StackLayout
            {
                Children = {
                    frame,
                    entry,
                    join,
                    image
                }
            };
        }

        private async void Join_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Room());
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;
            name = entry.Text;
        }
    }
}
