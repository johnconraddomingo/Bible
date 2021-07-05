using System;
using System.Collections.Generic;

#nullable disable

namespace Bible.Entities
{
    public partial class Translation
    {
        public Translation()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string TranslationCode { get; set; }
        public string TranslationName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
