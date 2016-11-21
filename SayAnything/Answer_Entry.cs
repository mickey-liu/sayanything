using System;

using Xamarin.Forms;

namespace SayAnything
{
	public class Answer_Entry : ContentPage
	{
		public int round;
		public Answer_Entry()
		{
			round = 1;
			StackLayout mainStack = new StackLayout();
			StackLayout textStack = new StackLayout();

			Label title = new Label
			{
				Text = "Round " + round + " - Results",
				TextColor = Color.Black

			};
			mainStack.Children.Add(title);
				
			ScrollView scrollView = new ScrollView
			{
				Content = textStack
				
			};
			mainStack.Children.Add(scrollView);
		}
	}
}

