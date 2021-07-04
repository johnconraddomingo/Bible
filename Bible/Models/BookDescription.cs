using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class BookDescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Book { get; set; }
        public int? Translation { get; set; }

        public virtual Book BookNavigation { get; set; }
        public virtual Translation TranslationNavigation { get; set; }
    }
}
