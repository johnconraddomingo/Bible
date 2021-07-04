using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class Translation
    {
        public Translation()
        {
            BookDescriptions = new HashSet<BookDescription>();
            Verses = new HashSet<Verse>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string TranslationCode { get; set; }
        public string TranslationName { get; set; }

        public virtual ICollection<BookDescription> BookDescriptions { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}
