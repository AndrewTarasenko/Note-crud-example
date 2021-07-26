using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Note_example.Database.ModelsDto
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public virtual AuthorDto Author { get; set; }
    }
}
