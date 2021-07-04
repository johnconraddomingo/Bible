using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Bible.Models
{
    public partial class Book
    {
        public Book()
        {
            BookDescriptions = new HashSet<BookDescription>();
            Chapters = new HashSet<Chapter>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string BookName { get; set; }

        public virtual ICollection<BookDescription> BookDescriptions { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
