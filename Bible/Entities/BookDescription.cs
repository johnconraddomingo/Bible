using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Entities
{
    public partial class BookDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Book { get; set; }

        public virtual Book BookNavigation { get; set; }
    }
}
