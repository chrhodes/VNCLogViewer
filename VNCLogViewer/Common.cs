

using System;
using System.Reflection;

namespace VNCLogViewer
{
    public static class Common
    {
        private static string _fileVersion;
        private static string _productName;
        private static string _productVersion;
        private static string _runtimeVersion;

        public const string PROJECT_NAME = "VNCLogViewer";
        public const string LOG_CATEGORY = "VNCLogViewer";

        public const string cCONFIG_FILE = @"C:\temp\VNCLogViewer_Config.xml";


        public static string RuntimeVersion
        {
            get => _runtimeVersion;
            set => _runtimeVersion = value;
        }

        public static string FileVersion
        {
            get => _fileVersion;
            set => _fileVersion = value;
        }

        public static string ProductName
        {
            get => _productName;
            set => _productName = value;
        }

        public static string ProductVersion
        {
            get => _productVersion;
            set => _productVersion = value;
        }

        public static event EventHandler AutoHideGroupSpeedChanged;

        private static int _AutoHideGroupSpeed = 250;

        public static int AutoHideGroupSpeed
        {
            get { return _AutoHideGroupSpeed; }
            set
            {
                _AutoHideGroupSpeed = value;

                EventHandler evt = AutoHideGroupSpeedChanged;

                if (evt != null)
                {
                    evt(null, EventArgs.Empty); ;
                }
            }
        }

        //public static void RaiseAutoHideGroupSpeedChanged()
        //{
        //    EventHandler evt = AutoHideGroupSpeedChanged;

        //    if (evt != null)
        //    {
        //        evt(null, EventArgs.Empty); ;
        //    }
        //}

        // NB. These are in Common.AddInHelper

        /// <summary>
        /// Indicates whether the UI is running in DeveloperMode
        /// </summary>
        public static bool DeveloperMode
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the UI is running in DebugMode
        /// </summary>
        public static bool DebugMode
        {
            get;
            set;
        }

        // These values are added to the dimensions of a hosting window if the
        // hosted User_Control specifies values for MinWidth/MinHeight.
        // They have not been thought through but do seem to "work".

        internal const int WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD = 30;
        internal const int WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD = 75;
        public static void SetAppVersionInfo()
        { 
            var runtimeVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(int).Assembly.Location);

            Common.RuntimeVersion = runtimeVersion.FileVersion;

            //var rv = runtimeVersion.Comments;
            //var rv1 = runtimeVersion.CompanyName;
            //var rv2 = runtimeVersion.FileDescription;
            //var rv3 = runtimeVersion.FileName;
            //var rv4 = runtimeVersion.FileVersion;
            //var rv5 = runtimeVersion.ProductVersion;
            //var rv6 = runtimeVersion.ProductName;


            //var assyb = Assembly.GetExecutingAssembly();
            //var a3 = assyb.Location;
            var appVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            var av = appVersion.Comments;
            var av1 = appVersion.CompanyName;
            var av2 = appVersion.FileDescription;
            var av3 = appVersion.FileName;
            var av4 = appVersion.FileVersion;
            var av5 = appVersion.ProductVersion;
            var av6 = appVersion.ProductName;

            Common.FileVersion = appVersion.FileVersion;
            Common.ProductName = appVersion.ProductName;
            Common.ProductVersion = appVersion.ProductVersion;

        }

        // This controls the behavior of the overall application.
        // It is initialized from app.config and is updated when the user changes the mode.
        // Changes are reflected in the app.config file.

        // public static IPrincipal CurrentUser
        // {
        // get;
        // set;
        // }

        // public static User_Interface.ViewMode UserMode { get; set; }

        // public static bool IsAdministrator { get; set; }
        // public static bool IsBetaUser { get; set; }
        // public static bool IsDeveloper { get; set; }
        // //public static bool IsAdvancedUser { get; set; }

        // public static bool AllowEditing { get; set; }

        // public static string RowDetailMode { get; set; }

        // private static bool _DataFullyLoaded = false;
        // public static bool DataFullyLoaded
        // {
        // get { return _DataFullyLoaded; }
        // set
        // {
        // _DataFullyLoaded = value;
        // }
        // }

        // // TODO(crhodes): Get rid of this (I think) and use the one from VNCCodeCommandConsole.  See if need anything else
        // // in  a DataSet first.  May want a separate one for the App.
        // private static Data.ApplicationDataSet _ApplicationDataSet;

        // public static Data.ApplicationDataSet ApplicationDataSet
        // {
        // get
        // {
        // if (_ApplicationDataSet == null)
        // {
        // //_ApplicationDataSet = new VNCCodeCommandConsole.Data.ApplicationDataSet();
        // _ApplicationDataSet = new Data.ApplicationDataSet();

        // // TODO: Add any other initialization of things related to the ApplicationDataSet
        // }

        // return _ApplicationDataSet;
        // }
        // set
        // {
        // _ApplicationDataSet = value;
        // }
        // }

        // public static void IndicateApplicationUsage(string application, DateTime eventDate, string user, string message)
        // {
        // if ( ! Data.Config.DBBypass)
        // {
        // var dataRow = Common.ApplicationDataSet.ApplicationUsage.NewApplicationUsageRow();

        // dataRow.Application = application;
        // dataRow.EventDate = eventDate;
        // dataRow.User = user;
        // dataRow.EventMessage = message;

        // Common.ApplicationDataSet.ApplicationUsage.AddApplicationUsageRow(dataRow);

        // Data.ApplicationDataSetTableAdapters.ApplicationUsageTableAdapter applicationUsageTA = new Data.ApplicationDataSetTableAdapters.ApplicationUsageTableAdapter();
        // applicationUsageTA.Update(Common.ApplicationDataSet.ApplicationUsage);
        // }
        // }
    }
}
