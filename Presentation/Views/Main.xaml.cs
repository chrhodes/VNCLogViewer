using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;
using VNCLogViewer.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class Main : ViewBase, IMain, IInstanceCountV
    {
        public MainViewModel _viewModel;

        public Main(MainViewModel viewModel)
        {
            Int64 startTicks = Log.Trace(String.Format("Enter"), Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
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
