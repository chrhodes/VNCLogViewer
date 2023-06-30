using System;
using System.Data.Entity;

using VNC;

namespace VNCLogViewer.Persistence.Data
{
    public class VNCLogViewerDbContextDatabaseInitializer : CreateDatabaseIfNotExists<VNCLogViewerDbContext>
    {
        protected override void Seed(VNCLogViewerDbContext context)
        {
            Int64 startTicks = Log.PERSISTENCE("Enter", Common.LOG_CATEGORY);

            base.Seed(context);

            Log.PERSISTENCE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
