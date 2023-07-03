using System;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Editors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerVNC2Main : UserControl, ILiveLogViewerVNCMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public LiveLogViewerVNC2Main(ILiveLogViewerViewModel viewModel)
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
            lgCaptureFilter.IsCollapsed = true;
            signalRInteraction.ViewModel = ViewModel;

            ((ILiveLogViewerViewModel)ViewModel).Doc = recLogStream.Document;
        }

        private void InitializeLogStream()
        {
            recLogStream.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
            recLogStream.ActiveView.BackColor = System.Drawing.Color.Black;

            //Document doc = recLogStream.Document;

            //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

            Section section = ((ILiveLogViewerViewModel)ViewModel).Doc.Sections[0];

            section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
            section.Page.Landscape = true;
            section.Margins.Left = 0.1f;
            section.Margins.Right = 0.1f;
        }

        #endregion

        #region Enums, Fields, Properties

        public ILiveLogViewerViewModel ViewModel
        {
            get { return (ILiveLogViewerViewModel)DataContext; }
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

        private void btnInfoToggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnInfoToggle.Content == "All Off")
            {
                ceInfo00.IsChecked = false;
                ceInfo01.IsChecked = false;
                ceInfo02.IsChecked = false;
                ceInfo03.IsChecked = false;
                ceInfo04.IsChecked = false;

                btnInfoToggle.Content = "All On";
            }
            else
            {
                ceInfo00.IsChecked = true;
                ceInfo01.IsChecked = true;
                ceInfo02.IsChecked = true;
                ceInfo03.IsChecked = true;
                ceInfo04.IsChecked = true;

                btnInfoToggle.Content = "All Off";
            }
        }

        private void btnDebugToggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnDebugToggle.Content == "All Off")
            {
                ceDebug00.IsChecked = false;
                ceDebug01.IsChecked = false;
                ceDebug02Enter.IsChecked = false;
                ceDebug02Exit.IsChecked = false;
                ceDebug03.IsChecked = false;
                ceDebug04.IsChecked = false;

                btnDebugToggle.Content = "All On";
            }
            else
            {
                ceDebug00.IsChecked = true;
                ceDebug01.IsChecked = true;
                ceDebug02Enter.IsChecked = true;
                ceDebug02Exit.IsChecked = true;
                ceDebug03.IsChecked = true;
                ceDebug04.IsChecked = true;

                btnDebugToggle.Content = "All Off";
            }
        }

        private void btnArch00_09Toggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnArch00_09Toggle.Content == "All Off")
            {
                ceArch00.IsChecked = false;
                ceArch01.IsChecked = false;
                ceArch02.IsChecked = false;
                ceArch03.IsChecked = false;
                ceArch04.IsChecked = false;
                ceArch05.IsChecked = false;
                ceArch06.IsChecked = false;
                ceArch07.IsChecked = false;
                ceArch08.IsChecked = false;
                ceArch09.IsChecked = false;

                btnArch00_09Toggle.Content = "All On";
            }
            else
            {
                ceArch00.IsChecked = true;
                ceArch01.IsChecked = true;
                ceArch02.IsChecked = true;
                ceArch03.IsChecked = true;
                ceArch04.IsChecked = true;
                ceArch05.IsChecked = true;
                ceArch06.IsChecked = true;
                ceArch07.IsChecked = true;
                ceArch08.IsChecked = true;
                ceArch09.IsChecked = true;

                btnArch00_09Toggle.Content = "All Off";
            }
        }

        private void btnArch10_19Toggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnArch10_19Toggle.Content == "All Off")
            {
                ceArch10.IsChecked = false;
                ceArch11.IsChecked = false;
                ceArch12.IsChecked = false;
                ceArch13.IsChecked = false;
                ceArch14.IsChecked = false;
                ceArch15.IsChecked = false;
                ceArch16.IsChecked = false;
                ceArch17.IsChecked = false;
                ceArch18.IsChecked = false;
                ceArch19.IsChecked = false;

                btnArch10_19Toggle.Content = "All On";
            }
            else
            {
                ceArch10.IsChecked = true;
                ceArch11.IsChecked = true;
                ceArch12.IsChecked = true;
                ceArch13.IsChecked = true;
                ceArch14.IsChecked = true;
                ceArch15.IsChecked = true;
                ceArch16.IsChecked = true;
                ceArch17.IsChecked = true;
                ceArch18.IsChecked = true;
                ceArch19.IsChecked = true;

                btnArch10_19Toggle.Content = "All Off";
            }
        }

        private void btnTrace00_09Toggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnTrace00_09Toggle.Content == "All Off")
            {
                ceTrace00.IsChecked = false;
                ceTrace01.IsChecked = false;
                ceTrace02.IsChecked = false;
                ceTrace03.IsChecked = false;
                ceTrace04.IsChecked = false;
                ceTrace05.IsChecked = false;
                ceTrace06.IsChecked = false;
                ceTrace07.IsChecked = false;
                ceTrace08.IsChecked = false;
                ceTrace09.IsChecked = false;

                btnTrace00_09Toggle.Content = "All On";
            }
            else
            {
                ceTrace00.IsChecked = true;
                ceTrace01.IsChecked = true;
                ceTrace02.IsChecked = true;
                ceTrace03.IsChecked = true;
                ceTrace04.IsChecked = true;
                ceTrace05.IsChecked = true;
                ceTrace06.IsChecked = true;
                ceTrace07.IsChecked = true;
                ceTrace08.IsChecked = true;
                ceTrace09.IsChecked = true;

                btnTrace00_09Toggle.Content = "All Off";
            }
        }

        private void btnTrace10_19Toggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnTrace10_19Toggle.Content == "All Off")
            {
                ceTrace10.IsChecked = false;
                ceTrace11.IsChecked = false;
                ceTrace12.IsChecked = false;
                ceTrace13.IsChecked = false;
                ceTrace14.IsChecked = false;
                ceTrace15.IsChecked = false;
                ceTrace16.IsChecked = false;
                ceTrace17.IsChecked = false;
                ceTrace18.IsChecked = false;
                ceTrace19.IsChecked = false;

                btnTrace10_19Toggle.Content = "All On";
            }
            else
            {
                ceTrace10.IsChecked = true;
                ceTrace11.IsChecked = true;
                ceTrace12.IsChecked = true;
                ceTrace13.IsChecked = true;
                ceTrace14.IsChecked = true;
                ceTrace15.IsChecked = true;
                ceTrace16.IsChecked = true;
                ceTrace17.IsChecked = true;
                ceTrace18.IsChecked = true;
                ceTrace19.IsChecked = true;

                btnTrace10_19Toggle.Content = "All Off";
            }
        }

        private void btnTrace20_29Toggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnTrace20_29Toggle.Content == "All Off")
            {
                ceTrace20.IsChecked = false;
                ceTrace21.IsChecked = false;
                ceTrace22.IsChecked = false;
                ceTrace23.IsChecked = false;
                ceTrace24.IsChecked = false;
                ceTrace25.IsChecked = false;
                ceTrace26.IsChecked = false;
                ceTrace27.IsChecked = false;
                ceTrace28.IsChecked = false;
                ceTrace29.IsChecked = false;

                btnTrace20_29Toggle.Content = "All On";
            }
            else
            {
                ceTrace20.IsChecked = true;
                ceTrace21.IsChecked = true;
                ceTrace22.IsChecked = true;
                ceTrace23.IsChecked = true;
                ceTrace24.IsChecked = true;
                ceTrace25.IsChecked = true;
                ceTrace26.IsChecked = true;
                ceTrace27.IsChecked = true;
                ceTrace28.IsChecked = true;
                ceTrace29.IsChecked = true;

                btnTrace20_29Toggle.Content = "All Off";
            }
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            // TODO(crhodes)
            // Figure out way to explore all child controls inside of capture filter and set IsChecked

            if ((String)btnToggle.Content == "All Off")
            {
                ceInfo00.IsChecked = false;
                ceInfo01.IsChecked = false;
                ceInfo02.IsChecked = false;
                ceInfo03.IsChecked = false;
                ceInfo04.IsChecked = false;

                ceDebug00.IsChecked = false;
                ceDebug01.IsChecked = false;
                ceDebug02Enter.IsChecked = false;
                ceDebug02Exit.IsChecked = false;
                ceDebug03.IsChecked = false;
                ceDebug04.IsChecked = false;

                ceArch00.IsChecked = false;
                ceArch01.IsChecked = false;
                ceArch02.IsChecked = false;
                ceArch03.IsChecked = false;
                ceArch04.IsChecked = false;
                ceArch05.IsChecked = false;
                ceArch06.IsChecked = false;
                ceArch07.IsChecked = false;
                ceArch08.IsChecked = false;
                ceArch09.IsChecked = false;

                ceArch10.IsChecked = false;
                ceArch11.IsChecked = false;
                ceArch12.IsChecked = false;
                ceArch13.IsChecked = false;
                ceArch14.IsChecked = false;
                ceArch15.IsChecked = false;
                ceArch16.IsChecked = false;
                ceArch17.IsChecked = false;
                ceArch18.IsChecked = false;
                ceArch19.IsChecked = false;

                ceTrace00.IsChecked = false;
                ceTrace01.IsChecked = false;
                ceTrace02.IsChecked = false;
                ceTrace03.IsChecked = false;
                ceTrace04.IsChecked = false;
                ceTrace05.IsChecked = false;
                ceTrace06.IsChecked = false;
                ceTrace07.IsChecked = false;
                ceTrace08.IsChecked = false;
                ceTrace09.IsChecked = false;

                ceTrace10.IsChecked = false;
                ceTrace11.IsChecked = false;
                ceTrace12.IsChecked = false;
                ceTrace13.IsChecked = false;
                ceTrace14.IsChecked = false;
                ceTrace15.IsChecked = false;
                ceTrace16.IsChecked = false;
                ceTrace17.IsChecked = false;
                ceTrace18.IsChecked = false;
                ceTrace19.IsChecked = false;

                ceTrace20.IsChecked = false;
                ceTrace21.IsChecked = false;
                ceTrace22.IsChecked = false;
                ceTrace23.IsChecked = false;
                ceTrace24.IsChecked = false;
                ceTrace25.IsChecked = false;
                ceTrace26.IsChecked = false;
                ceTrace27.IsChecked = false;
                ceTrace28.IsChecked = false;
                ceTrace29.IsChecked = false;

                btnInfoToggle.Content = "All On";
                btnDebugToggle.Content = "All On";
                btnTrace00_09Toggle.Content = "All On";
                btnTrace10_19Toggle.Content = "All On";
                btnTrace20_29Toggle.Content = "All On";
                btnToggle.Content = "All On";
            }
            else
            {
                ceInfo00.IsChecked = true;
                ceInfo01.IsChecked = true;
                ceInfo02.IsChecked = true;
                ceInfo03.IsChecked = true;
                ceInfo04.IsChecked = true;

                ceDebug00.IsChecked = true;
                ceDebug01.IsChecked = true;
                ceDebug02Enter.IsChecked = true;
                ceDebug02Exit.IsChecked = true;
                ceDebug03.IsChecked = true;
                ceDebug04.IsChecked = true;

                ceArch00.IsChecked = true;
                ceArch01.IsChecked = true;
                ceArch02.IsChecked = true;
                ceArch03.IsChecked = true;
                ceArch04.IsChecked = true;
                ceArch05.IsChecked = true;
                ceArch06.IsChecked = true;
                ceArch07.IsChecked = true;
                ceArch08.IsChecked = true;
                ceArch09.IsChecked = true;

                ceArch10.IsChecked = true;
                ceArch11.IsChecked = true;
                ceArch12.IsChecked = true;
                ceArch13.IsChecked = true;
                ceArch14.IsChecked = true;
                ceArch15.IsChecked = true;
                ceArch16.IsChecked = true;
                ceArch17.IsChecked = true;
                ceArch18.IsChecked = true;
                ceArch19.IsChecked = true;

                ceTrace00.IsChecked = true;
                ceTrace01.IsChecked = true;
                ceTrace02.IsChecked = true;
                ceTrace03.IsChecked = true;
                ceTrace04.IsChecked = true;
                ceTrace05.IsChecked = true;
                ceTrace06.IsChecked = true;
                ceTrace07.IsChecked = true;
                ceTrace08.IsChecked = true;
                ceTrace09.IsChecked = true;

                ceTrace10.IsChecked = true;
                ceTrace11.IsChecked = true;
                ceTrace12.IsChecked = true;
                ceTrace13.IsChecked = true;
                ceTrace14.IsChecked = true;
                ceTrace15.IsChecked = true;
                ceTrace16.IsChecked = true;
                ceTrace17.IsChecked = true;
                ceTrace18.IsChecked = true;
                ceTrace19.IsChecked = true;

                ceTrace20.IsChecked = true;
                ceTrace21.IsChecked = true;
                ceTrace22.IsChecked = true;
                ceTrace23.IsChecked = true;
                ceTrace24.IsChecked = true;
                ceTrace25.IsChecked = true;
                ceTrace26.IsChecked = true;
                ceTrace27.IsChecked = true;
                ceTrace28.IsChecked = true;
                ceTrace29.IsChecked = true;

                btnInfoToggle.Content = "All Off";
                btnDebugToggle.Content = "All Off";
                btnTrace00_09Toggle.Content = "All Off";
                btnTrace10_19Toggle.Content = "All Off";
                btnTrace20_29Toggle.Content = "All Off";
                btnToggle.Content = "All Off";
            }
        }

        #endregion

        #region Private Methods


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