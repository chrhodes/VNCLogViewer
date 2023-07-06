using System;
using System.Windows;

using VNCLogViewer.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace VNCLogViewer.Presentation.Views
{
    public partial class DefaultFilter : ViewBase, IDefaultFilter, IInstanceCountV
    {

        #region Constructors and Load
        
        public DefaultFilter()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            
			// Expose ViewModel
						
            // If View First with ViewModel in Xaml

            // ViewModel = (IDefaultFilterViewModel)DataContext;

            // Can create directly
            // ViewModel = DefaultFilterViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public DefaultFilter(IDefaultFilterViewModel viewModel)
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

        #region Fields and Properties (None)


        #endregion

        #region Event Handlers (None)

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
