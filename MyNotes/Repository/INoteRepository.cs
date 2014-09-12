using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Repository
{
    public interface INoteRepository
    {
        Note GetNote(Note note);

        Note SaveNote(Note note);

        List<Note> GetNoteList();

        void DeleteNote(Note note);
    }
}
