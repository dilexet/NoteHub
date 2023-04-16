using System.Collections.Generic;
using System.Threading.Tasks;
using NoteHub.Project.Entities;
using SQLite;

namespace NoteHub.Project.Data
{
    public class NotesDb
    {
        private readonly SQLiteAsyncConnection _db;

        public NotesDb(string connectionString)
        {
            _db = new SQLiteAsyncConnection(connectionString);
            _db.CreateTableAsync<NoteEntity>().Wait();
        }

        public Task<List<NoteEntity>> GetNotesAsync()
        {
            return _db
                .Table<NoteEntity>()
                .ToListAsync();
        }

        public Task<NoteEntity> GetNoteByIdAsync(int id)
        {
            return _db
                .Table<NoteEntity>()
                .Where(note => note.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(NoteEntity noteEntity)
        {
            if (noteEntity.Id != 0)
            {
                return _db.UpdateAsync(noteEntity);
            }

            return _db.InsertAsync(noteEntity);
        }

        public Task<int> DeleteNoteAsync(NoteEntity noteEntity)
        {
            return _db.DeleteAsync(noteEntity);
        }
    }
}