using System;
using System.Windows;

using VNCLogViewer.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;
using DevExpress.Xpf.Editors;
using DevExpress.XtraRichEdit;

namespace VNCLogViewer.Presentation.Views
{
    public partial class RecControls : ViewBase, IUIConfig, IInstanceCountV
    {

        #region Constructors and Load
        
        public RecControls()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            
			// Expose ViewModel
						
            // If View First with ViewModel in Xaml

            // ViewModel = (IUIConfigViewModel)DataContext;

            // Can create directly
            // ViewModel = UIConfigViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public UIConfig(IUIConfigViewModel viewModel)
        //{
        //    Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

        //    InstanceCountV++;
        //    InitializeComponent();

        //    ViewModel = viewModel;

        //    Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        #endregion

        #region Enums (None)


        #endregion

        #region Structures (None)


        #endregion

        #region Fields and Properties

        public new ILiveLogViewerViewModel ViewModel
        {
            get { return (ILiveLogViewerViewModel)DataContext; }
            set { DataContext = value; }
        }

        #endregion

        #region Event Handlers (None)


        #endregion

        #region Commands (None)

        #endregion

        #region Public Methods (None)


        #endregion

        #region Protected Methods (None)


        #endregion

        #region Private Methods (None)

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Doc.SelectAll();
            ViewModel.Doc.Cut();
            //InitializeLogStream();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Doc.SelectAll();
            ViewModel.Doc.Copy();
        }
        //private void CbeRichEditViewType_EditValueChanged(object sender, EditValueChangedEventArgs e)
        //{
        //    InitializeLogStream();
        //}

        //private void InitializeLogStream()
        //{
        //    ViewModel.Doc.ActiveViewType = (RichEditViewType)cbeRichEditViewType.SelectedIndex;
        //    ViewModel..ActiveView.BackColor = System.Drawing.Color.Black;

        //    //Document doc = recLogStream.Document;

        //    //DevExpress.XtraRichEdit.API.Native.Section section = doc.Sections[0];

        //    Section section = ((ILiveLogViewerViewModelREC)ViewModel).Doc.Sections[0];

        //    section.Page.PaperKind = System.Drawing.Printing.PaperKind.B4;
        //    section.Page.Landscape = true;
        //    section.Margins.Left = 0.1f;
        //    section.Margins.Right = 0.1f;
        //}

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
