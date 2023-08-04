using System.Windows.Controls;

namespace VNCLogViewer.Presentation.ViewModels
{
    public interface ILiveLogViewerViewModelRTB : ILiveLogViewerViewModel
    {
        RichTextBox RichTextBox { get; set; }
    }
}
