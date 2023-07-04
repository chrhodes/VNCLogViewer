using System;
using System.Threading.Tasks;

using DevExpress.XtraRichEdit.API.Native;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using luic = VNCLogViewer.LoggingUIConfig;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerVNCMainViewModel : EventViewModelBase, ILiveLogViewerViewModel, IInstanceCountVM
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerVNCMainViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            // TODO(crhodes)
            // Save constructor parameters here

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            //

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public Document Doc { get; set; }

        private luic.LoggingColors _loggingColors = new luic.LoggingColors();
       
        public luic.LoggingColors LoggingColors
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

        private luic.LoggingUIConfig _loggingUIConfig = new luic.LoggingUIConfig();

        public luic.LoggingUIConfig LoggingUIConfig
        {
            get => _loggingUIConfig;
            set
            {
                if (_loggingUIConfig == value)
                    return;
                _loggingUIConfig = value;
                OnPropertyChanged();
            }
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void SendPriority()
        {
            throw new NotImplementedException();
        }

        public void UpdateLoggingUIConfig()
        {
            throw new NotImplementedException();
        }

        #region IInstanceCount

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
