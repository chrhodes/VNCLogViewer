using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerEASEDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
