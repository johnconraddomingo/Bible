using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Models
{
    public interface IVerseQuery
    {
        string TranslationCode { get; set; }
        string Book { get; set; }
        int Chapter { get; set; }
        int [] Verses { get; set; }
    }

    public class VerseQuery : IVerseQuery
    {
        public string TranslationCode { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int [] Verses { get; set; }       
    }
}
