using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class FinalResults : ContentPage
    {
        Dictionary<string, int> scoreMap = new Dictionary<string, int>();
        public int round;
        public string player;
        public int playerPointCount;
        public FinalResults()
        {
            scoreMap.Add("John", 3);
            scoreMap.Add("Mark", 0);
            scoreMap.Add("Jimmy", 2);
            scoreMap.Add("Tony", 6);
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10

            };


            Label title = new Label
            {
                Text = "Score Board",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };
            mainStack.Children.Add(title);

            Label p9_01 = new Label
            {
                Text = "Game Over",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            mainStack.Children.Add(p9_01);

            foreach (var item in scoreMap)
            {
                player = item.Key;
                playerPointCount = item.Value;
                Frame scoreFrame = new Frame
                {


                    OutlineColor = Color.Black,
                    BackgroundColor = Color.Yellow,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Spacing = 15,
                        Children = {
                            new Label
                            {
                                Text = player,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                FontAttributes = FontAttributes.Bold,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.StartAndExpand
                            },
                            new Label
                            {
                                Text = playerPointCount.ToString(),
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Color.Red,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.StartAndExpand
                            }
                        }

                    }



                };
                textStack.Children.Add(scoreFrame);



            };

            Button doneButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                BorderColor = Color.Blue,
                BorderWidth = 1,
                Text = "Done"
            };
            doneButton.Clicked += async (sender, args) =>
            {
                // socket.io action
                await Navigation.PushAsync(new AnswerEntry());
            };
            textStack.Children.Add(doneButton);

            ScrollView scrollView = new ScrollView
            {
                Content = textStack,
                VerticalOptions = LayoutOptions.FillAndExpand,
                //Padding = new Thickness(5, 0),

            };

            mainStack.Children.Add(scrollView);


            Content = mainStack;
        }
    }
}
