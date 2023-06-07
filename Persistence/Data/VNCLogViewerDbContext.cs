using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using VNCLogViewer.Domain;

namespace VNCLogViewer.Persistence.Data
{
    public class VNCLogViewerDbContext : DbContext, IVNCLogViewerDbContext
    {
        // TODO(crhodes)
        // Add additional DbSet<TYPE> as needed.

        public DbSet<LiveLogViewerEASE> LiveLogViewerEASESet { get; set; }
        public DbSet<LiveLogViewerVNC> LiveLogViewerVNCSet { get; set; }

        // Name of connection string in Config

        public VNCLogViewerDbContext() : base("VNCLogViewer_DB")
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<VNCLogViewerDbContext, Configuration>());

            // There are four database initialization strategies

            // 1. CreateDatabaseIfNotExists (default)

            // Database.SetInitializer<VNCLogViewerDbContext>(new CreateDatabaseIfNotExists<VNCLogViewerDbContext>());

            // 2. DropCreateDatabaseIfModelChanges

            // Database.SetInitializer<VNCLogViewerDbContext>(new DropCreateDatabaseIfModelChanges<VNCLogViewerDbContext>());

            Database.SetInitializer<VNCLogViewerDbContext>(
                new DropCreateDatabaseIfModelChanges<VNCLogViewerDbContext>());

            // 3. DropCreateDatabaseAlways

            // Database.SetInitializer<VNCLogViewerDbContext>(new DropCreateDatabaseAlways<VNCLogViewerDbContext>());

            // 4. Custom DB Initializer

            //Database.SetInitializer<VNCLogViewerDbContext>(new VNCLogViewerDbContextDatabaseInitializer());

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            try
            {
                // TODO(crhodes)
                // This gives us too many types including the embedded ServiceType and PoolConditionReport
                // Need some way of filtering them out, otherwise have to put pointless IsDirty field in them.

                modelBuilder.Types()
                    .Configure(c => c.Ignore("IsDirty"));

            }
            catch (InvalidOperationException ex)
            {
                // Ignore
            }

            base.OnModelCreating(modelBuilder);

            // Do not pluralize table names

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.HasDefaultSchema("Domain");

            // Ignore any IsDirty property on any types pulled into model.



            // Fluent API approach to constraints
            // Alternative is to apply attributes to Model Class

            //modelBuilder.Entity<Friend>()
            //    .Property(f => f.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Could also have a general purpose approach. See class infra.

            //modelBuilder.Configurations.Add(new FriendConfiguration());

            // Alternatively can use DataAnnotations on model class.
            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public override int SaveChanges()
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            try
            {
                // Override SaveChanges so EF will enforce use of IModificationHistory changes.

                var hist = this.ChangeTracker.Entries();

                foreach (var item in hist)
                {
                    var isImod = item is IModificationHistory;
                    int i = 0;
                }

                foreach (var history in this.ChangeTracker.Entries()
                  .Where(e => e.Entity is IModificationHistory
                    && (e.State == EntityState.Added || e.State == EntityState.Modified))
                   .Select(e => e.Entity as IModificationHistory)
                  )
                {
                    history.DateModified = DateTime.Now;

                    // Use DateCreated DateTime.MinValue as new flag

                    var dt = DateTime.MinValue;
                    var dt2 = SqlDateTime.MinValue;
                    var hdc = history.DateCreated;

                    //if (history.DateCreated == DateTime.MinValue)
                    //{
                    //    history.DateCreated = DateTime.Now;
                    //}

                    if (history.DateCreated == null)
                    {
                        history.DateCreated = DateTime.Now;
                    }
                }

                // Save changes to database.

                int result = base.SaveChanges();

                // Reset the IsDirty flag on any entities implementing INotificationHistory

                foreach (var history in this.ChangeTracker.Entries()
                                              .Where(e => e.Entity is IModificationHistory)
                                              .Select(e => e.Entity as IModificationHistory))
                {
                    history.IsDirty = false;
                }

                return result;
                //return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Display some details on errors

                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public override async Task<int> SaveChangesAsync()
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            try
            {
                // Override SaveChanges so EF will enforce use of IModificationHistory changes.

                var hist = this.ChangeTracker.Entries();

                foreach (var item in hist)
                {
                    var isImod = item is IModificationHistory;
                    int i = 0;
                }

                foreach (var history in this.ChangeTracker.Entries()
                  .Where(e => e.Entity is IModificationHistory
                    && (e.State == EntityState.Added || e.State == EntityState.Modified))
                   .Select(e => e.Entity as IModificationHistory)
                  )
                {
                    history.DateModified = DateTime.Now;

                    // Use DateCreated DateTime.MinValue as new flag

                    var dt = DateTime.MinValue;
                    var dt2 = SqlDateTime.MinValue;
                    var hdc = history.DateCreated;

                    //if (history.DateCreated == DateTime.MinValue)
                    //{
                    //    history.DateCreated = DateTime.Now;
                    //}

                    if (history.DateCreated == null)
                    {
                        history.DateCreated = DateTime.Now;
                    }
                }

                // Save changes to database.

                int result = await base.SaveChangesAsync();

                // Reset the IsDirty flag on any entities implementing INotificationHistory

                foreach (var history in this.ChangeTracker.Entries()
                                              .Where(e => e.Entity is IModificationHistory)
                                              .Select(e => e.Entity as IModificationHistory))
                {
                    history.IsDirty = false;
                }

                return result;
                //return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Display some details on errors

                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }



        //public class AddressConfiguration : EntityTypeConfiguration<Address>
        //{

        //    public AddressConfiguration()
        //    {
        //        //Property(f => f.FirstName)
        //        //    .IsRequired()
        //        //    .HasMaxLength(50);
        //    }
        //}

    }
}
