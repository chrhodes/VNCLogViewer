using System;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Editors;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerVNCMain : UserControl, ILiveLogViewerVNCMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        //public LiveLogViewerVNCMain(ILiveLogViewerViewModelREC viewModel)
        public LiveLogViewerVNCMain(ILiveLogViewerViewModelRTB viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;

            InitializeView();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeView()
        {
            Int64 startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            lgCaptureFilter.IsCollapsed = true;
            signalRInteraction.ViewModel = ViewModel;

            //ViewModel.Doc = logStream.Document;
            ViewModel.LogStream = logStream;

            ViewModel.LoggingUIConfigFileName = "loggingUIConfigDefault.json";
            ViewModel.ReloadUIConfig();

            //ViewModel.UserName = "VNC";
            signalRInteraction.UserName = "VNC";

            lg_Body_dlm.Activate(lp_RightStuff);
            lp_RightStuff.Visibility = Visibility.Visible;

            Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //private void InitializeLogStream()
        //{
        //    logStream.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
        //    logStream.ActiveView.BackColor = System.Drawing.Color.Black;

        //    //Document doc = recLogStream.Document;

        //    //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

        //    Section section = ((ILiveLogViewerViewModelREC)ViewModel).Doc.Sections[0];

        //    section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
        //    section.Page.Landscape = true;
        //    section.Margins.Left = 0.1f;
        //    section.Margins.Right = 0.1f;
        //}

        #endregion

        #region Enums, Fields, Properties

        //public ILiveLogViewerViewModelREC ViewModel
        //{
        //    get { return (ILiveLogViewerViewModelREC)DataContext; }
        //    set { DataContext = value; }
        //}

        public ILiveLogViewerViewModelRTB ViewModel
        {
            get { return (ILiveLogViewerViewModelRTB)DataContext; }
            set { DataContext = value; }
        }

        #endregion

        #region Event Handlers

        //private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        //{
        //    //InitializeLogStream();
        //}

        private void logStream_TextChanged(object sender, EventArgs e)
        {
            if (logStreamControls != null)
            {
                if (logStreamControls.lbLastEntry != null) logStreamControls.lbLastEntry.Content = DateTime.Now.ToString("HH:mm:ss.fff");
            }
        }

        //private void btnClear_Click(object sender, RoutedEventArgs e)
        //{
        //    logStream.SelectAll();
        //    logStream.Cut();
        //    //InitializeLogStream();
        //}

        //private void btnCopy_Click(object sender, RoutedEventArgs e)
        //{
        //    logStream.SelectAll();
        //    logStream.Copy();
        //}

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