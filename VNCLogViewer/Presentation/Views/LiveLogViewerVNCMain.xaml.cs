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
    public partial class LiveLogViewerVNCMain : UserControl, ILiveLogViewerVNCMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public LiveLogViewerVNCMain(ILiveLogViewerViewModelREC viewModel)
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

            ViewModel.Doc = recLogStream.Document;
            ViewModel.LoggingUIConfigFileName = "loggingUIConfigDefault.json";
            ViewModel.ReloadUIConfig();

            ViewModel.UserName = "VNC";

            lg_Body_dlm.Activate(lp_RightStuff);
            lp_RightStuff.Visibility = Visibility.Visible;

            //ViewModel.RichTextBox = rtbConsoleStream;

            // NOTE(crhodes)
            // This works.
            //((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig = new LoggingUIConfig.LoggingUIConfigMINSK();

            // NOTE(crhodes)
            //// Now let's try loading from .json

            //Directory.SetCurrentDirectory(:jsonUIConfig");

            //string jsonString = File.ReadAllText(ViewModel.LoggingUIConfigFileName);
            //LoggingUIConfig_JsonRoot? jsonLoggingUIConfig = JsonSerializer.Deserialize<LoggingUIConfig_JsonRoot>(jsonString);

            //ViewModel.LoggingUIConfig = jsonLoggingUIConfig.ConvertJSONToLoggingUIConfig();

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

        // NOTE(crhodes)
        // Why would this get called
        private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            InitializeLogStream();
        }

        //private void btnSignIn_Click(object sender, RoutedEventArgs e)
        //{
        //    UserName = UserNameTextBox.Text;
        //    //Connect to server (use async method to avoid blocking UI thread)
        //    if (!String.IsNullOrEmpty(UserName))
        //    {
        //        StatusText.Visibility = Visibility.Visible;
        //        StatusText.Content = "Connecting to server...";

        //        ViewModel.ConnectAsync();
        //        //ConnectAsync();

        //        //Show chat UI; hide login UI
        //        SignInPanel.Visibility = Visibility.Collapsed;
        //        ChatPanel.Visibility = Visibility.Visible;
        //        btnSend.IsEnabled = true;
        //        btnSendPriority.IsEnabled = true;
        //        tbMessage.Focus();
        //    }
        //}

        //private async void btnSend_Click(object sender, RoutedEventArgs e)
        //{
        //    //await Connection.InvokeAsync("SendUserMessage", UserName, tbMessage.Text);
        //    ViewModel.Send();

        //    tbMessage.Text = String.Empty;

        //    tbMessage.Focus();
        //}

        //private async void btnSendPriority_Click(object sender, RoutedEventArgs e)
        //{
        //    //await Connection.InvokeAsync("SendPriorityMessage", tbMessage.Text, Int32.Parse(tbMessagePriority.Text));
        //    ViewModel.SendPriority();

        //    tbMessage.Text = String.Empty;
        //    tbMessage.Focus();
        //}

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