using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Message
{
    public class EditNoteMessage
    {
        public Note Note { get; set; }

        public EditNoteMessage(Note Note)
        {
            this.Note = Note;
        }
    }
}
