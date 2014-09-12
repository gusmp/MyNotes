using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Service
{
    public interface INoteService
    {
        List<Note> GetNotes();

        Note SaveNote(Note note);

        Note GetNote(Note note);

        void DeleteNote(Note note);
    }
}
