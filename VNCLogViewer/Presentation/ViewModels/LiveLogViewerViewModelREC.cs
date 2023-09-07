using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Model;

using Microsoft.AspNetCore.SignalR.Client;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using luic = VNCLogViewer.LoggingUIConfig;

using CharacterProperties = DevExpress.XtraRichEdit.API.Native.CharacterProperties;
using JSONConsoleApp.jsonDeserializeClass;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using VNCLogViewer.Domain;
using System.Diagnostics;

namespace VNCLogViewer.Presentation.ViewModels
{
    public class LiveLogViewerViewModelREC : EventViewModelBase, ILiveLogViewerViewModelREC, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load


        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;

        public LiveLogViewerViewModelREC(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            // TODO(crhodes)
            // Save constructor parameters here

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            //

            SignInCommand = new DelegateCommand(SignIn, SignInCanExecute);
            SendCommand = new DelegateCommand(Send, SendCanExecute);
            SendPriorityCommand = new DelegateCommand(SendPriority, SendPriorityCanExecute);

            Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums, Fields, Properties

        public HubConnection Connection { get; set; }

        private string _serverURI = "http://localhost:58195/signalr";

        public string ServerURI
        {
            get => _serverURI;
            set
            {
                if (_serverURI == value)
                    return;
                _serverURI = value;
                OnPropertyChanged();
            }
        }

        private string _userName;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName == value)
                    return;
                _userName = value;
                OnPropertyChanged();
            }
        }

        private int _priority = 0;

        public int Priority
        {
            get => _priority;
            set
            {
                if (_priority == value)
                    return;
                _priority = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                if (_message == value)
                    return;
                _message = value;
                OnPropertyChanged();
            }
        }

        public Document Doc { get; set; }

        public RichTextBox LogStream { get; set; }

        private int _hilightOffset = 3;
        public int HilightOffset
        {
            get => _hilightOffset;
            set
            {
                if (_hilightOffset == value)
                {
                    return;
                }

                _hilightOffset = value;
                OnPropertyChanged();
            }
        }

        private int _fontSize = 9;

        public int FontSize
        {
            get => _fontSize;
            set
            {
                if (_fontSize == value)
                    return;
                _fontSize = value;
                OnPropertyChanged();
            }
        }
        
        private luic.LoggingColors _loggingColors = new luic.LoggingColors();

        public luic.LoggingColors LoggingColors
        {
            get
            {
                return
                    _loggingColors;
            }
            set
            {
                _loggingColors = value;
                OnPropertyChanged();
            }
        }

        private luic.LoggingUIConfig _loggingUIConfig = new luic.LoggingUIConfig();

        public luic.LoggingUIConfig LoggingUIConfig
        {
            get => _loggingUIConfig;
            set
            {
                if (_loggingUIConfig == value)
                    return;
                _loggingUIConfig = value;
                OnPropertyChanged();
            }
        }

        private string _loggingUIConfigFileName;

        public string LoggingUIConfigFileName
        {
            get => _loggingUIConfigFileName;
            set
            {
                if (_loggingUIConfigFileName == value)
                    return;
                _loggingUIConfigFileName = value;
                OnPropertyChanged();
            }
        }        

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event Handlers

        #region SignIn Command

        public DelegateCommand SignInCommand { get; set; }
        public string SignInContent { get; set; } = "SignIn";
        public string SignInToolTip { get; set; } = "SignIn ToolTip";

        // Can get fancy and use Resources
        //public string SignInContent { get; set; } = "ViewName_SignInContent";
        //public string SignInToolTip { get; set; } = "ViewName_SignInContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_SignInContent">SignIn</system:String>
        //    <system:String x:Key="ViewName_SignInContentToolTip">SignIn ToolTip</system:String>  

        public void SignIn()
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.
            // Message = "Cool, you called SignIn";

            // Uncomment this if you are telling someone else to handle this

            // Common.EventAggregator.GetEvent<SignInEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<SignInEvent>().Publish(
            //      new SignInEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Three - Put this in PrismEvents

            // public class SignInEvent : PubSubEvent { }

            // End Cut Three

            // Start Cut Four - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<SignInEvent>().Subscribe(SignIn);

            // End Cut Four

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public bool SignInCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region Send Command

        public DelegateCommand SendCommand { get; set; }
        public string SendContent { get; set; } = "Send";
        public string SendToolTip { get; set; } = "Send ToolTip";

        // Can get fancy and use Resources
        //public string SendContent { get; set; } = "ViewName_SendContent";
        //public string SendToolTip { get; set; } = "ViewName_SendContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_SendContent">Send</system:String>
        //    <system:String x:Key="ViewName_SendContentToolTip">Send ToolTip</system:String>  

        public void Send()
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            Connection.InvokeAsync("SendUserMessage", UserName, Message);

            // TODO(crhodes)
            // Do something amazing.
            // Message = "Cool, you called Send";

            // Uncomment this if you are telling someone else to handle this

            // Common.EventAggregator.GetEvent<SendEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<SendEvent>().Publish(
            //      new SendEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Three - Put this in PrismEvents

            // public class SendEvent : PubSubEvent { }

            // End Cut Three

            // Start Cut Four - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<SendEvent>().Subscribe(Send);

            // End Cut Four

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public bool SendCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region SendPriority Command

        public DelegateCommand SendPriorityCommand { get; set; }
        public string SendPriorityContent { get; set; } = "SendPriority";
        public string SendPriorityToolTip { get; set; } = "SendPriority ToolTip";

        // Can get fancy and use Resources
        //public string SendPriorityContent { get; set; } = "ViewName_SendPriorityContent";
        //public string SendPriorityToolTip { get; set; } = "ViewName_SendPriorityContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_SendPriorityContent">SendPriority</system:String>
        //    <system:String x:Key="ViewName_SendPriorityContentToolTip">SendPriority ToolTip</system:String>  

        public void SendPriority()
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            Connection.InvokeAsync("SendPriorityMessage", Message, Priority);

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public bool SendPriorityCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #endregion

        #region Public methods

        public void ReloadUIConfig()
        {
            Int64 startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            string jsonString = File.ReadAllText(LoggingUIConfigFileName);
            LoggingUIConfig_JsonRoot? jsonLoggingUIConfig = JsonSerializer.Deserialize<LoggingUIConfig_JsonRoot>(jsonString);

            LoggingUIConfig = jsonLoggingUIConfig.ConvertJSONToLoggingUIConfig();

            Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Private methods (none)

        #endregion

        public async void ConnectAsync()
        {
            Int64 startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            Connection = new HubConnectionBuilder()
                .WithUrl(ServerURI)
                .Build();

            Connection.Closed += Connection_Closed;
            Connection.Reconnecting += Connection_Reconnecting;
            Connection.Reconnected += Connection_Reconnected;

            //Handle incoming event from server: use Invoke to write to console from SignalR's thread

            string formattedMessage = "";

            //Connection.On<string>("AddMessage", (message) =>
            //    this.Dispatcher.InvokeAsync(
            //    () =>
            //    {
            //        formattedMessage = String.Format("{0}\r", message);
            //        AppendFormattedMessage(recLogStream, formattedMessage);
            //    })
            //);
           
            Connection.On<string>("AddMessage", (message) =>
                AppendFormattedMessage($"{message}\r")
            );

            //Connection.On<string, string>("AddUserMessage", (name, message) =>
            //    this.Dispatcher.InvokeAsync(
            //    () =>
            //    {
            //        formattedMessage = String.Format("{0}: {1}\n", name, message);

            //        AppendFormattedMessage(recLogStream, formattedMessage);
            //    })
            //);

            Connection.On<string, string>("AddUserMessage", (name, message) =>
                AppendFormattedMessage($"{name}: {message}\r")
            );

            Connection.On<string, int>("AddPriorityMessage", (message, priority) =>
            {
                //Int64 startTicks = Log.Debug($"Enter/Exit message:{message}", Common.LOG_CATEGORY);

                Boolean displayMessage = false;

                // For now treat the whole message the same.
                formattedMessage = String.Format("{0}\r", message);

                // TODO(crhodes)
                // Make this more clever, perhaps a bit field
                // But this may be plenty fast enough just long :(

                switch (priority)
                {
                    #region Critical / Error / Warning

                    case -10:
                        AppendColorFormattedMessage(formattedMessage, Color.DarkRed);
                        break;

                    case -1:
                        AppendColorFormattedMessage(formattedMessage, Color.Red);
                        break;

                    case 1:
                        AppendColorFormattedMessage(formattedMessage, Color.DarkOrange);
                        break;

                    #endregion

                    #region Info

                    case 100:
                        if (LoggingUIConfig.Info00.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Info00.Color);
                            //displayMessage = ColorFormatMessage(formattedMessage,
                            //    LoggingUIConfig.Info00.Color);
                        }
                        break;

                    case 101: // Not Used
                        if (LoggingUIConfig.Info01.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Info01.Color);
                        }
                        break;

                    case 102: // Not Used
                        if (LoggingUIConfig.Info02.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Info02.Color);
                        }
                        break;

                    case 103: // Not Used
                        if (LoggingUIConfig.Info00.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Info03.Color);
                        }
                        break;

                    case 104: // Not Used
                        if (LoggingUIConfig.Info04.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Info04.Color);
                        }
                        break;

                    #endregion

                    #region Debug

                    case 1000: // Not Used
                        if (LoggingUIConfig.Debug00.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Debug00.Color);
                        }
                        break;

                    case 1001: // Not Used
                        if (LoggingUIConfig.Debug01.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Debug01.Color);
                        }
                        break;

                    // TODO(crhodes)
                    // Figure out how used back in EASE days.

                    case 1002: // Not Used
                        if (formattedMessage.Contains("Enter"))
                        {
                            if (LoggingUIConfig.Debug02.IsChecked == true)
                            {
                                ColorFormatMessageAndAppend(formattedMessage,
                                    LoggingUIConfig.Debug02.Color);
                            }
                        }
                        else if (LoggingUIConfig.Debug02.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Debug02.Color);
                        }
                        break;

                    case 1003: // Not Used
                        if (LoggingUIConfig.Debug03.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Debug03.Color);
                        }
                        break;

                    case 1004: // Not Used
                        if (LoggingUIConfig.Debug04.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Debug04.Color);
                        }
                        break;


                    #endregion

                    #region Arch00 - Arch09

                    case 9000:
                        if (LoggingUIConfig.Arch00.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch00.Color);
                        }
                        break;

                    case 9001:
                        if (LoggingUIConfig.Arch01.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch01.Color);
                        }
                        break;

                    case 9002:
                        if (LoggingUIConfig.Arch02.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch02.Color);
                        }
                        break;

                    case 9003:
                        if (LoggingUIConfig.Arch03.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch03.Color);
                        }
                        break;

                    case 9004:
                        if (LoggingUIConfig.Arch04.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch04.Color);
                        }
                        break;

                    case 9005:
                        if (LoggingUIConfig.Arch05.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch05.Color);
                        }
                        break;

                    case 9006:
                        if (LoggingUIConfig.Arch06.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch06.Color);
                        }
                        break;

                    case 9007:
                        if (LoggingUIConfig.Arch07.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch07.Color);
                        }
                        break;

                    case 9008:
                        if (LoggingUIConfig.Arch08.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch08.Color);
                        }
                        break;

                    case 9009:
                        if (LoggingUIConfig.Arch09.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch09.Color);
                        }
                        break;

                    #endregion

                    #region Arch10 - Arch19

                    case 9010:
                        if (LoggingUIConfig.Arch10.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch10.Color);
                        }
                        break;

                    case 9011:
                        if (LoggingUIConfig.Arch11.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch11.Color);
                        }
                        break;

                    case 9012:
                        if (LoggingUIConfig.Arch12.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch12.Color);
                        }
                        break;

                    case 9013:
                        if (LoggingUIConfig.Arch13.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch13.Color);
                        }
                        break;

                    case 9014:
                        if (LoggingUIConfig.Arch14.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch14.Color);
                        }
                        break;

                    case 9015:
                        if (LoggingUIConfig.Arch15.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch15.Color);
                        }
                        break;

                    case 9016:
                        if (LoggingUIConfig.Arch16.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch16.Color);
                        }
                        break;

                    case 9017:
                        if (LoggingUIConfig.Arch17.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch17.Color);
                        }
                        break;

                    case 9018:
                        if (LoggingUIConfig.Arch18.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch18.Color);
                        }
                        break;

                    case 9019:
                        if (LoggingUIConfig.Arch19.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Arch19.Color);
                        }
                        break;

                    #endregion

                    #region Trace00 - Trace09

                    case 10000: // Not Used
                        if (LoggingUIConfig.Trace00.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace00.Color);
                        }
                        break;

                    case 10001: // EVENT_HANDLER
                        if (LoggingUIConfig.Trace01.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace01.Color);
                        }
                        break;

                    case 10002: // APPLICATION_INITIALIZE
                        if (LoggingUIConfig.Trace02.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace02.Color);
                        }
                        break;

                    case 10003: // Not Used
                        if (LoggingUIConfig.Trace03.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace03.Color);
                        }
                        break;

                    case 10004: // Not Used
                        if (LoggingUIConfig.Trace04.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace04.Color);
                        }
                        break;

                    case 10005: // Not Used
                        if (LoggingUIConfig.Trace05.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace05.Color);
                        }
                        break;

                    case 10006: // Not Used
                        if (LoggingUIConfig.Trace06.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace06.Color);
                        }
                        break;

                    case 10007: // PRESENTATION
                        if (LoggingUIConfig.Trace07.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace07.Color);
                        }
                        break;

                    case 10008: // Not Used
                        if (LoggingUIConfig.Trace08.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace08.Color);
                        }
                        break;

                    case 10009: // CORE
                        if (LoggingUIConfig.Trace09.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace09.Color);
                        }
                        break;

                    #endregion

                    #region Trace10 - Trace19

                    case 10010: // APPLICATION
                        if (LoggingUIConfig.Trace10.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace10.Color);
                        }
                        break;

                    case 10011: // Not Used
                        if (LoggingUIConfig.Trace11.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace11.Color);
                        }
                        break;

                    case 10012: // FILE_DIR_IO
                        if (LoggingUIConfig.Trace12.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace12.Color);
                        }
                        break;

                    case 10013: // PERSISTENCE
                        if (LoggingUIConfig.Trace13.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace13.Color);
                        }
                        break;

                    case 10014: // Not Used
                        if (LoggingUIConfig.Trace14.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace14.Color);
                        }
                        break;

                    case 10015: // Not Used

                        if (LoggingUIConfig.Trace15.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace15.Color);
                        }
                        break;

                    case 10016: // Not Used
                        if (LoggingUIConfig.Trace16.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace16.Color);
                        }
                        break;

                    case 10017: // VIEW
                        if (LoggingUIConfig.Trace17.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace17.Color);
                        }
                        break;

                    case 10018: // VIEWMODEL
                        if (LoggingUIConfig.Trace18.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace18.Color);
                        }
                        break;

                    case 10019: // MODULE
                        if (LoggingUIConfig.Trace19.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace19.Color);
                        }
                        break;

                    #endregion

                    #region Trace20 - Trace29

                    case 10020: // APPLICATION_SERVICES
                        if (LoggingUIConfig.Trace20.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace20.Color);
                        }
                        break;

                    case 10021: // EVENT
                        if (LoggingUIConfig.Trace21.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace21.Color);
                        }
                        break;

                    case 10022: // DOMAIN SERVICES
                        if (LoggingUIConfig.Trace22.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace22.Color);
                        }
                        break;

                    case 10023: // PERSISTENCE_LOW
                        if (LoggingUIConfig.Trace23.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace23.Color);
                        }
                        break;

                    case 10024: // Not Used
                        if (LoggingUIConfig.Trace24.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace24.Color);
                        }
                        break;

                    case 10025: // CONSTRUCTOR
                        if (LoggingUIConfig.Trace25.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace25.Color);
                        }
                        break;

                    case 10026: // Not Used
                        if (LoggingUIConfig.Trace26.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace26.Color);
                        }
                        break;

                    case 10027: // VIEW_LOW
                        if (LoggingUIConfig.Trace27.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace27.Color);
                        }
                        break;

                    case 10028: // VIEWMODEL_LOW
                        if (LoggingUIConfig.Trace28.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace28.Color);
                        }
                        break;

                    case 10029: // MODULE_INITIALIZE
                        if (LoggingUIConfig.Trace29.IsChecked == true)
                        {
                            ColorFormatMessageAndAppend(formattedMessage,
                                LoggingUIConfig.Trace29.Color);
                        }
                        break;

                    #endregion

                    default:
                        displayMessage = true;
                        break;
                }

                if (displayMessage)
                {
                    AppendFormattedMessage(formattedMessage);
                }
            });

            Connection.On<string, SignalRTime>("AddTimedMessage", (message, signalrtime) =>
            {
                signalrtime.ClientReceivedTime = DateTime.Now;
                signalrtime.ClientReceivedTicks = Stopwatch.GetTimestamp();

                AppendFormattedMessage($"{message}\r");

                signalrtime.ClientMessageTime = DateTime.Now;
                signalrtime.ClientMessageTicks = Stopwatch.GetTimestamp();

                AppendFormattedMessage($"SendT:    {signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff}\r");

                AppendFormattedMessage($"HubRT:    {signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.HubReceivedTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

                AppendFormattedMessage($"ClientRT: {signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientReceivedTicks - signalrtime.HubReceivedTicks) / (double)Stopwatch.Frequency}\r");

                AppendFormattedMessage($"ClientMT: {signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientMessageTicks - signalrtime.ClientReceivedTicks) / (double)Stopwatch.Frequency}\r");

                AppendFormattedMessage($"Duration: {(signalrtime.ClientMessageTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

            });

            try
            {
                await Connection.StartAsync();
            }
            catch (HttpRequestException hre)
            {
                formattedMessage = $"Unable to connect to server: Start server before connecting clients. {hre.Message}";
                //No connection: Don't enable Send button or show chat UI
                AppendFormattedMessage(formattedMessage);
                return;
            }
            catch (Exception ex)
            {
                formattedMessage = $"Unable to connect to server, ex: {ex.Message}";
                //No connection: Don't enable Send button or show chat UI
                AppendFormattedMessage(formattedMessage);
                return;
            }

            ////Show chat UI; hide login UI
            //SignInPanel.Visibility = Visibility.Collapsed;
            //ChatPanel.Visibility = Visibility.Visible;
            //btnSend.IsEnabled = true;
            //btnSendPriority.IsEnabled = true;
            //tbMessage.Focus();
            formattedMessage = "Connected to server at " + ServerURI + "\n";

            AppendFormattedMessage(formattedMessage);

            Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public async void StopAsync()
        {
            await Connection.StopAsync();
        }

        public async void DisposeAsync()
        {
            await Connection.DisposeAsync();
            Connection = null;
        }

        Task Connection_Closed(Exception? arg)
        {
            AppendColorFormattedMessage($"Connection Closed {(arg is null ? "" : arg.Message)}.", Color.Red);

            ////Hide chat UI; show login UI
            //var dispatcher = Application.Current.Dispatcher;

            //dispatcher.InvokeAsync(() => ChatPanel.Visibility = Visibility.Collapsed);
            //dispatcher.InvokeAsync(() => btnSendPriority.IsEnabled = false);
            //dispatcher.InvokeAsync(() => btnSend.IsEnabled = false);
            //dispatcher.InvokeAsync(() => recLogStream.Text += $"Connection Closed {(arg is null ? "" : arg.Message)}.");
            //dispatcher.InvokeAsync(() => SignInPanel.Visibility = Visibility.Visible);

            return null;
        }

        private Task Connection_Reconnecting(Exception? arg)
        {
            AppendColorFormattedMessage($"Reconnecting {(arg is null ? "" : arg.Message)}.", Color.Red);

            //var dispatcher = Application.Current.Dispatcher;
            //dispatcher.InvokeAsync(() => recLogStream.Text = $"Reconnecting {(arg is null ? "" : arg.Message)}.");

            return null;
        }

        private Task Connection_Reconnected(string? arg)
        {
            AppendColorFormattedMessage($"Reconnected {(arg is null ? "" : arg)}", Color.Red);

            //var dispatcher = Application.Current.Dispatcher;
            //dispatcher.InvokeAsync(() => recLogStream.Text = $"Reconnected {arg}");

            return null;
        }

        private void AppendFormattedMessage(string formattedMessage)
        {
            // TODO(crhodes)
            // Doc maybe null when program exits.

            if (Doc is not null)
            {
                try
                {
                    Doc.BeginUpdate();

                    Doc.AppendText(formattedMessage);

                    Doc.EndUpdate();
                }
                catch (Exception ex)
                {
                    string exception = ex.ToString();
                    string innerException = ex.InnerException.ToString();
                }
            }
        }

        void AppendColorFormattedMessage(string formattedMessage, Color color)
        {
            try
            {
                Doc.BeginUpdate();

                //Doc.AppendText(formattedMessage);

                DocumentRange newRange = Doc.AppendText(formattedMessage);

                CharacterProperties charProp = Doc.BeginUpdateCharacters(newRange);
                charProp.ForeColor = color;
                Doc.EndUpdateCharacters(charProp);

                Doc.EndUpdate();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                string innerException = ex.InnerException?.ToString();
            }
        }

        private void ColorFormatMessageAndAppend(string formattedMessage, Color color)
        {
            // HACK(crhodes)
            // See if this is fast, Skip all color formatting

            //AppendFormattedMessage(formattedMessage);
            //return;

            // HACK(crhodes)
            // Ok, let's make the whole line colored

            if (HilightOffset == 0)
            {
                AppendColorFormattedMessage(formattedMessage, color);
                return;
            }

            int messageIndex = 0;

            //messageIndex = GetNthIndex3(formattedMessage, '|', 3);
            messageIndex = GetNthIndex3(formattedMessage, '|', HilightOffset);

            try
            {
                if (messageIndex++ > 0)
                {
                    string prefixMessage = formattedMessage.Substring(0, messageIndex);
                    AppendFormattedMessage(prefixMessage);

                    string colorMessage = formattedMessage.Substring(messageIndex);
                    AppendColorFormattedMessage(colorMessage, color);
                }
                else
                {
                    AppendColorFormattedMessage(formattedMessage, color);
                }
            }
            catch (Exception ex)
            {
                AppendColorFormattedMessage(ex.ToString(), Color.Red);
            }

            //return displayMessage;
        }

        private int GetNthIndex(string s, char c, int n)
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

        private int GetNthIndex2(string s, char c, int n)
        {
            var idx = s.IndexOf(c, 0);

            while (idx >= 0 && --n > 0)
            {
                idx = s.IndexOf(c, idx + 1);
            }

            return idx;
        }

        public int GetNthIndex3(ReadOnlySpan<char> sSpan, char c, int n)
        {
            var idx = sSpan.IndexOf(c);

            while (idx >= 0 && --n > 0)
            {
                idx++;  // Go past c
                ReadOnlySpan<char> remainingSpan = sSpan.Slice(idx, sSpan.Length - idx);

                idx += remainingSpan.IndexOf(c);
            }

            return idx;
        }

        #region IInstanceCount

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
