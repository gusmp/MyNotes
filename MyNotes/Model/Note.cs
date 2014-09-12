using System;
using System.Collections;

namespace MyNotes.Model
{
    public class Note : BaseModel, IEquatable<Note>
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Set("Title", ref _title, value);
            }
        }

        private string _content;
        public string Content
        {
            get 
            {
                return _content;
            }
            set
            {
                Set("Content", ref _content, value);
            }
        }

        public string GetCategory()
        {
            return this.Title.Substring(0, 1).Trim();
        }

        public bool Equals(Note other)
        {
            if (this == other) return true;

            if (this.Id == other.Id)
            {
                return true;
            }

            return false;
        }
    }
}
