using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Note_example.Models;
using Note_example.Services;

namespace Note_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService NoteService { get; set; }

        public NoteController(INoteService noteService)
        {
            NoteService = noteService;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            var notes = NoteService.GetAllNotes();
            return notes;
        }

        [HttpGet("{id}")]
        public Note Get(int id)
        {
            var note = NoteService.GetNoteById(id);
            return note;
        }

        [HttpPost]
        public void Post(Note note)
        {
            NoteService.CreateNote(note);
        }

        [HttpPut("{id}")]
        public void Put(Note note)
        {
            NoteService.UpdateNote(note);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NoteService.DeleteNoteById(id);
        }
    }
}
