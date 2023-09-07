﻿using System;
using System.Windows;

using VNCLogViewer.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LogStreamControls : ViewBase, IUIConfig, IInstanceCountV
    {

        #region Constructors and Load
        
        public LogStreamControls()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            
			// Expose ViewModel
						
            // If View First with ViewModel in Xaml

            // ViewModel = (IUIConfigViewModel)DataContext;

            // Can create directly
            // ViewModel = UIConfigViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public UIConfig(IUIConfigViewModel viewModel)
        //{
        //    Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

        //    InstanceCountV++;
        //    InitializeComponent();

        //    ViewModel = viewModel;

        //    Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        #endregion

        #region Enums (None)


        #endregion

        #region Structures (None)


        #endregion

        #region Fields and Properties

        public new ILiveLogViewerViewModel ViewModel
        {
            get { return (ILiveLogViewerViewModel)DataContext; }
            set { DataContext = value; }
        }

        #endregion

        #region Event Handlers (None)


        #endregion

        #region Commands (None)

        #endregion

        #region Public Methods (None)


        #endregion

        #region Protected Methods (None)


        #endregion

        #region Private Methods (None)

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.LogStream is null)
            {
                // Using RichEditControl

                ViewModel.Doc.SelectAll();
                ViewModel.Doc.Cut();
            }
            else
            {
                // Using RichTextBlock

                ViewModel.LogStream.SelectAll();
                ViewModel.LogStream.Cut();
                //InitializeLogStream();
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.LogStream.SelectAll();
            ViewModel.LogStream.Copy();
        }

        #endregion

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
