using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

using VNCLogViewer.Core;
using VNCLogViewer.Presentation.ViewModels;
using VNCLogViewer.Presentation.Views;

namespace VNCLogViewer
{
    public class LiveLogViewerEASEModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public LiveLogViewerEASEModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            //_container = container;
            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            //containerRegistry.Register<ILiveLogViewerEASEDetailViewModel, LiveLogViewerEASEDetailViewModel>();
            //containerRegistry.Register<ILiveLogViewerEASEDetail, LiveLogViewerEASEDetail>();

            containerRegistry.Register<ILiveLogViewerViewModelREC, LiveLogViewerViewModelREC>();
            containerRegistry.Register<ILiveLogViewerEASEMain, LiveLogViewerEASEMain>();

            //containerRegistry.RegisterSingleton<ILiveLogViewerEASENavigationViewModel, LiveLogViewerEASENavigationViewModel>();
            //containerRegistry.RegisterSingleton<ILiveLogViewerEASENavigation, LiveLogViewerEASENavigation>();

            //containerRegistry.RegisterSingleton<ILiveLogViewerEASELookupDataService, LiveLogViewerEASELookupDataService>();
            //containerRegistry.RegisterSingleton<ILiveLogViewerEASEDataService, LiveLogViewerEASEDataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            //this loads LiveLogViewerEASEMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerEASEMainRegion, typeof(LiveLogViewerEASEMain));

            // These load into LiveLogViewerEASEMain.xaml
            //_regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerEASENavigationRegion, typeof(LiveLogViewerEASENavigation));
            //_regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerEASEDetailRegion, typeof(LiveLogViewerEASEDetail));

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}