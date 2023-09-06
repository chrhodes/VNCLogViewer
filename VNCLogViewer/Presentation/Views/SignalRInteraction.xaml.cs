﻿using System;
using System.Windows;

using VNCLogViewer.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;
using DevExpress.XtraRichEdit.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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


        public String UserName { get; set; }

        public new ILiveLogViewerViewModel ViewModel
        {
            get { return (ILiveLogViewerViewModel)DataContext; }
            set { DataContext = value; }
        }

        #endregion

        #region Event Handlers (None)

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            UserName = UserNameTextBox.Text;

            if (!String.IsNullOrEmpty(UserName))
            {
                //Connect to server (use async method to avoid blocking UI thread)
                ViewModel.ConnectAsync();
                //ConnectAsync();

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
            ViewModel.StopAsync();
            ViewModel.DisposeAsync();

            lgChatPanel.Visibility = Visibility.Hidden;
            btnSend.IsEnabled = false;
            btnSendPriority.IsEnabled = false;

            btnSignIn.IsEnabled = true;
            btnSignOut.IsEnabled = false;
        }

        // TODO(crhodes)
        // If we implement SignOut, hide ChatPanel

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //await Connection.InvokeAsync("SendUserMessage", UserName, tbMessage.Text);
            ViewModel.Send();

            tbMessage.Text = String.Empty;
            tbMessage.Focus();
        }

        private async void btnSendPriority_Click(object sender, RoutedEventArgs e)
        {
            //await Connection.InvokeAsync("SendPriorityMessage", tbMessage.Text, Int32.Parse(tbMessagePriority.Text));
            ViewModel.SendPriority();

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
