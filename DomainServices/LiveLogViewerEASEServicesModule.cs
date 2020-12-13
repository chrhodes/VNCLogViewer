using System;

using Prism.Ioc;
using Prism.Modularity;

using VNC;

namespace VNCLogViewer.DomainServices
{
    public class LiveLogViewerEASEServicesModule : IModule
    {
        IContainerProvider _containerProvider;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            _containerProvider = containerProvider;

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_APPNAME);

            Log.MODULE("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
