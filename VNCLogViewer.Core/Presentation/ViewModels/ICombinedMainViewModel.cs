using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ICombinedMainViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
