using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Models
{
    public partial class Title
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? Verse { get; set; }

        public virtual Verse VerseNavigation { get; set; }
    }
}
