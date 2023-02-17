using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Document.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Document.Workers;

public class ChangeExpiredDocumentStatusJob : IHostedService
{
    private readonly DataContext _context;

    public ChangeExpiredDocumentStatusJob(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<DataContext>();
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            var expiredDocuments = await _context.Documents.Where(x => x.EndDateTime >= DateTime.Now && x.StatusId != 5)
                .ToListAsync(cancellationToken);
            foreach (var expiredDocument in expiredDocuments)
            {
                expiredDocument.StatusId = 5;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _context.Dispose();
        return Task.CompletedTask;
    }
}