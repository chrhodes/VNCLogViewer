using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.AspNetCore.SignalR.Client;

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

        #region Fields and Properties (None)

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //long startTicks = Log.VIEWMODEL_LOW("Enter (" + propertyName + ")", "VNCCore");
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //Log.VIEWMODEL_LOW("Exit", "VNCCore", startTicks);
        }

        //public String UserName { get; set; }

        //public new ILiveLogViewerViewModel ViewModel
        //{
        //    get { return (ILiveLogViewerViewModel)DataContext; }
        //    set { DataContext = value; }
        //}

        public ILiveLogViewerViewModel ViewModel { get; set; }

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

        #endregion

        #region Event Handlers (None)

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //UserName = tUserNameTextBox.Text;

            if (!String.IsNullOrEmpty(UserName))
            {
                //Connect to server (use async method to avoid blocking UI thread)
                ConnectAsync();

                //Show chat UI; hide login UI
                //SignInPanel.Visibility = Visibility.Collapsed;
                lgChatPanel.Visibility = Visibility.Visible;
                btnSend.IsEnabled = true;
                btnSendPriority.IsEnabled = true;
                tbMessage.Focus();

                btnSignIn.IsEnabled = false;
                btnSignOut.IsEnabled = true;
            }
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            StopAsync();
            DisposeAsync();

            lgChatPanel.Visibility = Visibility.Hidden;
            btnSend.IsEnabled = false;
            btnSendPriority.IsEnabled = false;

            btnSignIn.IsEnabled = true;
            btnSignOut.IsEnabled = false;
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await Connection.InvokeAsync("SendUserMessage", UserName, Message);

            tbMessage.Text = String.Empty;
            tbMessage.Focus();
        }

        private async void btnSendPriority_Click(object sender, RoutedEventArgs e)
        {
            await Connection.InvokeAsync("SendPriorityMessage", Message, Priority);

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

        //public void Send()
        //{
        //    //Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

        //    Connection.InvokeAsync("SendUserMessage", UserName, Message);

        //    //Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        //public void SendPriority()
        //{
        //    //Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

        //    Connection.InvokeAsync("SendPriorityMessage", Message, Priority);

        //    //Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        //}

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

            Connection.On<string>("AddMessage", (message) =>
                  ViewModel.AppendFormattedMessage($"{message}\r")
              );

            Connection.On<string, string>("AddUserMessage", (name, message) =>
                ViewModel.AppendFormattedMessage($"{name}: {message}\r")
            );

            Connection.On<string, int>("AddPriorityMessage", (message, priority) =>
                ViewModel.ProcessPriorityMessage($"{message}\r", priority)
            );

            Connection.On<string, SignalRTime>("AddTimedMessage", (message, signalrtime) =>
            {
                signalrtime.ClientReceivedTime = DateTime.Now;
                signalrtime.ClientReceivedTicks = Stopwatch.GetTimestamp();

                ViewModel.AppendFormattedMessage($"{message}\r");

                signalrtime.ClientMessageTime = DateTime.Now;
                signalrtime.ClientMessageTicks = Stopwatch.GetTimestamp();

                ViewModel.AppendFormattedMessage($"SendT:    {signalrtime.SendTime:yyyy/MM/dd HH:mm:ss.ffff}\r");

                ViewModel.AppendFormattedMessage($"HubRT:    {signalrtime.HubReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.HubReceivedTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

                ViewModel.AppendFormattedMessage($"ClientRT: {signalrtime.ClientReceivedTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientReceivedTicks - signalrtime.HubReceivedTicks) / (double)Stopwatch.Frequency}\r");

                ViewModel.AppendFormattedMessage($"ClientMT: {signalrtime.ClientMessageTime:yyyy/MM/dd HH:mm:ss.ffff} - Duration:{(signalrtime.ClientMessageTicks - signalrtime.ClientReceivedTicks) / (double)Stopwatch.Frequency}\r");

                ViewModel.AppendFormattedMessage($"Duration: {(signalrtime.ClientMessageTicks - signalrtime.SendTicks) / (double)Stopwatch.Frequency}\r");

            });

            try
            {
                await Connection.StartAsync();
            }
            catch (HttpRequestException hre)
            {
                formattedMessage = $"Unable to connect to server: Start server before connecting clients. {hre.Message}";
                //No connection: Don't enable Send button or show chat UI
                ViewModel.AppendFormattedMessage(formattedMessage);
                return;
            }
            catch (Exception ex)
            {
                formattedMessage = $"Unable to connect to server, ex: {ex.Message}";
                //No connection: Don't enable Send button or show chat UI
                ViewModel.AppendFormattedMessage(formattedMessage);
                return;
            }

            ////Show chat UI; hide login UI
            //SignInPanel.Visibility = Visibility.Collapsed;
            //ChatPanel.Visibility = Visibility.Visible;
            //btnSend.IsEnabled = true;
            //btnSendPriority.IsEnabled = true;
            //tbMessage.Focus();
            formattedMessage = "Connected to server at " + ServerURI + "\n";

            ViewModel.AppendFormattedMessage(formattedMessage);

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
            ViewModel.AppendColorFormatedMessage($"Connection Closed {(arg is null ? "" : arg.Message)}.", 
                System.Drawing.Color.Red);

            return null;
        }

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
