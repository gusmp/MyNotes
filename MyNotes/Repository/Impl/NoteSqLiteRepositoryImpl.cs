using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Repository.Impl
{
    public class NoteSqLiteRepositoryImpl : SqLiteBaseRepository, INoteRepository
    {

        public NoteSqLiteRepositoryImpl()
        {
            GetConnection().CreateTable<Note>();
        }

        public Note GetNote(Note note)
        {
            return GetConnection().Table<Note>().Where(x => x.Id == note.Id).SingleOrDefault();
        }

        public Note SaveNote(Note note)
        {
            return (Note) this.SaveOrUpdate(note);
        }


        public List<Note> GetNoteList()
        {
            return GetConnection().Table<Note>().ToList();
        }

        public void DeleteNote(Note note)
        {
            GetConnection().Delete(note);
        }
    }
}
