using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bible.Models;

namespace Bible.Services
{
    public interface ISeederService
    {
        Task Seed(AppDbContext context, IEnumerable<Translation> translations, IEnumerable<Book> bible);
    }

    public class SeederService : ISeederService
    {
        public async Task Seed(AppDbContext context, IEnumerable<Translation> translations, IEnumerable<Book> bible)
        {
            var translateInsert = translations.Where(s => context.Translations.Contains(s));
            await context.Translations.AddRangeAsync(translateInsert);

            if (!context.Books.Any()) await context.Books.AddRangeAsync(bible);
            await context.SaveChangesAsync(); 

        }
    }
}
