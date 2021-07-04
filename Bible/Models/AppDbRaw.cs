using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Models
{
    public class AppDbRaw
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookDescription> BookDescriptions { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
        public IEnumerable<Footnote> Footnotes { get; set; }
        public IEnumerable<Title> Titles { get; set; }
        public IEnumerable<Translation> Translations { get; set; }
        public IEnumerable<Verse> Verses { get; set; }
    }
}
