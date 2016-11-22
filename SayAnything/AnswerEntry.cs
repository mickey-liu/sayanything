using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class AnswerEntry : ContentPage
    {
        public int round;
        public String question;
        public String answer1;
        public String answer2;
        public AnswerEntry()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            round = 1;
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

            for (int i = 1; i <= 2; i++)
            {
                Frame answerFrame = new Frame
                {
                    OutlineColor = Color.Black,
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Content = new Label
                    {
                        Text = "Answer" + i + ":" + Environment.NewLine + answer1,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.Red
                    }
                };
                textStack.Children.Add(answerFrame);
            };

            Entry answerEntry = new Entry
            {
                Keyboard = Keyboard.Default,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "Answer"
            };

            Button SubmitButton = new Button
            {
                HorizontalOptions = LayoutOptions.End,
                BorderColor = Color.Blue,
                BorderWidth = 1,
                Text = "Submit"
            };
            SubmitButton.Clicked += async (sender, args) =>
            {
                // socket.io action
                await Navigation.PushAsync(new DisplayAskerSelection());
            };

            StackLayout entry = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    answerEntry,
                    SubmitButton

                }
            };
            textStack.Children.Add(entry);

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
