using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Models
{
    public partial class Book
    {
        public Book()
        {
            BookDescriptions = new HashSet<BookDescription>();
            BookShortcuts = new HashSet<BookShortcut>();
            Chapters = new HashSet<Chapter>();
        }

        public int Id { get; set; }
        public string BookName { get; set; }

        public virtual ICollection<BookDescription> BookDescriptions { get; set; }
        public virtual ICollection<BookShortcut> BookShortcuts { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
