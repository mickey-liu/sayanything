using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class HostAns : ContentPage
    {
        class Answer
        {
            public Answer( string name,string ans)
            {
                Name = name;
                Ans = ans;
            }

            public string Name { private set; get; }
            public string Ans { private set; get; }
            
        }

        public HostAns()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Label HAMainLabel = new Label
            {
                FontSize = 26,
                BackgroundColor = Color.Navy,
                Text = "All Players have posted their answers, Please select one",
                TextColor = Color.Red
            };

            List<Answer> answers = new List<Answer>
            {
                new Answer("Kevin", "Micheal Jordan"),
                new Answer("John", "Micheal Jordan"),
            };

            ListView HAListView = new ListView()
            {
                //RowHeight = 40,
                SeparatorVisibility = SeparatorVisibility.Default,
                SeparatorColor = Color.Blue,
                ItemsSource = answers,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label HALabel1 = new Label
                    {
                        FontSize = 18,
                        BackgroundColor = Color.Yellow,
                        TextColor = Color.Red
                    };
                    HALabel1.SetBinding(Label.TextProperty, "Name");

                    Label HALabel2 = new Label
                    {
                        FontSize = 12,
                        BackgroundColor = Color.Yellow,
                        TextColor = Color.Red
                    };
                    HALabel2.SetBinding(Label.TextProperty, "Ans");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                                HALabel1,
                                HALabel2
                            }
                        }
                    };
                }),
                HeightRequest = 300
            };
            HAListView.ItemSelected += HAListView_ItemSelected;

            Content = new StackLayout
            {
                Children = {
                    HAMainLabel,
                    HAListView
                }
            };
        }

        private async void HAListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DisplayAskerSelection());
        }
    }
}
