using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyNotes.Message;
using MyNotes.Model;
using MyNotes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyNotes.ViewModel
{
    public class AddNoteViewModel : ViewModelBase
    {
        private Note _note;
        public Note Note
        {
            get 
            {
                return _note;
            }
            set 
            {
                Set("Note", ref _note, value);
            }
        }

        private INoteService NoteService;

        public AddNoteViewModel(INoteService NoteService)
        {
            this.NoteService = NoteService;
            this.Note = new Note();
            this.AddNoteCommand = new RelayCommand<Note>(AddNote);
            this.InitializeCommand = new RelayCommand(Initialize);
        }

        public ICommand AddNoteCommand { get; private set; }

        private void AddNote(Note note)
        {
            this.NoteService.SaveNote(note);
            Messenger.Default.Send(new NewNoteMessage(note));
        }

        public ICommand InitializeCommand { get; private set; }

        private void Initialize()
        {
            this._note = new Note();
        }
    }
}
