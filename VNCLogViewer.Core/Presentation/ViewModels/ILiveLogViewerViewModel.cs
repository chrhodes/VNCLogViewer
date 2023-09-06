﻿using System.Threading.Tasks;
using System.Windows.Controls;

using DevExpress.XtraRichEdit.API.Native;


using VNC.Core.Mvvm;
using luic = VNCLogViewer.LoggingUIConfig;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerViewModel : IViewModel
    {
        Task LoadAsync();

        void ConnectAsync();
        void StopAsync();
        void DisposeAsync();

        void Send();
        void SendPriority();

        // HACK(crhodes)
        // How does one handle this without ugly circular references to projects

        //LoggingColors LoggingColors { get; set; }
        luic.LoggingUIConfig LoggingUIConfig { get; set; }

        string LoggingUIConfigFileName { get; set; }

        void ReloadUIConfig();

        //void SetLoggingUIConfig(LoggingUIConfig loggingUIConfig);

        Document Doc { get; set; }

        RichTextBox RichTextBox { get; set; }

        string UserName { get; set; }

        int HilightOffset { get; set; }
    }
}
