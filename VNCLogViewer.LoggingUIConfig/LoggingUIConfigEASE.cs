using System.Drawing;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigEASE
    {
        public string Name { get; set; } = "EASE";

        // TODO(crhodes)
        // Add Error, Warning

        public LoggingLevel Info00 { get; set; } = new LoggingLevel { Label = "100", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "APPLICATION_START / APPLICATION_END / LOADEASE / Info00" };
        public LoggingLevel Info01 { get; set; } = new LoggingLevel { Label = "101", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info01" };
        public LoggingLevel Info02 { get; set; } = new LoggingLevel { Label = "102", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info02" };
        public LoggingLevel Info03 { get; set; } = new LoggingLevel { Label = "103", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info03" };
        public LoggingLevel Info04 { get; set; } = new LoggingLevel { Label = "104", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info04" };
 
        public LoggingLevel Debug00 { get; set; } = new LoggingLevel { Label = "Debug00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug00" };
        public LoggingLevel Debug01 { get; set; } = new LoggingLevel { Label = "Debug01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug01" };
        public LoggingLevel Debug02 { get; set; } = new LoggingLevel { Label = "Debug02", Visibility = System.Windows.Visibility.Visible, Color = Color.Red, IsChecked = true, ToolTip = "SQL_CALL / Debug02" };
        public LoggingLevel Debug03 { get; set; } = new LoggingLevel { Label = "Debug03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug03" };
        public LoggingLevel Debug04 { get; set; } = new LoggingLevel { Label = "Debug04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug04" };

        public LoggingLevel Arch00 { get; set; } = new LoggingLevel { Label = "Arch00", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch00" };
        public LoggingLevel Arch01 { get; set; } = new LoggingLevel { Label = "Arch01", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch01" };
        public LoggingLevel Arch02 { get; set; } = new LoggingLevel { Label = "Arch02", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch02" };
        public LoggingLevel Arch03 { get; set; } = new LoggingLevel { Label = "Arch03", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch03" };
        public LoggingLevel Arch04 { get; set; } = new LoggingLevel { Label = "Arch04", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch04" };
        public LoggingLevel Arch05 { get; set; } = new LoggingLevel { Label = "Arch05", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch05" };
        public LoggingLevel Arch06 { get; set; } = new LoggingLevel { Label = "Arch06", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch06" };
        public LoggingLevel Arch07 { get; set; } = new LoggingLevel { Label = "Arch07", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch07" };
        public LoggingLevel Arch08 { get; set; } = new LoggingLevel { Label = "Arch08", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch08" };
        public LoggingLevel Arch09 { get; set; } = new LoggingLevel { Label = "Arch09", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch09" };
        public LoggingLevel Arch10 { get; set; } = new LoggingLevel { Label = "Arch10", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch10" };
        public LoggingLevel Arch11 { get; set; } = new LoggingLevel { Label = "Arch11", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch11" };
        public LoggingLevel Arch12 { get; set; } = new LoggingLevel { Label = "Arch12", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch12" };
        public LoggingLevel Arch13 { get; set; } = new LoggingLevel { Label = "Arch13", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch13" };
        public LoggingLevel Arch14 { get; set; } = new LoggingLevel { Label = "Arch14", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch14" };
        public LoggingLevel Arch15 { get; set; } = new LoggingLevel { Label = "Arch15", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch15" };
        public LoggingLevel Arch16 { get; set; } = new LoggingLevel { Label = "Arch16", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch16" };
        public LoggingLevel Arch17 { get; set; } = new LoggingLevel { Label = "Arch17", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch17" };
        public LoggingLevel Arch18 { get; set; } = new LoggingLevel { Label = "Arch18", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch18" };
        public LoggingLevel Arch19 { get; set; } = new LoggingLevel { Label = "Arch19", Visibility = System.Windows.Visibility.Hidden, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch19" };

        public LoggingLevel Trace00 { get; set; } = new LoggingLevel { Label = "10000", Visibility = System.Windows.Visibility.Visible, Color = Color.Lime, IsChecked = true, ToolTip = "PAGE_LOAD / FORM_LOAD / Trace00" };
        public LoggingLevel Trace01 { get; set; } = new LoggingLevel { Label = "10001", Visibility = System.Windows.Visibility.Visible, Color = Color.Cyan, IsChecked = true, ToolTip = "EVENTHANDLER / Trace01" };
        public LoggingLevel Trace02 { get; set; } = new LoggingLevel { Label = "10002", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "STATUS / Trace02" };
        public LoggingLevel Trace03 { get; set; } = new LoggingLevel { Label = "10003", Visibility = System.Windows.Visibility.Visible, Color = Color.GreenYellow, IsChecked = true, ToolTip = "REDIRECT_TRANSFER / Trace03" };
        public LoggingLevel Trace04 { get; set; } = new LoggingLevel { Label = "10004", Visibility = System.Windows.Visibility.Visible, Color = Color.BurlyWood, IsChecked = true, ToolTip = "POLLING / Trace04" };
        public LoggingLevel Trace05 { get; set; } = new LoggingLevel { Label = "10005", Visibility = System.Windows.Visibility.Visible, Color = Color.Yellow, IsChecked = true, ToolTip = "ERROR_TRACE / Trace05" };
        public LoggingLevel Trace06 { get; set; } = new LoggingLevel { Label = "10006", Visibility = System.Windows.Visibility.Visible, Color = Color.DarkCyan, IsChecked = true, ToolTip = "EASESYS_IO / Trace06" };
        public LoggingLevel Trace07 { get; set; } = new LoggingLevel { Label = "10007", Visibility = System.Windows.Visibility.Visible, Color = Color.LightPink, IsChecked = true, ToolTip = "UI_CONTROL / Trace07" };
        public LoggingLevel Trace08 { get; set; } = new LoggingLevel { Label = "10008", Visibility = System.Windows.Visibility.Visible, Color = Color.SlateGray, IsChecked = true, ToolTip = "UTILITY / Trace08" };
        public LoggingLevel Trace09 { get; set; } = new LoggingLevel { Label = "10009", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "OPERATION / Trace09" };
        public LoggingLevel Trace10 { get; set; } = new LoggingLevel { Label = "10010", Visibility = System.Windows.Visibility.Visible, Color = Color.Plum, IsChecked = true, ToolTip = "APPLICATION_SESSION / Trace10" };
        public LoggingLevel Trace11 { get; set; } = new LoggingLevel { Label = "10011", Visibility = System.Windows.Visibility.Visible, Color = Color.Orange, IsChecked = true, ToolTip = "SYSTEM_CONFIG / Trace11" };
        public LoggingLevel Trace12 { get; set; } = new LoggingLevel { Label = "10012", Visibility = System.Windows.Visibility.Visible, Color = Color.Chocolate, IsChecked = true, ToolTip = "FILE_DIR_IO / Trace12" };
        public LoggingLevel Trace13 { get; set; } = new LoggingLevel { Label = "10013", Visibility = System.Windows.Visibility.Visible, Color = Color.Olive, IsChecked = true, ToolTip = "DATABASE_IO / Trace13" };
        public LoggingLevel Trace14 { get; set; } = new LoggingLevel { Label = "10014", Visibility = System.Windows.Visibility.Visible, Color = Color.Fuchsia, IsChecked = true, ToolTip = "SECURITY / Trace14" };
        public LoggingLevel Trace15 { get; set; } = new LoggingLevel { Label = "10015", Visibility = System.Windows.Visibility.Visible, Color = Color.Yellow, IsChecked = true, ToolTip = "ERROR_TRACE_LOW / Trace15" };
        public LoggingLevel Trace16 { get; set; } = new LoggingLevel { Label = "10016", Visibility = System.Windows.Visibility.Visible, Color = Color.DarkCyan, IsChecked = true, ToolTip = "EASESYS_IO_MED / Trace16" };
        public LoggingLevel Trace17 { get; set; } = new LoggingLevel { Label = "10017", Visibility = System.Windows.Visibility.Visible, Color = Color.LightPink, IsChecked = true, ToolTip = "UI_CONTROL_MED / Trace17" };
        public LoggingLevel Trace18 { get; set; } = new LoggingLevel { Label = "10018", Visibility = System.Windows.Visibility.Visible, Color = Color.SlateGray, IsChecked = true, ToolTip = "UTILITY_MED / Trace18" };
        public LoggingLevel Trace19 { get; set; } = new LoggingLevel { Label = "10019", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "OPERATION_LOW / DEFAULT / Trace19" };
        public LoggingLevel Trace20 { get; set; } = new LoggingLevel { Label = "10020", Visibility = System.Windows.Visibility.Visible, Color = Color.Plum, IsChecked = true, ToolTip = "APPLICATION_SESSION_LOW / Trace20" };
        public LoggingLevel Trace21 { get; set; } = new LoggingLevel { Label = "10021", Visibility = System.Windows.Visibility.Visible, Color = Color.Orange, IsChecked = true, ToolTip = "SYSTEMCONFIG_LOW / Trace21" };
        public LoggingLevel Trace22 { get; set; } = new LoggingLevel { Label = "10022", Visibility = System.Windows.Visibility.Visible, Color = Color.Chocolate, IsChecked = true, ToolTip = "FILE_DIR_IO_LOW / Trace22" };
        public LoggingLevel Trace23 { get; set; } = new LoggingLevel { Label = "10023", Visibility = System.Windows.Visibility.Visible, Color = Color.Olive, IsChecked = true, ToolTip = "DATABASE_IO_LOW / Trace23" };
        public LoggingLevel Trace24 { get; set; } = new LoggingLevel { Label = "10024", Visibility = System.Windows.Visibility.Visible, Color = Color.Fuchsia, IsChecked = true, ToolTip = "SECURITY_LOW / Trace24" };
        public LoggingLevel Trace25 { get; set; } = new LoggingLevel { Label = "10025", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "CLEAR_INITIALIZE / Trace25" };
        public LoggingLevel Trace26 { get; set; } = new LoggingLevel { Label = "10026", Visibility = System.Windows.Visibility.Visible, Color = Color.DarkCyan, IsChecked = true, ToolTip = "EASESYS_IO_LOW / Trace26" };
        public LoggingLevel Trace27 { get; set; } = new LoggingLevel { Label = "10027", Visibility = System.Windows.Visibility.Visible, Color = Color.LightPink, IsChecked = true, ToolTip = "UI_CONTROL_LOW / Trace27" };
        public LoggingLevel Trace28 { get; set; } = new LoggingLevel { Label = "10028", Visibility = System.Windows.Visibility.Visible, Color = Color.SlateGray, IsChecked = true, ToolTip = "UTILITY_LOW / Trace28" };
        public LoggingLevel Trace29 { get; set; } = new LoggingLevel { Label = "10029", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace29" };
    }
}
