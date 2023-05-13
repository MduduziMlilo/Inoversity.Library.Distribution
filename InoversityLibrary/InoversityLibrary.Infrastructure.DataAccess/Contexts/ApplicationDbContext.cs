using System.Reflection;
using InoversityLibrary.Domain.Common;
using InoversityLibrary.Domain.Common.Interfaces;
using InoversityLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InoversityLibrary.DataAccess.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IDomainEventDispatcher dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Document> Documents => Set<Document>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Document>()
            .ToTable("Documents", "InoversityLibrary");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}