﻿using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Editors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

using JSONConsoleApp.jsonDeserializeClass;

using Microsoft.AspNetCore.SignalR.Client;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerEASEMain : UserControl, ILiveLogViewerEASEMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public LiveLogViewerEASEMain(ILiveLogViewerViewModelREC viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            //DataContext = ViewModel;

            InitializeView();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeView()
        {
            Int64 startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            lgCaptureFilter.IsCollapsed = true;
            signalRInteraction.ViewModel = ViewModel;
            uiConfig.ViewModel = ViewModel;

            ViewModel.Doc = recLogStream.Document;
            ViewModel.LoggingUIConfigFileName = "loggingUIConfigEASE.json";
            ViewModel.ReloadUIConfig();

            ViewModel.UserName = "EASE";

            lg_Body_dlm.Activate(lp_RightStuff);
            lp_RightStuff.Visibility = Visibility.Visible;
            
            Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeLogStream()
        {
            recLogStream.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
            recLogStream.ActiveView.BackColor = System.Drawing.Color.Black;

            //Document doc = recLogStream.Document;

            //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

            Section section = ((ILiveLogViewerViewModelREC)ViewModel).Doc.Sections[0];

            section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
            section.Page.Landscape = true;
            section.Margins.Left = 0.1f;
            section.Margins.Right = 0.1f;
        }

        #endregion

        #region Enums, Fields, Properties

        public ILiveLogViewerViewModelREC ViewModel
        {
            get { return (ILiveLogViewerViewModelREC)DataContext; }
            set { DataContext = value; }
        }

        //public String UserName { get; set; }

        #endregion

        #region Event Handlers

        private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            InitializeLogStream();
        }


        private void recLogStream_TextChanged(object sender, EventArgs e)
        {
            lbLastEntry.Content = DateTime.Now.ToString("HH:mm:ss.fff");

            // TODO(crhodes)
            // See if can do this with a RichEditControl control

            //if (ceAutoUpdate.IsChecked == true)
            //{
            //    recLogStream.Focus();
            //    recLogStream.SelectionStart = recLogStream.Text.Length;
            //}
        }

        private void btnUpdateScreen_Click(object sender, RoutedEventArgs e)
        {
            // TODO(crhodes)
            // See if can do this with a RichEditControl control

            //recLogStream.Focus();
            //recLogStream.SelectionStart = recLogStream.Text.Length;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //recLogStream.Clear();
            recLogStream.Text = "";
            InitializeLogStream();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            recLogStream.SelectAll();
            recLogStream.Copy();
        }

        #endregion

        #region Private Methods (none)

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
