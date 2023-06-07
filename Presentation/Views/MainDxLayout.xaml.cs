using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class MainDxLayout : Window, IInstanceCountV
    {
        public MainDxLayoutViewModel _viewModel;

        public MainDxLayout(MainDxLayoutViewModel viewModel)
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
