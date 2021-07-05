using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Entities
{
    public partial class Chapter
    {
        public Chapter()
        {
            Verses = new HashSet<Verse>();
        }

        public int Id { get; set; }
        public int? ChapterNumber { get; set; }
        public int Book { get; set; }

        public virtual Book BookNavigation { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}
