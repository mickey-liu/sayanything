using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class DisplayAskerSelection : ContentPage
    {
        public int round;
        public String question;
        public String answer1;
        public String answer2;
        public String chosenPlayer;
        bool isAnswer;
        public int numberOfPlayers;
        public DisplayAskerSelection()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            numberOfPlayers = 2;
            chosenPlayer = "Jack";
            round = 1;
            isAnswer = true;
            question = "Who is the best basketball player?";
            answer1 = "Michael Jordan";
            answer2 = "Lebron James";
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10

            };

            Label title = new Label
            {
                Text = "Round " + round + " - Player",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center

            };
            mainStack.Children.Add(title);

            Label p8_01 = new Label
            {
                Text = chosenPlayer + "'s answer was selected.",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center
            };
            textStack.Children.Add(p8_01);

            Frame questionFrame = new Frame
            {
                OutlineColor = Color.Black,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Content = new Label
                {
                    Text = "Question: " + Environment.NewLine + question,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    TextColor = Color.Blue
                }
            };
            textStack.Children.Add(questionFrame);

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                if (isAnswer)
                {
                    Button answerButton = new Button
                    {

                        BackgroundColor = Color.Gray,
                        HorizontalOptions = LayoutOptions.Center,
                        BorderColor = Color.Red,
                        BorderWidth = 1,
                        VerticalOptions = LayoutOptions.Center,

                        Text = "Answer" + i + ": " + answer1,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.White,

                    };
                    isAnswer = false;
                    textStack.Children.Add(answerButton);
                }
                else
                {
                    Button answerButton = new Button
                    {

                        BackgroundColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        BorderColor = Color.Accent,
                        BorderWidth = 1,
                        VerticalOptions = LayoutOptions.Center,

                        Text = "Answer" + i + ": " + answer1,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.Red

                    };
                    textStack.Children.Add(answerButton);
                }
            }

            Button NextButton = new Button
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.Blue,
                BorderWidth = 1,
                Text = "Next"
            };

            NextButton.Clicked += async (sender, args) =>
            {
                // socket.io to save selection
                await Navigation.PushAsync(new RoundResults());
            };

            textStack.Children.Add(NextButton);

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
