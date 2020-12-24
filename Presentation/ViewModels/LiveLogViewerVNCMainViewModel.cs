using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using VNCLogViewer.Core.Events;
using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerVNCMainViewModel : ViewModelBase, ILiveLogViewerVNCMainViewModel
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerVNCMainViewModel(
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private LoggingColors _loggingColors = new LoggingColors();

       
        public LoggingColors LoggingColors
        {
            get
            {
                return
                    _loggingColors;
            }
            set
            {
                _loggingColors = value;
                OnPropertyChanged();
            }
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }
    }
}
