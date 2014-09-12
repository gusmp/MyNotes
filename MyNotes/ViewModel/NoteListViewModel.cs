using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyNotes.Message;
using MyNotes.Model;
using MyNotes.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MyNotes.ViewModel
{
    public class NoteListViewModel : ViewModelBase
    {
        private INoteService NoteService;

        private ObservableCollection<NoteListGrouping> _noteGroupingList;
        public ObservableCollection<NoteListGrouping> NoteGroupingList
        {
            get 
            {
                return _noteGroupingList;
            }
            set
            {
                Set( "NoteGroupingList", ref _noteGroupingList, value);
            }
        }

        public NoteListViewModel(INoteService noteService)
        {
            this.NoteService = noteService;
            this.UpdateNoteListCommand = new RelayCommand(UpdateNoteList);
            this.DeleteNoteCommand = new RelayCommand<Note>(DeleteNote);

            UpdateNoteList();
            Messenger.Default.Register<NewNoteMessage>(this, AddNoteHandler);
            Messenger.Default.Register<EditNoteMessage>(this, EditNoteHandler);
        }


        public ICommand UpdateNoteListCommand {get; private set;}

        private void UpdateNoteList()
        {
            var noteGroups = (from obj in this.NoteService.GetNotes()
                              group obj by obj.GetCategory() into g
                              orderby g.Key
                              select new NoteListGrouping(g.Key, g));
            this.NoteGroupingList = new ObservableCollection<NoteListGrouping>(noteGroups.ToList());
        }

        public ICommand DeleteNoteCommand { get; private set; }

        private void DeleteNote(Note note)
        {
            this.NoteService.DeleteNote(note);

            NoteListGrouping nlg = this.NoteGroupingList.Where(x => note.Title.StartsWith(x.Key)).SingleOrDefault();
            if (nlg != null)
            {
                nlg.Remove(note);
            }
        }

        private void AddNoteHandler(NewNoteMessage NewNoteMessage)
        {
            Note note = NewNoteMessage.Note;

            NoteListGrouping nlg = this.NoteGroupingList.Where(x => note.Title.StartsWith(x.Key)).SingleOrDefault();
            if (nlg != null)
            {
                nlg.AddNoteViewModel(note);
            }
            else 
            {
                this.NoteGroupingList.Add(new NoteListGrouping(note.Title.Substring(0, 1), new List<Note> { note }));
            }
        }


        private void EditNoteHandler(EditNoteMessage EditNoteMessage)
        {
            UpdateNoteList();
        }
    }
}
