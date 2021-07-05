using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Models
{
    public interface IVerseQuery {
        string TranslationCode { get; set; }
        string Book { get; set; }
        string Chapter { get; set; }
        string Verses { get; set; }
    }

    public class VerseQuery : IVerseQuery
    { 
       public string TranslationCode { get; set; }
       public string Book { get; set; }
       public string Chapter { get; set; }
       public string Verses { get; set; }

        public VerseQuery(string query, string translation) {

            // E.g.
            //
            // gen 1:1
            // gen1:1
            // gen 1 : 1
            // gen 1:1-2
            // 1pet1:1
            // 1 pet 1 : 1
            // 
             
        }

    }
}
