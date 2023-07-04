using System.Threading.Tasks;

using DevExpress.XtraRichEdit.API.Native;


using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerViewModel : IViewModel
    {
        Task LoadAsync();

        void ConnectAsync();

        void Send();
        void SendPriority();

        // HACK(crhodes)
        // How does one handle this without ugly circular references to projects

        //LoggingColors LoggingColors { get; set; }
        //LoggingUIConfig LoggingUIConfig { get; set; }

        //void SetLoggingUIConfig(LoggingUIConfig loggingUIConfig);

        Document Doc { get; set; }
    }
}
