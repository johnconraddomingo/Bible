using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class Footnote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FootnoteText { get; set; }
        public int? Verse { get; set; }

        public virtual Verse VerseNavigation { get; set; }
    }
}
