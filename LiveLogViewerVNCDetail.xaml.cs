using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerVNCDetail : UserControl, ILiveLogViewerVNCDetail
    {

        public LiveLogViewerVNCDetail()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public LiveLogViewerVNCDetail(ViewModels.ILiveLogViewerVNCDetailViewModel viewModel)
        {
            Int64 startTicks = Log.Trace($"Enter ({viewModel.GetType()})", Common.LOG_APPNAME);

            InitializeComponent();
            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
