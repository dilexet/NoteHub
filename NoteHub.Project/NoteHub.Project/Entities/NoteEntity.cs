using System;
using SQLite;

namespace NoteHub.Project.Entities
{
    public class NoteEntity
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}