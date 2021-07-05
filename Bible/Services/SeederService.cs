using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bible.Entities;

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
            // Only insert the translations that aren't in the database yet
            var translateInsert = translations.Where(s => !context.Translations.Contains(s));
            await context.Translations.AddRangeAsync(translateInsert);

            // Only insert the books where the translation isn't on the database yet
            var translationIds = translateInsert.Select(s => s.Id);
            await context.Books.AddRangeAsync( bible.Where(s => translationIds.Contains(s.Translation)));

            // Single Save
            await context.SaveChangesAsync(); 

        }
    }
}
