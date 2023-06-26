using System.Threading.Tasks;

using DevExpress.XtraRichEdit.API.Native;

using VNC.Core.Mvvm;

using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerViewModel : IViewModel
    {
        Task LoadAsync();

        void ConnectAsync();

        void Send();
        void SendPriority();

        LoggingColors LoggingColors { get; set; }
        LoggingUIConfig LoggingUIConfig { get; set; }

        public Document Doc { get; set; }
    }
}
