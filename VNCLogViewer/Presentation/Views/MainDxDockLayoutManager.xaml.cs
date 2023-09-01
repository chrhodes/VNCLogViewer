using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;
using VNCLogViewer.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class MainDxDockLayoutManager : ViewBase, IMain, IInstanceCountV
    {
        public MainDxDockLayoutManagerViewModel _viewModel;

        public MainDxDockLayoutManager(MainDxDockLayoutManagerViewModel viewModel)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }

        private void SaveLayout_Click(object sender, RoutedEventArgs e)
        {
            dlm.SaveLayoutToXml(Common.cCONFIG_FILE);
        }

        private void RestoreLayout_Click(object sender, RoutedEventArgs e)
        {
            dlm.RestoreLayoutFromXml(Common.cCONFIG_FILE);
        }

        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion
    }
}
