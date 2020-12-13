using System.Collections.Generic;
using System.Threading.Tasks;

using VNC.Core.DomainServices;

namespace VNCLogViewer.DomainServices
{
    public interface ILiveLogViewerVNCLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetLiveLogViewerVNCLookupAsync();
    }
}
