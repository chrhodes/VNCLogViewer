using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerEASEDetail : UserControl, ILiveLogViewerEASEDetail
    {

        public LiveLogViewerEASEDetail()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public LiveLogViewerEASEDetail(ViewModels.ILiveLogViewerEASEDetailViewModel viewModel)
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
