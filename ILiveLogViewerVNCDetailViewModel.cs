using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerVNCDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
