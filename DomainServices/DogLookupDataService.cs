using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using VNCLogViewer.Persistence.Data;

namespace VNCLogViewer.DomainServices
{
    public class DogLookupDataService : IDogLookupDataService
    {
        private Func<VNCLogViewerDbContext> _contextCreator;

        public DogLookupDataService(Func<VNCLogViewerDbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR(String.Format("Enter"), Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LookupItem>> GetDogLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var ctx = _contextCreator())
            {
                return await ctx.DogSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FieldString
                  })
                  .ToListAsync();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
