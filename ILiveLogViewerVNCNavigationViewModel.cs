using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerVNCNavigationViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
