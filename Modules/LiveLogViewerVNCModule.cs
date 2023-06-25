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
    public class LiveLogViewerVNCModule : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public LiveLogViewerVNCModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // This is where you pick the style of what gets loaded in the Shell.

            // If you are using the Ribbon Shell and the RibbonRegion

            containerRegistry.RegisterSingleton<IRibbonViewModel, RibbonViewModel>();
            containerRegistry.RegisterSingleton<IRibbon, Ribbon>();

            // Pick one of these for the MainRegion
            // Use Main to see the AutoWireViewModel in action.

            //containerRegistry.Register<IMain, Main>();            
            //containerRegistry.Register<IMain, MainDxLayout>();
            //containerRegistry.Register<IMain, MainDxDockLayoutManager>();  

            containerRegistry.Register<ILiveLogViewerViewModel, LiveLogViewerVNCMainViewModel>();
            containerRegistry.Register<ILiveLogViewerVNCMain, LiveLogViewerVNCMain>();

            containerRegistry.Register<ILiveLogViewerViewModel, LiveLogViewerVNC2MainViewModel>();
            containerRegistry.Register<ILiveLogViewerVNCMain, LiveLogViewerVNC2Main>();

            //containerRegistry.Register<ILiveLogViewerEASEMainViewModel, LiveLogViewerEASEMainViewModel>();
            //containerRegistry.Register<ILiveLogViewerEASEMain, LiveLogViewerEASEMain>();

            //containerRegistry.RegisterSingleton<ILiveLogViewerVNCNavigationViewModel, LiveLogViewerVNCNavigationViewModel>();
            //containerRegistry.RegisterSingleton<ILiveLogViewerVNCNavigation, LiveLogViewerVNCNavigation>();

            //containerRegistry.RegisterSingleton<ILiveLogViewerVNCLookupDataService, LiveLogViewerVNCLookupDataService>();
            //containerRegistry.RegisterSingleton<ILiveLogViewerVNCDataService, LiveLogViewerVNCDataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(IRibbon));
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(IMain));

            //this loads LiveLogViewerVNCMain into the Shell loaded in App.Xaml.cs

            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCMainRegion, typeof(LiveLogViewerVNCMain));
            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNC2MainRegion, typeof(LiveLogViewerVNC2Main));
            //_regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerEASEMainRegion, typeof(LiveLogViewerEASEMain));

            // These load into LiveLogViewerVNCMain.xaml
            //_regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCNavigationRegion, typeof(LiveLogViewerVNCNavigation));
            //_regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCDetailRegion, typeof(LiveLogViewerVNCDetail));

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}