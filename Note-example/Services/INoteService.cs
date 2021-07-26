using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Note_example.Models;

namespace Note_example.Services
{
    public interface INoteService
    {
        Note GetNoteById(int id);
        IEnumerable<Note> GetAllNotes();
        int CreateNote(Note note);
        bool DeleteNoteById(int id);

        int UpdateNote(Note note);
    }
}
