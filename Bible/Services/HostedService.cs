using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Bible.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Bible.Services
{
    public class SeederHostedService : IHostedService
    { 
        private readonly IServiceProvider _serviceProvider;
        private readonly string _source;

        public SeederHostedService(IServiceProvider serviceProvider, string source)
        {
            _serviceProvider = serviceProvider;
            _source = source;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        { 
            using var scope = _serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var seederService = scope.ServiceProvider.GetRequiredService<ISeederService>();

            // Temporary Solution
            var tContents = await File.ReadAllTextAsync(Path.Combine( _source, "translations.json"), cancellationToken);
            var bContents = await File.ReadAllTextAsync(Path.Combine(_source, "books.json"), cancellationToken);

            var translations = JsonConvert.DeserializeObject<IEnumerable<Translation>>(tContents);
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(bContents);
           
            // Production Solution 
            // var httpService = scope.ServiceProvider.GetRequiredService<IHttpService>();
            // var sourceObject = await httpService.GetObjectResponse<AppDbRaw>(_source);

            await seederService.Seed(dbContext, translations, books );
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
