using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note_example.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
    }
}
