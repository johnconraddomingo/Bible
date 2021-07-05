using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Models
{
    public partial class BookAlias
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int? Book { get; set; }

        public virtual Book BookNavigation { get; set; }
    }
}
