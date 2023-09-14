using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

using DevExpress.XtraPrinting.Native;

#if NET48
using Microsoft.AspNet.SignalR.Client;
#else
using Microsoft.AspNetCore.SignalR.Client;
#endif

using VNC;
using VNC.Core.Mvvm;

using VNCLogViewer.Domain;
using VNCLogViewer.Presentation.ViewModels;

namespace VNCLogViewer.Presentation.Views
{
    public partial class SignalRInteraction : ViewBase, ISignalRInteraction, IInstanceCountV
    {

        #region Constructors and Load
        
        public SignalRInteraction()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            DataContext = this;

            InitializeView();

            // Expose ViewModel

            // If View First with ViewModel in Xaml

            // ViewModel = (ISignalRInteractionViewModel)DataContext;

            // Can create directly
            // ViewModel = SignalRInteractionViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public SignalRInteraction(ISignalRInteractionViewModel viewModel)
        //{
        //    Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

        //    InstanceCountV++;
        //    InitializeComponent();

        //InitializeView();

        //    ViewModel = viewModel;

        //    Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        private void InitializeView()
        {
            Int64 startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            lgChatPanel.Visibility = Visibility.Hidden;
            btnSignOut.IsEnabled = false;

            Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (None)


        #endregion

        #region Structures (None)


        #endregion

        #region Fields and Properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ILiveLogViewerViewModel ViewModel { get; set; }

#if NET48
        private string _serverURI = "http://localhost:58095";

        public IDisposable SignalR { get; set; }

        public IHubProxy HubProxy { get; set; }

        public HubConnection Connection { get; set; }
#else
        private string _serverURI = "http://localhost:58195/signalR";

        public HubConnection Connection { get; set; }
#endif

        public string ServerURI { get => _serverURI; set => _serverURI = value; }

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

        #endregion

        #region Event Handlers

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(UserName))
            {
                //Connect to server (use async method to avoid blocking UI thread)
                ConnectAsync();

                lgChatPanel.Visibility = Visibility.Visible;
                btnSend.IsEnabled = true;
                btnSendPriority.IsEnabled = true;

                btnSignIn.IsEnabled = false;
                btnSignOut.IsEnabled = true;
            }
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
#if NET48
            Connection.Stop();
            Connection.Dispose();
            Connection = null;
#else
            Connection.StopAsync();
            Connection.DisposeAsync();
            Connection = null;
#endif
            lgChatPanel.Visibility = Visibility.Hidden;
            btnSend.IsEnabled = false;
            btnSendPriority.IsEnabled = false;

            btnSignIn.IsEnabled = true;
            btnSignOut.IsEnabled = false;
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
#if NET48
            await HubProxy.Invoke("SendUserMessage", UserName, Message);
#else
            await Connection.InvokeAsync("SendUserMessage", UserName, Message);
#endif
            tbMessage.Text = String.Empty;
            tbMessage.Focus();
        }

        private async void btnSendPriority_Click(object sender, RoutedEventArgs e)
        {
#if NET48
            HubProxy.Invoke("SendPriorityMessage", Message, Priority);
#else
            await Connection.InvokeAsync("SendPriorityMessage", Message, Priority);
#endif
            tbMessage.Text = String.Empty;
            tbMessage.Focus();
        }

        #endregion

        #region Commands (None)

        #endregion

        #region Public Methods (None)


        #endregion

        #region Protected Methods (None)


        #endregion

        #region Private Methods (None)

        public async void ConnectAsync()
        {
            //Connection = new HubConnectionBuilder()
            //    .WithUrl(ServerURI)
            //    .Build();

            //Connection.Closed += Connection_Closed;
            //Connection.Reconnecting += Connection_Reconnecting;
            //Connection.Reconnected += Connection_Reconnected;

            ////Handle incoming event from server: use Invoke to write to console from SignalR's thread

            //string formattedMessage = "";

            //Connection.On<string>("AddMessage", (message) =>
            //      ViewModel.AppendFormattedMessage($"{message}\r")
            //  );

            //Connection.On<string, string>("AddUserMessage", (name, message) =>
            //    ViewModel.AppendFormattedMessage($"{name}: {message}\r")
            //);

            //Connection.On<string, int>("AddPriorityMessage", (message, priority) =>
            //    ViewModel.ProcessPriorityMessage($"{message}\r", priority)
            //);

            //Connection.On<string, SignalRTime>("AddTimedMessage", (message, signalrtime) =>
            //{
            //    signalrtime.ClientReceivedTime = DateTime.Now;
            //    signalrtime.ClientReceivedTicks = Stopwatch.GetTimestamp();

            //    ViewModel.AppendFormattedMessage($"{message}\r");

            //    signalrtime.ClientMessageTime = DateTime.Now;
            //    signalrtime.ClientMessageTicks = Stopwatch.GetTimestamp();

            //    ViewModel.AppendFormattedMessage($"SendT:    {signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff}\r");

            //    ViewModel.AppendFormattedMessage($"HubRT:    {signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.HubReceivedTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

            //    ViewModel.AppendFormattedMessage($"ClientRT: {signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientReceivedTicks - signalrtime.HubReceivedTicks) / (double)Stopwatch.Frequency}\r");

            //    ViewModel.AppendFormattedMessage($"ClientMT: {signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientMessageTicks - signalrtime.ClientReceivedTicks) / (double)Stopwatch.Frequency}\r");

            //    ViewModel.AppendFormattedMessage($"Duration: {(signalrtime.ClientMessageTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

            //});

#if NET48
            Connection = new HubConnection(tbServerURI.Text);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("SignalRHub");

            //Handle incoming event from server: use Invoke to write to console from SignalR's thread

            HubProxy.On<string>("AddMessage", (message) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage(String.Format("{0}\r", message))
                )
            );

