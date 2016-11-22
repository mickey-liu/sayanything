using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SayAnything
{
    public class QS : ContentPage
    {
        class Question
        {
            public Question(string qs)
            {
                Qs = qs;
            }

            public string Qs {private set; get;}
        }

        public QS()
        {
            

            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;
            Label QSMainLabel = new Label
            {
                FontSize = 26,
                BackgroundColor = Color.Navy,
                Text = "You are the host this round. Please Pick a Question",
                TextColor = Color.Red
            };

            List<Question> questions = new List<Question>
            {
                new Question("Who is the best basketball player?"),
                new Question("What would be a great sunday breakfast?"),
                new Question("What is the worst place to have a first date?"),
                new Question("What is the grade I should get in this class?")
            };          

            
            ListView QSlistView = new ListView()
            {
                RowHeight = 40,
                SeparatorVisibility = SeparatorVisibility.Default,
                SeparatorColor = Color.Blue,
                ItemsSource = questions,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label QSlabel = new Label
                    {
                        FontSize = 18,
                        BackgroundColor = Color.Yellow,
                        TextColor = Color.Red
                    };
                    QSlabel.SetBinding(Label.TextProperty, "Qs");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Children =
                            {
                                QSlabel
                            }
                        }
                    };
                }),
                    HeightRequest = 300
                //BackgroundColor = Color.Yellow
            };

            


            QSlistView.ItemSelected += QSlistView_ItemSelected;
            //QSlistView.Focused =
            //QSlistView.ItemTemplate = new DataTemplate(typeof(TextCell));

            Content = new StackLayout
            {
                Spacing = 20,
                Children = {
                    QSMainLabel,
                    QSlistView
                }
            };
        }

        private async void QSlistView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new HostAns());
        }
    }
}
