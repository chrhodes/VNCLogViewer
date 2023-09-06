using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Editors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

using JSONConsoleApp.jsonDeserializeClass;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerMINSKMain : UserControl, ILiveLogViewerVNCMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public LiveLogViewerMINSKMain(ILiveLogViewerViewModelRTB viewModel)
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
            signalRInteraction.ViewModel = (ILiveLogViewerViewModel)ViewModel;
            uiConfig.ViewModel = (ILiveLogViewerViewModel)ViewModel;

            ViewModel.RichTextBox = rtbLogStream;
            ViewModel.LoggingUIConfigFileName = "loggingUIConfigMINSK.json";
            ViewModel.ReloadUIConfig();

            ViewModel.UserName = "MINSK";

            lg_Body_dlm.Activate(lp_RightStuff);
            lp_RightStuff.Visibility = Visibility.Visible;

            // NOTE(crhodes)
            // This works.
            //((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig = new LoggingUIConfig.LoggingUIConfigMINSK();

            // NOTE(crhodes)
            // Now let's try loading from .json

            //Directory.SetCurrentDirectory("D:\\VNC\\git\\chrhodes\\VNCLogViewer\\jsonUIConfig");

            //string jsonString = File.ReadAllText(ViewModel.LoggingUIConfigFileName);
            //LoggingUIConfig_JsonRoot? jsonLoggingUIConfig = JsonSerializer.Deserialize<LoggingUIConfig_JsonRoot>(jsonString);

            //ViewModel.LoggingUIConfig = jsonLoggingUIConfig.ConvertJSONToLoggingUIConfig();

            Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //private void InitializeLogStream()
        //{
        //    rtbLogStream.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
        //    recLogStream.ActiveView.BackColor = System.Drawing.Color.Black;

        //    //Document doc = recLogStream.Document;

        //    //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

        //    Section section = ((ILiveLogViewerViewModel)ViewModel).Doc.Sections[0];

        //    section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
        //    section.Page.Landscape = true;
        //    section.Margins.Left = 0.1f;
        //    section.Margins.Right = 0.1f;
        //}

        #endregion

        #region Enums, Fields, Properties

        public ILiveLogViewerViewModelRTB ViewModel
        {
            get { return (ILiveLogViewerViewModelRTB)DataContext; }
            set { DataContext = value; }
        }

        //public String UserName { get; set; }

        #endregion

        #region Event Handlers

        // NOTE(crhodes)
        // Why would this get called
        //private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        //{
        //    InitializeLogStream();
        //}

        private void rtbLogStream_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lbLastEntry != null) lbLastEntry.Content = DateTime.Now.ToString("HH:mm:ss.fff");

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
            rtbLogStream.SelectAll();
            rtbLogStream.Cut();
            //InitializeLogStream();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            rtbLogStream.SelectAll();
            rtbLogStream.Copy();
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