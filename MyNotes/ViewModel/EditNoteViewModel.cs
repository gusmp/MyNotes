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
    public class EditNoteViewModel : ViewModelBase
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

        public EditNoteViewModel(INoteService NoteService)
        {
            this.NoteService = NoteService;
            this.InitializeCommand = new RelayCommand<string>(Initialize);
            this.SaveNoteCommand = new RelayCommand<Note>(SaveNote);
        }


        public ICommand InitializeCommand { get; private set; }

        private void Initialize(string noteId)
        {
            this.Note = this.NoteService.GetNote(new Note() { Id = Int32.Parse(noteId) });
        }

        public ICommand SaveNoteCommand { get; private set; }
        private void SaveNote(Note note)
        {
            this.NoteService.SaveNote(note);
            Messenger.Default.Send(new EditNoteMessage(note));
        }

    }
}
