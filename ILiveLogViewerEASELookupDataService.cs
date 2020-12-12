using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace VNCLogViewer.DomainServices
{
    public interface ILiveLogViewerEASELookupDataService
    {
        Task<IEnumerable<LookupItem>> GetLiveLogViewerEASELookupAsync();
    }
}
