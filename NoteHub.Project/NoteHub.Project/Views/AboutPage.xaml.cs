using System;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace NoteHub.Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void OnLinkedinIcon_Tapped(object sender, EventArgs e)
        {
            var uri = "https://www.linkedin.com/in/pavarha-maksim/";
            await Launcher.OpenAsync(uri);
        }

        private async void OnTelegramIcon_Tapped(object sender, EventArgs e)
        {
            var uri = "https://t.me/dilexet";
            await Launcher.OpenAsync(uri);
        }
    }
}