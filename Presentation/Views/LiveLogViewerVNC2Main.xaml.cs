using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using DevExpress.Xpf.Editors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

using Microsoft.AspNetCore.SignalR.Client;

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class LiveLogViewerVNC2Main : UserControl, ILiveLogViewerVNCMain
    {

        public LiveLogViewerVNC2Main(ViewModels.ILiveLogViewerViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeComponent();

            ViewModel = viewModel;
            //Loaded += UserControl_Loaded;
            lgCaptureFilter.IsCollapsed = true;

           ((ILiveLogViewerViewModel)ViewModel).Doc = recLogStream.Document;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Int64 startTicks = Log.VIEW("Enter", Common.LOG_CATEGORY);

        //    await ((ViewModels.ILiveLogViewerVNCMainViewModel)ViewModel).LoadAsync();

        //    Log.VIEW("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        //-------------------------------------

        #region Enums, Fields, Properties

        public String UserName { get; set; }
        //public IHubProxy HubProxy { get; set; }
        //private string ServerURI = "http://localhost:58195/signalr";
        public HubConnection Connection { get; set; }

        //public Document Doc { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Initialization

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["serversInstancesViewSource"];
            //// Things work if this line is present.  Testing to see if it works without 6/13/2012
            //// Yup, still works.  Don't need this line as it is done in the XAML.
            //myCollectionViewSource.Source = EyeOnLife.Common.ApplicationDataSet.Instances;

            System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["serversViewSource"];
            // Things work if this line is present.  Testing to see if it works without 6/13/2012
            // Yup, still works.  Don't need this line as it is done in the XAML.
            //myCollectionViewSource.Source = EyeOnLife.Common.ApplicationDataSet.Servers;

            InitializeLogStream();
        }

        private void InitializeLogStream()
        {
            recLogStream.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
            recLogStream.ActiveView.BackColor = System.Drawing.Color.Black;

            //Document doc = recLogStream.Document;

            //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

            DevExpress.XtraRichEdit.API.Native.Section section = ((ILiveLogViewerViewModel)ViewModel).Doc.Sections[0];

            section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
            section.Page.Landscape = true;
            section.Margins.Left = 0.1f;
            section.Margins.Right = 0.1f;
        }

        #endregion

        #region Private Methods

        //AppendFormattedText(recLogStream, Color color)
        #region Connection Events

        void AppendFormattedMessage(DevExpress.Xpf.RichEdit.RichEditControl richEditControl, string formattedMessage)
        {
            try
            {
                //Document doc = richEditControl.Document;

                //doc.BeginUpdate();

                //doc.AppendText(formattedMessage);

                //doc.EndUpdate();

                ((ILiveLogViewerViewModel)ViewModel).Doc.BeginUpdate();

                ((ILiveLogViewerViewModel)ViewModel).Doc.AppendText(formattedMessage);

                ((ILiveLogViewerViewModel)ViewModel).Doc.EndUpdate();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                string innerException = ex.InnerException.ToString();
            }
        }

        void AppendColorFormattedMessage(DevExpress.Xpf.RichEdit.RichEditControl richEditControl, string formattedMessage, Color color)
        {
            try
            {
                //Document doc = richEditControl.Document;

                //DocumentRange newRange = doc.AppendText(formattedMessage);
                //CharacterProperties charProp = doc.BeginUpdateCharacters(newRange);
                //charProp.ForeColor = color;
                //doc.EndUpdateCharacters(charProp);

                DocumentRange newRange = ((ILiveLogViewerViewModel)ViewModel).Doc.AppendText(formattedMessage);
                CharacterProperties charProp = ((ILiveLogViewerViewModel)ViewModel).Doc.BeginUpdateCharacters(newRange);
                charProp.ForeColor = color;
                ((ILiveLogViewerViewModel)ViewModel).Doc.EndUpdateCharacters(charProp);
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                string innerException = ex.InnerException.ToString();
            }
        }

        private async void ConnectAsync()
        {
            var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(int).Assembly.Location);

            Connection = new HubConnectionBuilder()
                .WithUrl(ServerURI.Text)
                .Build();

            Connection.Closed += Connection_Closed;
            Connection.Reconnecting += Connection_Reconnecting;
            Connection.Reconnected += Connection_Reconnected;

            //Handle incoming event from server: use Invoke to write to console from SignalR's thread

            string formattedMessage = "";

            Connection.On<string>("AddMessage", (message) =>
                this.Dispatcher.InvokeAsync(
                () =>
                {
                    formattedMessage = String.Format("{0}\r", message);
                    AppendFormattedMessage(recLogStream, formattedMessage);
                })
            );

            Connection.On<string, string>("AddUserMessage", (name, message) =>
                this.Dispatcher.InvokeAsync(
                () =>
                {
                    formattedMessage = String.Format("{0}: {1}\n", name, message);

                    AppendFormattedMessage(recLogStream, formattedMessage);
                })
            );

            Connection.On<string, int>("AddPriorityMessage", (message, priority) =>
                this.Dispatcher.InvokeAsync(
                () =>
                {
                    Boolean displayMessage = false;

                    // For now treat the whole message the same.
                    formattedMessage = String.Format("{0}\r", message);

                    // TODO(crhodes)
                    // Make this more clever, perhaps a bit field
                    // But this may be plenty fast enough just long :(

                    switch (priority)
                    {
                        #region Info

                        case 100:
                            if (ceInfo00.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Info00.Color);
                            }
                            break;

                        case 101: // Not Used
                            if (ceInfo01.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Info01.Color);
                            }
                            break;

                        case 102: // Not Used
                            if (ceInfo02.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Info02.Color);
                            }
                            break;

                        case 103: // Not Used
                            if (ceInfo00.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Info03.Color);
                            }
                            break;

                        case 104: // Not Used
                            if (ceInfo04.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Info04.Color);
                            }
                            break;

                        //case 105: // Not Used
                        //    if (ceInfo05.IsChecked == true)
                        //    {
                        //        displayMessage = ColorFormatMessage(formattedMessage, 
                        //            ((ILiveLogViewerVNCMainViewModel)ViewModel).LoggingUIConfig.Info05.Color);
                        //    }
                        //    break;

                        #endregion

                        #region Debug

                        case 1000: // Not Used
                            if (ceDebug00.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug00.Color);
                            }
                            break;

                        case 1001: // Not Used
                            if (ceDebug01.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug01.Color);
                            }
                            break;

                        case 1002: // Not Used
                            if (formattedMessage.Contains("Enter"))
                            {
                                if (ceDebug02Enter.IsChecked == true)
                                {
                                    displayMessage = ColorFormatMessage(formattedMessage, 
                                        ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug02.Color);
                                }
                            }
                            else if (ceDebug02Exit.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug02.Color);
                            }
                            break;

                        case 1003: // Not Used
                            if (ceDebug03.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug03.Color);
                            }
                            break;

                        case 1004: // Not Used
                            if (ceDebug04.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Debug04.Color);
                            }
                            break;


                        #endregion

                        #region Arch00 - Arch09

                        #endregion

                        #region Arch10 - Arch19

                        #endregion

                        #region Trace00 - Trace09

                        case 10000: // Not Used
                            if (ceTrace00.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace00.Color);
                            }
                            break;

                        case 10001: // EVENT_HANDLER
                            if (ceTrace01.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace01.Color);
                            }
                            break;

                        case 10002: // APPLICATION_INITIALIZE
                            if (ceTrace02.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace02.Color);
                            }
                            break;

                        case 10003: // Not Used
                            if (ceTrace03.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace03.Color);
                            }
                            break;

                        case 10004: // Not Used
                            if (ceTrace04.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage,
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace04.Color);
                            }
                            break;

                        case 10005: // Not Used
                            if (ceTrace05.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace05.Color);
                            }
                            break;

                        case 10006: // Not Used
                            if (ceTrace06.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage,
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace06.Color);
                            }
                            break;

                        case 10007: // PRESENTATION
                            if (ceTrace07.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace07.Color);
                            }
                            break;

                        case 10008: // Not Used
                            if (ceTrace08.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace08.Color);
                            }
                            break;

                        case 10009: // CORE
                            if (ceTrace09.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace09.Color);
                            }
                            break;

                        #endregion

                        #region Trace10 - Trace19

                        case 10010: // APPLICATION
                            if (ceTrace10.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace10.Color);
                            }
                            break;

                        case 10011: // Not Used
                            if (ceTrace11.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace11.Color);
                            }
                            break;

                        case 10012: // FILE_DIR_IO
                            if (ceTrace12.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace12.Color);
                            }
                            break;

                        case 10013: // PERSISTENCE
                            if (ceTrace13.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace13.Color);
                            }
                            break;

                        case 10014: // Not Used
                            if (ceTrace14.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace14.Color);
                            }
                            break;

                        case 10015: // Not Used

                            if (ceTrace15.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace15.Color);
                            }
                            break;

                        case 10016: // Not Used
                            if (ceTrace16.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace16.Color);
                            }
                            break;

                        case 10017: // VIEW
                            if (ceTrace17.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace17.Color);
                            }
                            break;

                        case 10018: // VIEWMODEL
                            if (ceTrace18.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace18.Color);
                            }
                            break;

                        case 10019: // MODULE
                            if (ceTrace19.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace19.Color);
                            }
                            break;

                        #endregion

                        #region Trace20 - Trace29

                        case 10020: // APPLICATION_SERVICES
                            if (ceTrace20.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace20.Color);
                            }
                            break;

                        case 10021: // EVENT
                            if (ceTrace21.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace21.Color);
                            }
                            break;

                        case 10022: // DOMAIN SERVICES
                            if (ceTrace22.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace22.Color);
                            }
                            break;

                        case 10023: // PERSISTENCE_LOW
                            if (ceTrace23.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace23.Color);
                            }
                            break;

                        case 10024: // Not Used
                            if (ceTrace24.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace24.Color);
                            }
                            break;

                        case 10025: // CONSTRUCTOR
                            if (ceTrace25.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace25.Color);
                            }
                            break;

                        case 10026: // Not Used
                            if (ceTrace26.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace26.Color);
                            }
                            break;

                        case 10027: // VIEW_LOW
                            if (ceTrace27.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage,
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace27.Color);
                            }
                            break;

                        case 10028: // VIEWMODEL_LOW
                            if (ceTrace28.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace28.Color);
                            }
                            break;

                        case 10029: // MODULE_INITIALIZE
                            if (ceTrace29.IsChecked == true)
                            {
                                displayMessage = ColorFormatMessage(formattedMessage, 
                                    ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig.Trace29.Color);
                            }
                            break;

                        #endregion

                        default:
                            displayMessage = true;
                            break;
                    }

                    if (displayMessage)
                    {
                        formattedMessage = String.Format("{0}\r", message);
                        AppendFormattedMessage(recLogStream, formattedMessage);
                    }
                })
            );

            try
            {
                await Connection.StartAsync();
            }
            catch (HttpRequestException hre)
            {
                StatusText.Content = $"Unable to connect to server: Start server before connecting clients. {hre.Message}";
                //No connection: Don't enable Send button or show chat UI
                return;
            }
            catch (Exception ex)
            {
                StatusText.Content = $"Unable to connect to server, ex: {ex.Message}";
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Show chat UI; hide login UI
            SignInPanel.Visibility = Visibility.Collapsed;
            ChatPanel.Visibility = Visibility.Visible;
            btnSend.IsEnabled = true;
            btnSendPriority.IsEnabled = true;
            tbMessage.Focus();
            formattedMessage = "Connected to server at " + ServerURI + "\n";

            AppendFormattedMessage(recLogStream, formattedMessage);
        }

        private bool ColorFormatMessage(string formattedMessage, Color color)
        {
            bool displayMessage = false;
            int messageIndex = 0;

            messageIndex = GetNthIndex(formattedMessage, '|', 6);
            try
            {
                if (messageIndex++ > 0)
                {
                    string prefixMessage = formattedMessage.Substring(0, messageIndex);
                    AppendFormattedMessage(recLogStream, prefixMessage);

                    string colorMessage = formattedMessage.Substring(messageIndex);
                    AppendColorFormattedMessage(recLogStream, colorMessage, color);
                }
                else
                {
                    AppendColorFormattedMessage(recLogStream, formattedMessage, color);
                }
            }
            catch (Exception ex)
            {
                AppendColorFormattedMessage(recLogStream, ex.ToString(), Color.Red);
            }

            return displayMessage;
        }

        private Task Connection_Reconnecting(Exception? arg)
        {
            var dispatcher = Application.Current.Dispatcher;
            dispatcher.InvokeAsync(() => recLogStream.Text = $"Reconnecting {(arg is null ? "" : arg.Message)}.");

            return null;
        }

        private Task Connection_Reconnected(string? arg)
        {
            var dispatcher = Application.Current.Dispatcher;
            dispatcher.InvokeAsync(() => recLogStream.Text = $"Reconnected {arg}");

            return null;
        }

        //void Connection_StateChanged(StateChange obj)
        //{
        //    var dispatcher = Application.Current.Dispatcher;
        //    var formattedMessage = string.Format("Connection_StateChanged {0,15} -> {1,-15}\n", obj.OldState, obj.NewState);

        //    dispatcher.InvokeAsync(() => AppendFormattedMessage(recLogStream, formattedMessage));
        //}

        //private void Connection_Received(string obj)
        //{
        //    var dispatcher = Application.Current.Dispatcher;
        //    string formattedMessage = "Connection_Received\n";

        //    dispatcher.InvokeAsync(() => AppendFormattedMessage(recLogStream, formattedMessage));
        //}

        //private void Connection_Error(Exception obj)
        //{
        //    var dispatcher = Application.Current.Dispatcher;
        //    var formattedMessage = string.Format("Connection_Error >{0}<\n", obj.GetBaseException().ToString());

        //    dispatcher.InvokeAsync(() => AppendFormattedMessage(recLogStream, formattedMessage));
        //}

        /// <summary>
        /// If the server is stopped, the connection will time out after 30 seconds (default), and the 
        /// Closed event will fire.
        /// </summary>
        Task Connection_Closed(Exception? arg)
        {
            //Hide chat UI; show login UI
            var dispatcher = Application.Current.Dispatcher;

            dispatcher.InvokeAsync(() => ChatPanel.Visibility = Visibility.Collapsed);
            dispatcher.InvokeAsync(() => btnSendPriority.IsEnabled = false);
            dispatcher.InvokeAsync(() => btnSend.IsEnabled = false);
            dispatcher.InvokeAsync(() => recLogStream.Text += $"Connection Closed {(arg is null ? "" : arg.Message)}.");
            dispatcher.InvokeAsync(() => SignInPanel.Visibility = Visibility.Visible);

            return null;
        }

        #endregion

        #endregion

        #region Event Handlers

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            UserName = UserNameTextBox.Text;
            //Connect to server (use async method to avoid blocking UI thread)
            if (!String.IsNullOrEmpty(UserName))
            {
                StatusText.Visibility = Visibility.Visible;
                StatusText.Content = "Connecting to server...";
                ConnectAsync();
            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await Connection.InvokeAsync("SendUserMessage", UserName, tbMessage.Text);
            tbMessage.Text = String.Empty;

            tbMessage.Focus();
        }

        private async void btnSendPriority_Click(object sender, RoutedEventArgs e)
        {
            await Connection.InvokeAsync("SendPriorityMessage", tbMessage.Text, Int32.Parse(tbMessagePriority.Text));
            tbMessage.Text = String.Empty;
            tbMessage.Focus();
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

        private void btnInfoToggle_Click(object sender, RoutedEventArgs e)
        {
            if ((String)btnInfoToggle.Content == "All Off")
            {
                ceInfo00.IsChecked = false;
                ceInfo01.IsChecked = false;
                ceInfo02.IsChecked = false;
                ceInfo03.IsChecked = false;
                ceInfo04.IsChecked = false;
                ceInfo05.IsChecked = false;

                btnInfoToggle.Content = "All On";
            }
            else
            {
                ceInfo00.IsChecked = true;
                ceInfo01.IsChecked = true;
                ceInfo02.IsChecked = true;
                ceInfo03.IsChecked = true;
                ceInfo04.IsChecked = true;
                ceInfo05.IsChecked = true;

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
                ceDebug05.IsChecked = false;

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
                ceDebug05.IsChecked = true;

                btnDebugToggle.Content = "All Off";
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

        private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            InitializeLogStream();
        }

        int GetNthIndex(string s, char c, int n)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
            // = s.TakeWhile(c => n -= (c == t ? 1 : 0)) > 0).Count();
        }
    }
}