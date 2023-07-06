using System.Drawing;
using System.Windows;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigEASE : LoggingUIConfig
    {
        public LoggingUIConfigEASE()
        {
            Name = "EASE Capture Filter";

            Info00 = new LoggingLevel { Label = "100", ToolTip = "APPLICATION_START / APPLICATION_END / LOADEASE / Info00" };

            Debug02 = new LoggingLevel { Label = "Debug02", LabelColor = Color.Red, Color = Color.Red, ToolTip = "SQL_CALL / Debug02" };

            Trace00 = new LoggingLevel { Label = "10000", LabelColor = Color.Lime, Color = Color.Lime, ToolTip = "PAGE_LOAD / FORM_LOAD / Trace00" };
            Trace01 = new LoggingLevel { Label = "10001", LabelColor = Color.Cyan, Color = Color.Cyan, ToolTip = "EVENTHANDLER / Trace01" };
            Trace02 = new LoggingLevel { Label = "10002", ToolTip = "STATUS / Trace02" };
            Trace03 = new LoggingLevel { Label = "10003", LabelColor = Color.GreenYellow, Color = Color.GreenYellow, ToolTip = "REDIRECT_TRANSFER / Trace03" };
            Trace04 = new LoggingLevel { Label = "10004", LabelColor = Color.BurlyWood, Color = Color.BurlyWood, ToolTip = "POLLING / Trace04" };
            Trace05 = new LoggingLevel { Label = "10005", LabelColor = Color.Yellow, Color = Color.Yellow, ToolTip = "ERROR_TRACE / Trace05" };
            Trace06 = new LoggingLevel { Label = "10006", LabelColor = Color.DarkCyan, Color = Color.DarkCyan, ToolTip = "EASESYS_IO / Trace06" };
            Trace07 = new LoggingLevel { Label = "10007", LabelColor = Color.LightPink, Color = Color.LightPink, ToolTip = "UI_CONTROL / Trace07" };
            Trace08 = new LoggingLevel { Label = "10008", LabelColor = Color.SlateGray, Color = Color.SlateGray, ToolTip = "UTILITY / Trace08" };
            Trace09 = new LoggingLevel { Label = "10009", ToolTip = "OPERATION / Trace09" };
                                                          
            Trace10 = new LoggingLevel { Label = "10010", LabelColor = Color.Plum, Color = Color.Plum, ToolTip = "APPLICATION_SESSION / Trace10" };
            Trace11 = new LoggingLevel { Label = "10011", LabelColor = Color.Orange, Color = Color.Orange, ToolTip = "SYSTEM_CONFIG / Trace11" };
            Trace12 = new LoggingLevel { Label = "10012", LabelColor = Color.Chocolate, Color = Color.Chocolate, ToolTip = "FILE_DIR_IO / Trace12" };
            Trace13 = new LoggingLevel { Label = "10013", LabelColor = Color.Olive, Color = Color.Olive, ToolTip = "DATABASE_IO / Trace13" };
            Trace14 = new LoggingLevel { Label = "10014", LabelColor = Color.Fuchsia, Color = Color.Fuchsia, ToolTip = "SECURITY / Trace14" };
            Trace15 = new LoggingLevel { Label = "10015", LabelColor = Color.Yellow, Color = Color.Yellow, ToolTip = "ERROR_TRACE_LOW / Trace15" };
            Trace16 = new LoggingLevel { Label = "10016", LabelColor = Color.DarkCyan, Color = Color.DarkCyan, ToolTip = "EASESYS_IO_MED / Trace16" };
            Trace17 = new LoggingLevel { Label = "10017", LabelColor = Color.LightPink, Color = Color.LightPink, ToolTip = "UI_CONTROL_MED / Trace17" };
            Trace18 = new LoggingLevel { Label = "10018", LabelColor = Color.SlateGray, Color = Color.SlateGray, ToolTip = "UTILITY_MED / Trace18" };
            Trace19 = new LoggingLevel { Label = "10019", ToolTip = "OPERATION_LOW / DEFAULT / Trace19" };
                                                         
            Trace20 = new LoggingLevel { Label = "10020", LabelColor = Color.Plum, Color = Color.Plum, ToolTip = "APPLICATION_SESSION_LOW / Trace20" };
            Trace21 = new LoggingLevel { Label = "10021", LabelColor = Color.Orange, Color = Color.Orange, ToolTip = "SYSTEMCONFIG_LOW / Trace21" };
            Trace22 = new LoggingLevel { Label = "10022", LabelColor = Color.Chocolate, Color = Color.Chocolate, ToolTip = "FILE_DIR_IO_LOW / Trace22" };
            Trace23 = new LoggingLevel { Label = "10023", LabelColor = Color.Olive, Color = Color.Olive, ToolTip = "DATABASE_IO_LOW / Trace23" };
            Trace24 = new LoggingLevel { Label = "10024", LabelColor = Color.Fuchsia, Color = Color.Fuchsia, ToolTip = "SECURITY_LOW / Trace24" };
            Trace25 = new LoggingLevel { Label = "10025", ToolTip = "CLEAR_INITIALIZE / Trace25" };
            Trace26 = new LoggingLevel { Label = "10026", LabelColor = Color.DarkCyan, Color = Color.DarkCyan, ToolTip = "EASESYS_IO_LOW / Trace26" };
            Trace27 = new LoggingLevel { Label = "10027", LabelColor = Color.LightPink, Color = Color.LightPink, ToolTip = "UI_CONTROL_LOW / Trace27" };
            Trace28 = new LoggingLevel { Label = "10028", LabelColor = Color.SlateGray, Color = Color.SlateGray, ToolTip = "UTILITY_LOW / Trace28" };
        }
    }
}
