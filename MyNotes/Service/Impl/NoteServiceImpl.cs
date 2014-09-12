using MyNotes.Model;
using MyNotes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Service.Impl
{
    public class NoteServiceImpl : INoteService
    {
        private INoteRepository NoteRepository;

        public NoteServiceImpl(INoteRepository noteRepository)
        {
            this.NoteRepository = noteRepository;
        }


        public List<Note> GetNotes()
        {
            return this.NoteRepository.GetNoteList();
        }

        public Note SaveNote(Note note)
        {
            return this.NoteRepository.SaveNote(note);
        }


        public Note GetNote(Note note)
        {
            return this.NoteRepository.GetNote(note);
        }

        public void DeleteNote(Note note)
        {
            this.NoteRepository.DeleteNote(note);
        }
    }
}
