using System;
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

            ViewModel.Doc = logStream.Document;
            //InitializeLogStream();

            ViewModel.LoggingUIConfigFileName = "loggingUIConfigEASE.json";
            ViewModel.ReloadUIConfig();

            ViewModel.UserName = "EASE";

            lg_Body_dlm.Activate(lp_RightStuff);
            lp_RightStuff.Visibility = Visibility.Visible;
            
            Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // NOTE(crhodes)
        // It takes awhile for the RichEditControl to load.
        // Cannot do this in InitializeView
        private void logStreamLoaded(object sender, RoutedEventArgs e)
        {
            logStream.Views.SimpleView.BackColor = Color.Black;
        }

        //private void InitializeLogStream()
        //{
        //    if (logStream == null)
        //    {

        //    }
        //    //logStream.Views.SimpleView.BackColor = Color.Blue;
        //    //logStream.ActiveViewType = RichEditViewType.Simple;
        //    //logStream.Background = System.Windows.Media.Brushes.Blue;

        //    //logStream.ActiveViewType = (RichEditViewType)logStreamControls.cbeRichEditViewType.SelectedIndex;
        //    //logStream.ActiveView.BackColor = System.Drawing.Color.Black;

        //    //Document doc = recLogStream.Document;

        //    //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

        //    //Section section = ((ILiveLogViewerViewModelREC)ViewModel).Doc.Sections[0];

        //    //section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
        //    //section.Page.Landscape = true;
        //    //section.Margins.Left = 0.1f;
        //    //section.Margins.Right = 0.1f;
        //}

        #endregion

        #region Enums, Fields, Properties

        public ILiveLogViewerViewModelREC ViewModel
        {
            get { return (ILiveLogViewerViewModelREC)DataContext; }
            set { DataContext = value; }
        }

        #endregion

        #region Event Handlers

        private void logStream_TextChanged(object sender, EventArgs e)
        {
            if (logStreamControls != null)
            {
                if (logStreamControls.lbLastEntry != null) logStreamControls.lbLastEntry.Content = DateTime.Now.ToString("HH:mm:ss.fff");
            }
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
