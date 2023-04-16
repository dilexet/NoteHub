using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NoteHub.Project.Mapper;
using NoteHub.Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteHub.Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage
    {
        private readonly IMapper _mapper;

        public NotesPage()
        {
            InitializeComponent();
            _mapper = AutoMapperHelper.GetMapper();
        }

        protected async override void OnAppearing()
        {
            NotesView.ItemsSource = _mapper.Map<List<NoteViewModel>>(await App.NotesDb.GetNotesAsync());
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ChangeNotePage));
        }

        private async void OnSelectionNote_Changed(object sender, SelectionChangedEventArgs e)
        {
            NoteViewModel note = (NoteViewModel)e.CurrentSelection?.FirstOrDefault();

            if (note != null)
            {
                await Shell.Current.GoToAsync(
                    $"{nameof(ChangeNotePage)}?{nameof(ChangeNotePage.ItemId)}={note.Id.ToString()}");
            }
        }
    }
}