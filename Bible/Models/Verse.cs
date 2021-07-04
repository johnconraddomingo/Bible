using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class Verse
    {
        public Verse()
        {
            Footnotes = new HashSet<Footnote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? VerseNumber { get; set; }
        public string Text { get; set; }
        public int? Translation { get; set; }
        public int? Chapter { get; set; }

        public virtual Chapter ChapterNavigation { get; set; }
        public virtual Translation TranslationNavigation { get; set; }
        public virtual ICollection<Footnote> Footnotes { get; set; }
    }
}