            HubProxy.On<string, string>("AddUserMessage", (name, message) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage(String.Format("{0}: {1}\r", name, message))
                )
            );

            HubProxy.On<string, Int32>("AddPriorityMessage", (message, priority) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"P{priority}: {message}\r")
                )
            );

#else
            Connection = new HubConnectionBuilder()
                .WithUrl(ServerURI)
                .Build();

            Connection.Closed += Connection_Closed;
            Connection.Reconnecting += Connection_Reconnecting;
            Connection.Reconnected += Connection_Reconnected;

            //Handle incoming event from server: use Invoke to write to console from SignalR's thread

            Connection.On<string>("AddMessage", (message) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"{message}\r")
                )
            );

            Connection.On<string, string>("AddUserMessage", (name, message) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"{name}: {message}\r")
                )
            );

            Connection.On<string, Int32>("AddPriorityMessage", (message, priority) =>
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"P{priority}: {message}\r")
                )
            );

#endif
#if NET48
            HubProxy.On<string, SignalRTime>("AddTimedMessage", (message, signalrtime) =>
            {
                signalrtime.ClientReceivedTime = DateTime.Now;
                signalrtime.ClientReceivedTicks = Stopwatch.GetTimestamp();

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"{message}\r"));

                signalrtime.ClientMessageTime = DateTime.Now;
                signalrtime.ClientMessageTicks = Stopwatch.GetTimestamp();

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"SendT:    {signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff} Send:{signalrtime.SendTicks}\r"));

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"HubRT:    {signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.HubReceivedTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r"));

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"ClientRT: {signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientReceivedTicks - signalrtime.HubReceivedTicks) / (double)Stopwatch.Frequency}\r"));

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"ClientMT: {signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientMessageTicks - signalrtime.ClientReceivedTicks) / (double)Stopwatch.Frequency}\r"));

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"Duration: {(signalrtime.ClientMessageTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r"));

            });
#else
            Connection.On<string, SignalRTime>("AddTimedMessage", (message, signalrtime) =>
            {
                signalrtime.ClientReceivedTime = DateTime.Now;
                signalrtime.ClientReceivedTicks = Stopwatch.GetTimestamp();
                //this.Dispatcher.InvokeAsync(() =>
                //    ViewModel.AppendFormattedMessage($"SendT:{signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff} Send:{signalrtime.SendTicks} HubRT:{signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} HubR:{signalrtime.HubReceivedTicks} ClientRT:{signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} ClientR:{signalrtime.ClientReceivedTicks} ClientMT:{signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} ClientM:{signalrtime.ClientMessageTicks} : {message}\r")
                //);
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"{message}\r"));

                signalrtime.ClientMessageTime = DateTime.Now;
                signalrtime.ClientMessageTicks = Stopwatch.GetTimestamp();

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"SendT:    {signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff} Send:{signalrtime.SendTicks}\r"));

                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"HubRT:    {signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.HubReceivedTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r"));
                
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"ClientRT: {signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientReceivedTicks - signalrtime.HubReceivedTicks) / (double)Stopwatch.Frequency}\r"));
                
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"ClientMT: {signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientMessageTicks - signalrtime.ClientReceivedTicks) / (double)Stopwatch.Frequency}\r"));
                
                this.Dispatcher.InvokeAsync(() =>
                    ViewModel.AppendFormattedMessage($"Duration: {(signalrtime.ClientMessageTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r"));

            });
#endif
            string formattedMessage = "";

            try
            {
#if NET48
                await Connection.Start();
#else
                await Connection.StartAsync();
#endif
            }
            catch (HttpRequestException hre)
            {
                formattedMessage = $"Unable to connect to server: Start server before connecting clients. {hre.Message}\r";
                ViewModel.AppendFormattedMessage(formattedMessage);
                return;
            }
            catch (Exception ex)
            {
                formattedMessage = $"Unable to connect to server, ex: {ex.Message}\r";
                ViewModel.AppendFormattedMessage(formattedMessage);
                return;
            }

            formattedMessage = $"Connected to server at {ServerURI}\r";
            ViewModel.AppendFormattedMessage(formattedMessage);

            //Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

#if NET48
        void Connection_Closed()
        {
            ViewModel.AppendColorFormatedMessage($"Connection Closed.\r",
                System.Drawing.Color.Red);
        }
#else
        Task Connection_Closed(Exception? arg)
        {
            ViewModel.AppendColorFormatedMessage($"Connection Closed {(arg is null ? "" : arg.Message)}.\r", 
                System.Drawing.Color.Red);

            return null;
        }  
#endif

#if NET48

#else
        private Task Connection_Reconnecting(Exception? arg)
        {
            ViewModel.AppendColorFormatedMessage($"Reconnecting {(arg is null ? "" : arg.Message)}.", 
                System.Drawing.Color.Red);

            return null;
        }

        private Task Connection_Reconnected(string? arg)
        {
            ViewModel.AppendColorFormatedMessage($"Reconnected {(arg is null ? "" : arg)}", 
                System.Drawing.Color.Red);

            return null;
        }
#endif

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
