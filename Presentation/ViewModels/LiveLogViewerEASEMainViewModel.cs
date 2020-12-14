using System;
using System.Threading.Tasks;

using Prism.Events;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerEASEMainViewModel : ViewModelBase, ILiveLogViewerEASEMainViewModel
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerEASEMainViewModel(
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
            private set
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