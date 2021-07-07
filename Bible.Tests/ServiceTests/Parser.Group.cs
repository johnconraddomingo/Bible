using Bible.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bible.Tests
{
    public class Parser
    { 
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Book_Chapter_Verse_MustGroup()
        {
            var query = "gen 1:1";
            var expected = new List<string> { "gen", "1", ":", "1" };
            var parserService = new ParserService();

            parserService.Parse(query, null);

            Assert.AreEqual(expected, parserService.ParseGroups);
        }

        [Test]
        public void Numbered_Book_Chapter_Verse_MustGroup()
        {
            var query = "1 pet 3:1";
            var expected = new List<string> { "1pet", "3", ":", "1" };
            var parserService = new ParserService();

            parserService.Parse(query, null);

            Assert.AreEqual(expected, parserService.ParseGroups);
        }

        [Test]
        public void Numbered_Book_Chapter_Verse_Range_MustGroup()
        {
            var query = "1 pet 3:1-2";
            var expected = new List<string> { "1pet", "3", ":", "1", "-", "2"  };
            var parserService = new ParserService();

            parserService.Parse(query, null);

            Assert.AreEqual(expected, parserService.ParseGroups);
        }

        [Test]
        public void Book_Chapter_Verse_Range_MustGroup()
        {
            var query = "lev 3:1-2";
            var expected = new List<string> { "lev", "3", ":", "1", "-", "2" };
            var parserService = new ParserService();

            parserService.Parse(query, null);

            Assert.AreEqual(expected, parserService.ParseGroups);
        }

 
    }
}