using System;

using Xamarin.Forms;

namespace SayAnything
{
	public class _ : ContentPage
	{
		public _()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

