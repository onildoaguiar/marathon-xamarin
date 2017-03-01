using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cats
{
    public partial class DetailsPage : ContentPage
    {
        Cat SelectedCat;

        public DetailsPage(Cat selectedCat)
        {
            InitializeComponent();
            this.SelectedCat = selectedCat;
            BindingContext = this.SelectedCat;

            ButtonWebSite.Clicked += ButtonWebSite_Clicked;
        }

        private void ButtonWebSite_Clicked(object sender, EventArgs e)
        {
            if (SelectedCat.WebSite.StartsWith("http"))
            {
                Device.OpenUri(new Uri(SelectedCat.WebSite));
            }
        }
    }
}
