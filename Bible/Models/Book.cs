using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAliases = new HashSet<BookAlias>();
            BookDescriptions = new HashSet<BookDescription>();
            Chapters = new HashSet<Chapter>();
        }

        public int Id { get; set; }
        public string BookName { get; set; }
        public int Translation { get; set; }

        public virtual Translation TranslationNavigation { get; set; }
        public virtual ICollection<BookAlias> BookAliases { get; set; }
        public virtual ICollection<BookDescription> BookDescriptions { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
