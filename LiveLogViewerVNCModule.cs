using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using VNC;

using VNCLogViewer.Core;
using VNCLogViewer.DomainServices;
using VNCLogViewer.Presentation.ViewModels;
using VNCLogViewer.Presentation.Views;

namespace VNCLogViewer
{
    public class LiveLogViewerVNCModule : IModule
    {
        private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        // 01

        public LiveLogViewerVNCModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            //_container = container;
            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            containerRegistry.Register<ILiveLogViewerVNCDetailViewModel, LiveLogViewerVNCDetailViewModel>();
            containerRegistry.Register<ILiveLogViewerVNCDetail, LiveLogViewerVNCDetail>();

            containerRegistry.Register<ILiveLogViewerVNCMainViewModel, LiveLogViewerVNCMainViewModel>();
            containerRegistry.Register<ILiveLogViewerVNCMain, LiveLogViewerVNCMain>();

            containerRegistry.RegisterSingleton<ILiveLogViewerVNCNavigationViewModel, LiveLogViewerVNCNavigationViewModel>();
            containerRegistry.RegisterSingleton<ILiveLogViewerVNCNavigation, LiveLogViewerVNCNavigation>();

            containerRegistry.RegisterSingleton<ILiveLogViewerVNCLookupDataService, LiveLogViewerVNCLookupDataService>();
            containerRegistry.RegisterSingleton<ILiveLogViewerVNCDataService, LiveLogViewerVNCDataService>();

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            //this loads LiveLogViewerVNCMain into the Shell loaded in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCMainRegion, typeof(LiveLogViewerVNCMain));

            // These load into LiveLogViewerVNCMain.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCNavigationRegion, typeof(LiveLogViewerVNCNavigation));
            _regionManager.RegisterViewWithRegion(RegionNames.LiveLogViewerVNCDetailRegion, typeof(LiveLogViewerVNCDetail));

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}