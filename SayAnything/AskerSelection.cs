using System;

using Xamarin.Forms;

namespace SayAnything
{
	public class AskerSelection : ContentPage
	{
		//If current player is not question asker, disable page elements and buttons
		public int round;
		public String question;
		public String answer1;
		public String answer2;
		public AskerSelection()
		{
			NavigationPage.SetHasBackButton(this, false);
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

			Label p7_01 = new Label
			{
				Text = "Everyone has submitted an answer, please select an answer.",
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.Center
			};
			textStack.Children.Add(p7_01);

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
				answerButton.Clicked += answerButtonClicked;
			};



			Button SubmitButton = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BorderColor = Color.Blue,
				BorderWidth = 1,
				Text = "Submit"
			};
			SubmitButton.Clicked += async (sender, args) =>
			{
				// socket.io to save selection
				await Navigation.PushAsync(new DisplayAskerSelection());
			};


			textStack.Children.Add(SubmitButton);

			ScrollView scrollView = new ScrollView
			{
				Content = textStack,
				VerticalOptions = LayoutOptions.FillAndExpand,
				//Padding = new Thickness(5, 0),

			};
			mainStack.Children.Add(scrollView);

			Content = mainStack;


		}
		void answerButtonClicked(object sender, EventArgs args)
		{
			// highlight selection
		}
		}
	}


