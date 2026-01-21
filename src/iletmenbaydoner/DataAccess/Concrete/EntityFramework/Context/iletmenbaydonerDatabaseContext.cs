using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using iletmenbaydoner.Entities.Core;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entites.Concrete;


public class iletmenbaydonerDatabaseContext : DbContext
{
    //entities
    public DbSet<Client> Clients { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductGroupType> ProductGroupTypes { get; set; }
    public DbSet<BranchProduct> BranchProducts { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }


    public iletmenbaydonerDatabaseContext(DbContextOptions<iletmenbaydonerDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // OrderHeaders: OrderNo is unique in DB, tell EF it's an alternate key
        modelBuilder.Entity<OrderHeader>()
            .HasAlternateKey(h => h.OrderNo);

        // OrderDetails -> OrderHeaders via OrderNo (string) instead of OrderHeaderId (long)
        modelBuilder.Entity<OrderDetail>()
            .HasOne(d => d.OrderHeader)
            .WithMany() // or .WithMany(h => h.OrderDetails) if you add the collection navigation
            .HasForeignKey(d => d.OrderNo)
            .HasPrincipalKey(h => h.OrderNo);

        base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        var modified = ChangeTracker.Entries().Where(q => q.State == EntityState.Modified);
        PreSaveChangesTasks(modified);

        int result;
        try
        {
            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            result = base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
            throw;
        }



        return result;
    }
    private void PreSaveChangesTasks(IEnumerable<EntityEntry> modified)
    {


        foreach (var item in modified)
        {
            if (item.Properties.Any(q => q.IsModified))
            {
                var entity = (item.Entity as EntityBaseModel);
                entity.UpdatedDate = DateTimeOffset.Now;
            }
        }

    }

}