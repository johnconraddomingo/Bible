using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Verses = new HashSet<Verse>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? ChapterNumber { get; set; }
        public int Book { get; set; }

        public virtual Book BookNavigation { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}
