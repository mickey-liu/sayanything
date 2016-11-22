using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class Room : ContentPage
    {
        List<String> names = new List<String>();
        public Room()
        {
            names.Add("Tom");
            names.Add("John");
            names.Add("Kevin");
            String roomNames = "Players in the room: " + names[0];

            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;

            int n = names.Count;
            for (int i = 1; i < names.Count; i++)
            {
                roomNames = roomNames + ", " + names[i];
            }

            Label roomLabel1 = new Label
            {
                BackgroundColor = Color.Yellow,
                TextColor = Color.Blue,
                //Text = roomNames
                FontSize = 20,
                HeightRequest = 100,
                WidthRequest = 200,
                Text = "Players in the room: \n" + names[0]
            };

            Frame roomFrame1 = new Frame
            {

                OutlineColor = Color.Black,

                HasShadow = true,
                Padding = 5,
                HeightRequest = 150,
                WidthRequest = 200,
                Content = roomLabel1
            };

            Button roomButton1 = new Button
            {
                Text = "Leave",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            roomButton1.Clicked += RoomButton1_Clicked;

            Button roomButton2 = new Button
            {
                Text = "Start",
                FontSize = 20,
                BackgroundColor = Color.Silver,
                TextColor = Color.Red,
                BorderRadius = 15
            };
            roomButton2.Clicked += RoomButton2_Clicked;

            //finalize content
            Content = new StackLayout
            {
                Children = {
                    roomFrame1,
                    roomButton1,
                    roomButton2
                }
            };
        }

        private async void RoomButton1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void RoomButton2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QS());
        }
    }
}
