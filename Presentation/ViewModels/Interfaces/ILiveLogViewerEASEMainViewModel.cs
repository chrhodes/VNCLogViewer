using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerEASEMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
