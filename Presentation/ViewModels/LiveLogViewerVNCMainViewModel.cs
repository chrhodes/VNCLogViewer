﻿using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using VNCLogViewer.Core.Events;
using VNCLogViewer.Resources;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerVNCMainViewModel : EventViewModelBase, ILiveLogViewerVNCMainViewModel, IInstanceCountVM
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerVNCMainViewModel(
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
