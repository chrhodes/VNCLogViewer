using System;
using System.Drawing;
using System.IO;

#if NET48

#else
using System.Text.Json;
#endif

using System.Windows;
using System.Windows.Controls;

using DevExpress.DataAccess.Native.ExpressionEditor;
using DevExpress.XtraRichEdit.API.Native;

using JSONConsoleApp.jsonDeserializeClass;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Services;

using CharacterProperties = DevExpress.XtraRichEdit.API.Native.CharacterProperties;
using luic = VNCLogViewer.LoggingUIConfig;

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

            //SignInCommand = new DelegateCommand(SignIn, SignInCanExecute);
            //SendCommand = new DelegateCommand(Send, SendCanExecute);
            //SendPriorityCommand = new DelegateCommand(SendPriority, SendPriorityCanExecute);

            Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums, Fields, Properties

        //public HubConnection Connection { get; set; }

        //private string _serverURI = "http://localhost:58195/signalr";

        //public string ServerURI
        //{
        //    get => _serverURI;
        //    set
        //    {
        //        if (_serverURI == value)
        //            return;
        //        _serverURI = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string _userName;

        //public string UserName
        //{
        //    get => _userName;
        //    set
        //    {
        //        if (_userName == value)
        //            return;
        //        _userName = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private int _priority = 0;

        //public int Priority
        //{
        //    get => _priority;
        //    set
        //    {
        //        if (_priority == value)
        //            return;
        //        _priority = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string _message;

        //public string Message
        //{
        //    get => _message;
        //    set
        //    {
        //        if (_message == value)
        //            return;
        //        _message = value;
        //        OnPropertyChanged();
        //    }
        //}

        public Document Doc { get; set; }

        public RichTextBox LogStream { get; set; }

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

        //public Task LoadAsync()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Event Handlers

        #region SignIn Command

        //public DelegateCommand SignInCommand { get; set; }
        //public string SignInContent { get; set; } = "SignIn";
        //public string SignInToolTip { get; set; } = "SignIn ToolTip";

        // Can get fancy and use Resources
        //public string SignInContent { get; set; } = "ViewName_SignInContent";
        //public string SignInToolTip { get; set; } = "ViewName_SignInContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_SignInContent">SignIn</system:String>
        //    <system:String x:Key="ViewName_SignInContentToolTip">SignIn ToolTip</system:String>  

        //public void SignIn()
        //{
        //    Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);
        //    // TODO(crhodes)
        //    // Do something amazing.
        //    // Message = "Cool, you called SignIn";

        //    // Uncomment this if you are telling someone else to handle this

        //    // Common.EventAggregator.GetEvent<SignInEvent>().Publish();

        //    // May want EventArgs

        //    //  EventAggregator.GetEvent<SignInEvent>().Publish(
        //    //      new SignInEventArgs()
        //    //      {
        //    //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
        //    //            Process = _contextMainViewModel.Context.SelectedProcess
        //    //      });

        //    // Start Cut Three - Put this in PrismEvents

        //    // public class SignInEvent : PubSubEvent { }

        //    // End Cut Three

        //    // Start Cut Four - Put this in places that listen for event

        //    //Common.EventAggregator.GetEvent<SignInEvent>().Subscribe(SignIn);

        //    // End Cut Four

        //    Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        //public bool SignInCanExecute()
        //{
        //    // TODO(crhodes)
        //    // Add any before button is enabled logic.
        //    return true;
        //}

        #endregion

        #region Send Command

        //public DelegateCommand SendCommand { get; set; }
        //public string SendContent { get; set; } = "Send";
        //public string SendToolTip { get; set; } = "Send ToolTip";

        // Can get fancy and use Resources
        //public string SendContent { get; set; } = "ViewName_SendContent";
        //public string SendToolTip { get; set; } = "ViewName_SendContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_SendContent">Send</system:String>
        //    <system:String x:Key="ViewName_SendContentToolTip">Send ToolTip</system:String>  

        //public void Send()
        //{
        //    Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

        //    Connection.InvokeAsync("SendUserMessage", UserName, Message);

        //    // TODO(crhodes)
        //    // Do something amazing.
        //    // Message = "Cool, you called Send";

        //    // Uncomment this if you are telling someone else to handle this

        //    // Common.EventAggregator.GetEvent<SendEvent>().Publish();

        //    // May want EventArgs

        //    //  EventAggregator.GetEvent<SendEvent>().Publish(
        //    //      new SendEventArgs()
        //    //      {
        //    //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
        //    //            Process = _contextMainViewModel.Context.SelectedProcess
        //    //      });

        //    // Start Cut Three - Put this in PrismEvents

        //    // public class SendEvent : PubSubEvent { }

        //    // End Cut Three

        //    // Start Cut Four - Put this in places that listen for event

        //    //Common.EventAggregator.GetEvent<SendEvent>().Subscribe(Send);

        //    // End Cut Four

        //    Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        //public bool SendCanExecute()
        //{
        //    // TODO(crhodes)
        //    // Add any before button is enabled logic.
        //    return true;
        //}

        #endregion

        #region SendPriority Command

        //public DelegateCommand SendPriorityCommand { get; set; }
        //public string SendPriorityContent { get; set; } = "SendPriority";
        //public string SendPriorityToolTip { get; set; } = "SendPriority ToolTip";

        //// Can get fancy and use Resources
        ////public string SendPriorityContent { get; set; } = "ViewName_SendPriorityContent";
        ////public string SendPriorityToolTip { get; set; } = "ViewName_SendPriorityContentToolTip";

        //// Put these in Resource File
        ////    <system:String x:Key="ViewName_SendPriorityContent">SendPriority</system:String>
        ////    <system:String x:Key="ViewName_SendPriorityContentToolTip">SendPriority ToolTip</system:String>  

        //public void SendPriority()
        //{
        //    Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

        //    Connection.InvokeAsync("SendPriorityMessage", Message, Priority);

        //    Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        //public bool SendPriorityCanExecute()
        //{
        //    // TODO(crhodes)
        //    // Add any before button is enabled logic.
        //    return true;
        //}

        #endregion

        #endregion

        #region Public methods

        public void ReloadUIConfig()
        {
            Int64 startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            string jsonString = File.ReadAllText(LoggingUIConfigFileName);
#if NET48
            // TODO(crhodes)
            // Figure out what to use instead of JsonSerializer in net48.  Sigh.
#else
            LoggingUIConfig_JsonRoot? jsonLoggingUIConfig = JsonSerializer.Deserialize<LoggingUIConfig_JsonRoot>(jsonString);
            LoggingUIConfig = jsonLoggingUIConfig.ConvertJSONToLoggingUIConfig();
#endif

            Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Private methods (none)

        #endregion 

        public void ProcessPriorityMessage(string message, Int32 priority)
        {
            Int64 startTicks = Log.Debug($"Enter/Exit message:{message}", Common.LOG_CATEGORY);

            //Boolean displayMessage = false;

            // For now treat the whole message the same.
            //message = String.Format("{0}\r", message);

            // TODO(crhodes)
            // Make this more clever, perhaps a bit field
            // But this may be plenty fast enough just long :(

            switch (priority)
            {
                #region Critical / Error / Warning

                case -10:
                    AppendColoredText(message, Color.DarkRed);
                    break;

                case -1:
                    AppendColoredText(message, Color.Red);
                    break;

                case 1:
                    AppendColoredText(message, Color.DarkOrange);
                    break;

                #endregion

                #region Info

                case 100:
                    if (LoggingUIConfig.Info00.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Info00.Color);
                    }
                    break;

                case 101:
                    if (LoggingUIConfig.Info01.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Info01.Color);
                    }
                    break;

                case 102:
                    if (LoggingUIConfig.Info02.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Info02.Color);
                    }
                    break;

                case 103:
                    if (LoggingUIConfig.Info00.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Info03.Color);
                    }
                    break;

                case 104:
                    if (LoggingUIConfig.Info04.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Info04.Color);
                    }
                    break;

                #endregion

                #region Debug

                case 1000:
                    if (LoggingUIConfig.Debug00.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Debug00.Color);
                    }
                    break;

                case 1001:
                    if (LoggingUIConfig.Debug01.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Debug01.Color);
                    }
                    break;

                // TODO(crhodes)
                // Figure out how used back in EASE days.

                case 1002:
                    if (message.Contains("Enter"))
                    {
                        if (LoggingUIConfig.Debug02.IsChecked == true)
                        {
                            AppendColorFormatedMessage(message,
                                LoggingUIConfig.Debug02.Color);
                        }
                    }
                    else if (LoggingUIConfig.Debug02.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Debug02.Color);
                    }
                    break;

                case 1003:
                    if (LoggingUIConfig.Debug03.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Debug03.Color);
                    }
                    break;

                case 1004:
                    if (LoggingUIConfig.Debug04.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Debug04.Color);
                    }
                    break;


                #endregion

                #region Arch00 - Arch09

                case 9000:
                    if (LoggingUIConfig.Arch00.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch00.Color);
                    }
                    break;

                case 9001:
                    if (LoggingUIConfig.Arch01.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch01.Color);
                    }
                    break;

                case 9002:
                    if (LoggingUIConfig.Arch02.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch02.Color);
                    }
                    break;

                case 9003:
                    if (LoggingUIConfig.Arch03.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch03.Color);
                    }
                    break;

                case 9004:
                    if (LoggingUIConfig.Arch04.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch04.Color);
                    }
                    break;

                case 9005:
                    if (LoggingUIConfig.Arch05.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch05.Color);
                    }
                    break;

                case 9006:
                    if (LoggingUIConfig.Arch06.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch06.Color);
                    }
                    break;

                case 9007:
                    if (LoggingUIConfig.Arch07.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch07.Color);
                    }
                    break;

                case 9008:
                    if (LoggingUIConfig.Arch08.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch08.Color);
                    }
                    break;

                case 9009:
                    if (LoggingUIConfig.Arch09.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch09.Color);
                    }
                    break;

                #endregion

                #region Arch10 - Arch19

                case 9010:
                    if (LoggingUIConfig.Arch10.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch10.Color);
                    }
                    break;

                case 9011:
                    if (LoggingUIConfig.Arch11.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch11.Color);
                    }
                    break;

                case 9012:
                    if (LoggingUIConfig.Arch12.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch12.Color);
                    }
                    break;

                case 9013:
                    if (LoggingUIConfig.Arch13.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch13.Color);
                    }
                    break;

                case 9014:
                    if (LoggingUIConfig.Arch14.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch14.Color);
                    }
                    break;

                case 9015:
                    if (LoggingUIConfig.Arch15.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch15.Color);
                    }
                    break;

                case 9016:
                    if (LoggingUIConfig.Arch16.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch16.Color);
                    }
                    break;

                case 9017:
                    if (LoggingUIConfig.Arch17.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch17.Color);
                    }
                    break;

                case 9018:
                    if (LoggingUIConfig.Arch18.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch18.Color);
                    }
                    break;

                case 9019:
                    if (LoggingUIConfig.Arch19.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Arch19.Color);
                    }
                    break;

                #endregion

                #region Trace00 - Trace09

                case 10000:
                    if (LoggingUIConfig.Trace00.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace00.Color);
                    }
                    break;

                case 10001:
                    if (LoggingUIConfig.Trace01.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace01.Color);
                    }
                    break;

                case 10002:
                    if (LoggingUIConfig.Trace02.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace02.Color);
                    }
                    break;

                case 10003:
                    if (LoggingUIConfig.Trace03.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace03.Color);
                    }
                    break;

                case 10004:
                    if (LoggingUIConfig.Trace04.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace04.Color);
                    }
                    break;

                case 10005:
                    if (LoggingUIConfig.Trace05.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace05.Color);
                    }
                    break;

                case 10006:
                    if (LoggingUIConfig.Trace06.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace06.Color);
                    }
                    break;

                case 10007:
                    if (LoggingUIConfig.Trace07.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace07.Color);
                    }
                    break;

                case 10008:
                    if (LoggingUIConfig.Trace08.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace08.Color);
                    }
                    break;

                case 10009:
                    if (LoggingUIConfig.Trace09.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace09.Color);
                    }
                    break;

                #endregion

                #region Trace10 - Trace19

                case 10010:
                    if (LoggingUIConfig.Trace10.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace10.Color);
                    }
                    break;

                case 10011:
                    if (LoggingUIConfig.Trace11.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace11.Color);
                    }
                    break;

                case 10012:
                    if (LoggingUIConfig.Trace12.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace12.Color);
                    }
                    break;

                case 10013:
                    if (LoggingUIConfig.Trace13.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace13.Color);
                    }
                    break;

                case 10014:
                    if (LoggingUIConfig.Trace14.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace14.Color);
                    }
                    break;

                case 10015:

                    if (LoggingUIConfig.Trace15.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace15.Color);
                    }
                    break;

                case 10016:
                    if (LoggingUIConfig.Trace16.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace16.Color);
                    }
                    break;

                case 10017:
                    if (LoggingUIConfig.Trace17.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace17.Color);
                    }
                    break;

                case 10018:
                    if (LoggingUIConfig.Trace18.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace18.Color);
                    }
                    break;

                case 10019:
                    if (LoggingUIConfig.Trace19.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace19.Color);
                    }
                    break;

                #endregion

                #region Trace20 - Trace29

                case 10020:
                    if (LoggingUIConfig.Trace20.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace20.Color);
                    }
                    break;

                case 10021:
                    if (LoggingUIConfig.Trace21.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace21.Color);
                    }
                    break;

                case 10022:
                    if (LoggingUIConfig.Trace22.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace22.Color);
                    }
                    break;

                case 10023:
                    if (LoggingUIConfig.Trace23.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace23.Color);
                    }
                    break;

                case 10024:
                    if (LoggingUIConfig.Trace24.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace24.Color);
                    }
                    break;

                case 10025:
                    if (LoggingUIConfig.Trace25.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace25.Color);
                    }
                    break;

                case 10026:
                    if (LoggingUIConfig.Trace26.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace26.Color);
                    }
                    break;

                case 10027:
                    if (LoggingUIConfig.Trace27.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace27.Color);
                    }
                    break;

                case 10028:
                    if (LoggingUIConfig.Trace28.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace28.Color);
                    }
                    break;

                case 10029:
                    if (LoggingUIConfig.Trace29.IsChecked == true)
                    {
                        AppendColorFormatedMessage(message,
                            LoggingUIConfig.Trace29.Color);
                    }
                    break;

                #endregion

                default:
                    AppendFormattedMessage(message);
                    break;
            }
        }

        public void AppendFormattedMessage(string formattedMessage)
        {
            // TODO(crhodes)
            // Doc maybe null when program exits.
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (Doc != null)
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
            });
        }

        public void AppendColoredText(string formattedMessage, Color color)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
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
            });
        }

        public void AppendColorFormatedMessage(string formattedMessage, Color color)
        {
            // HACK(crhodes)
            // See if this is fast, Skip all color formatting

            //AppendFormattedMessage(formattedMessage);
            //return;

            // HACK(crhodes)
            // Ok, let's make the whole line colored

            if (HilightOffset == 0)
            {
                AppendColoredText(formattedMessage, color);
                return;
            }

            int messageIndex = 0;

#if NET48
            messageIndex = GetNthIndex2(formattedMessage, '|', HilightOffset);
#else
            messageIndex = GetNthIndex3(formattedMessage, '|', HilightOffset);
#endif

            try
            {
                if (messageIndex++ > 0)
                {
                    string prefixMessage = formattedMessage.Substring(0, messageIndex);
                    AppendFormattedMessage(prefixMessage);

                    string colorMessage = formattedMessage.Substring(messageIndex);
                    AppendColoredText(colorMessage, color);
                }
                else
                {
                    AppendColoredText(formattedMessage, color);
                }
            }
            catch (Exception ex)
            {
                AppendColoredText(ex.ToString(), Color.Red);
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

#if NET48

#else
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
#endif

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
