using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Entities
{
    public partial class Footnote
    {
        public int Id { get; set; }
        public string FootnoteText { get; set; }
        public int? Verse { get; set; }

        public virtual Verse VerseNavigation { get; set; }
    }
}
