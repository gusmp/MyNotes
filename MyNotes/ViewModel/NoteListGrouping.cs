using MyNotes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyNotes.ViewModel
{
    public class NoteListGrouping : ObservableCollection<Note>
    {
        public string Key { get; set; }

        public NoteListGrouping(string key, IEnumerable<Note> items) : base(items)
        {
            this.Key = key;
        }

        public void AddNoteViewModel(Note note)
        {
            this.Add(note);
        }
    }
}
