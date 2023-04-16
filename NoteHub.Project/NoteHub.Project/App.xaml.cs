using System;
using System.IO;
using NoteHub.Project.Data;

namespace NoteHub.Project
{
    public partial class App
    {
        private static NotesDb _notesDb;

        public static NotesDb NotesDb
        {
            get => _notesDb ?? (_notesDb = new NotesDb(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "NotesDatabase.db")));
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}