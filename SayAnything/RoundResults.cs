using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SayAnything
{
	public class RoundResults : ContentPage
	{
		Dictionary<string, int> scoreMap = new Dictionary<string, int>();
		public int yourPoints;
		public int countDown;
		public string player;
		public int playerPointCount;
		public RoundResults()
		{
			scoreMap.Add("John", 3);
			scoreMap.Add("Mark", 0);
			scoreMap.Add("Jimmy", 2);
			scoreMap.Add("Tony", 6);
			NavigationPage.SetHasBackButton(this, false);
			yourPoints = 2;
			countDown = 15;
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
				Text = "In this round, you got :" + Environment.NewLine + Environment.NewLine + yourPoints + " Points",
				HorizontalOptions = LayoutOptions.Center,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			mainStack.Children.Add(p9_01);


			// Display Score 
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


			Label clockLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Text = "Next round will start in " + countDown + " seconds"
			};
			textStack.Children.Add(clockLabel);

			// Start the timer going.
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				countDown = countDown - 1;
				clockLabel.Text = "Next round will start in " + countDown + " seconds";
				if (countDown == 0)
				{
					Button goButton = new Button
					{
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						BorderColor = Color.Blue,
						BorderWidth = 1,
						Text = "Go"
					};
					goButton.Clicked += async (sender, args) =>
					{
						await Navigation.PushAsync(new FinalResults());
					};
					textStack.Children.Add(goButton);
					return false;
					
				}
				return true;
			});



		


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

