using Bible.Entities;
using Bible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Services
{
    public interface IQueryService
    {
        Book GetVerseResult (IVerseQuery verseQuery);
    }

    public class QueryService:IQueryService
    {
        public Book GetVerseResult (IVerseQuery verseQuery) {
            return new Book();
        }

    }
}
