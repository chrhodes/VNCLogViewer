using System.Threading.Tasks;

using VNC.Core.Mvvm;

using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerEASEMainViewModel : IViewModel
    {
        Task LoadAsync();
        LoggingColors LoggingColors { get; set; }
        LoggingUIConfig LoggingUIConfig { get; set; }
    }
}
