using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Note_example.Database;
using Note_example.Database.ModelsDto;
using Note_example.Models;

namespace Note_example.Services
{
    public class NoteService : INoteService
    {
        private NoteContext DbContext { get; set; }

        public NoteService(NoteContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int CreateNote(Note note)
        {
            try
            {
                //TODO: implement automapper 
                var noteDto = new NoteDto
                {
                    Title = note.Title,
                    Text = note.Text,
                    AuthorId = note.AuthorId
                };
                DbContext.Notes.Add(noteDto);

                return DbContext.SaveChanges();
                ;
            }
            catch (Exception exception)
            {
                //TODO: log exception
                return default(int);
            }
        }

        public bool DeleteNoteById(int id)
        {
            try
            {
                var noteDto = DbContext.Notes.FirstOrDefault(note => note.Id == id);
                if (noteDto == default(NoteDto))
                {
                    return false;
                }

                DbContext.Remove(noteDto);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //TODO: log exception
                return false;
            }
        }

        public IEnumerable<Note> GetAllNotes()
        {
            try
            {
                var noteDto = DbContext.Notes.ToList();

                //TODO: automapper

                return noteDto.Select(note => new Note
                {
                    Id = note.Id,
                    AuthorId = note.AuthorId,
                    Title = note.Title,
                    Text = note.Text
                }).ToList();
            }
            catch (Exception exception)
            {
                //TODO: log exception
                throw;
            }
        }

        public Note GetNoteById(int id)
        {
            try
            {
                var noteDto = DbContext.Notes.FirstOrDefault(note => note.Id == id);

                //TODO: automapper

                return new Note
                {
                    AuthorId = noteDto.AuthorId,
                    Title = noteDto.Title,
                    Text = noteDto.Text
                };
            }
            catch (Exception exception)
            {
                //TODO: log exception
                throw;
            }
        }

        public int UpdateNote(Note note)
        {
            try
            {
                var noteDto = DbContext.Notes.FirstOrDefault(x => x.Id == note.Id);

                if (noteDto == default(NoteDto))
                {
                    //TODO add custom errors or discuss it with a team (for Entity not found ex)
                }

                //TODO: automapper
                noteDto.Text = note.Text;
                noteDto.Title = note.Title;

                var updatedNote = DbContext.Notes.Update(noteDto);

                DbContext.SaveChanges();

                return DbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                //TODO: log exception
                throw;
            }
        }
    }
}
