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
    public partial class LiveLogViewerMINSKMain : UserControl, ILiveLogViewerVNCMain, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public LiveLogViewerMINSKMain(ILiveLogViewerViewModel viewModel)
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
            ((ILiveLogViewerViewModel)ViewModel).LoggingUIConfig = new LoggingUIConfig.LoggingUIConfigMINSK();
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