using Bible.Entities;
using Bible.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Services
{

    // This is too critical to the application, therefore I decided it to be a Service instead of a Helper
    

    public interface IParserService
    {
        IEnumerable<IVerseQuery> Parse (string query, string translation);
        IEnumerable<string> ParseGroups { get; }
    }

    public class ParserService : IParserService
    {
        public IEnumerable<string> ParseGroups { get; private set; }

        private string fullQuery;
        private int max ;


        public IEnumerable<IVerseQuery> Parse(string query, string translation) 
        {
                  

            fullQuery = query.Replace(" ","").ToLower();
            max = fullQuery.Length - 1;

            if (fullQuery.Length <= 3) throw new FormatException("Query cannot be parse to a verse.");

            ParseGroups = Group();

            // TODO: Form Verses out of the Groups

            return null;
        }

        private IEnumerable<string> Group()
        {
            
            var current = 0;
            var from = current;
            var groups = new List<string>();

            while (current <= max)
            {                
                current = GroupEnd(current);
                var newEnd = current - from;
                groups.Add( fullQuery.Substring(from, newEnd));
                from = current;            
            }

            return groups;
        }

        private int GroupEnd(int startingPoint) 
        {
            var currentCharacter = fullQuery[startingPoint];
            var currentCategoryType = char.GetUnicodeCategory(currentCharacter);


            var mover = startingPoint + 1;
            var numberedBook = false;
            while (mover<= max) {

                // Get the new type
                var nextCategoryType = char.GetUnicodeCategory(fullQuery[mover]);
                if (nextCategoryType == currentCategoryType)
                {
                    // Numbered Book? Break here.
                    if (numberedBook)
                    { break; }
                    // Same type? Just move to the next one.
                    mover++;

                }
                else
                {
                    // Not the same? Consider numbered books
                    if (currentCategoryType == UnicodeCategory.DecimalDigitNumber && nextCategoryType == UnicodeCategory.LowercaseLetter) 
                    {
                        numberedBook = true;
                        mover++;
                    }
                    else
                    {
                        // Stop
                        break;
                    }                
                }

            }

            return mover  ;
        }
         
    }
}
