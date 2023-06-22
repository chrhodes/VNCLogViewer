﻿using System;
using System.Threading.Tasks;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerEASEMainViewModel : EventViewModelBase, ILiveLogViewerEASEMainViewModel, IInstanceCountVM
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerEASEMainViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            // TODO(crhodes)
            //

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
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

        private LoggingUIConfig _loggingUIConfig = new LoggingUIConfig();

        public LoggingUIConfig LoggingUIConfig
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