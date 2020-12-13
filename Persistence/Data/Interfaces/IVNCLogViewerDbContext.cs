using System.Data.Entity;

using VNCLogViewer.Domain;

namespace VNCLogViewer.Persistence.Data
{
    public interface IVNCLogViewerDbContext
    {
        int SaveChanges();

        //DbSet<Dog> DogSet { get; set; }
    }
}
