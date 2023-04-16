using NoteHub.Project.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteHub.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ChangeNotePage), typeof(ChangeNotePage));
        }
    }
}