using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Models
{
    public partial class Verse
    {
        public Verse()
        {
            Footnotes = new HashSet<Footnote>();
            Titles = new HashSet<Title>();
        }

        public int Id { get; set; }
        public int? VerseNumber { get; set; }
        public string Text { get; set; }
        public int? Chapter { get; set; }

        public virtual Chapter ChapterNavigation { get; set; }
        public virtual ICollection<Footnote> Footnotes { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
    }
}
