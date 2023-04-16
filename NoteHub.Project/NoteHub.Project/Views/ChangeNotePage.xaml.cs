using System;
using NoteHub.Project.Entities;
using Xamarin.Forms;

namespace NoteHub.Project.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ChangeNotePage
    {
        public string ItemId
        {
            set => LoadNote(value);
        }

        public ChangeNotePage()
        {
            InitializeComponent();

            BindingContext = new NoteEntity();
        }

        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                var note = await App.NotesDb.GetNoteByIdAsync(id);

                BindingContext = note;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            NoteEntity noteEntity = (NoteEntity)BindingContext;

            noteEntity.Date = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(noteEntity.Title) && !string.IsNullOrWhiteSpace(noteEntity.Text))
            {
                await App.NotesDb.SaveNoteAsync(noteEntity);
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            NoteEntity noteEntity = (NoteEntity)BindingContext;
            if (noteEntity == null || noteEntity.Id <= 0)
            {
                return;
            }

            await App.NotesDb.DeleteNoteAsync(noteEntity);

            await Shell.Current.GoToAsync("..");
        }
    }
}