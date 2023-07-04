using System.Drawing;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfig
    {
        public string Name { get; set; } = "Default";

        // TODO(crhodes)
        // Add Error, Warning

        public LoggingLevel Info00 { get; set; } = new LoggingLevel { Label = "Info00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info00" };
        public LoggingLevel Info01 { get; set; } = new LoggingLevel { Label = "Info01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info01" };
        public LoggingLevel Info02 { get; set; } = new LoggingLevel { Label = "Info02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info02" };
        public LoggingLevel Info03 { get; set; } = new LoggingLevel { Label = "Info03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info03" };
        public LoggingLevel Info04 { get; set; } = new LoggingLevel { Label = "Info04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info04" };

        public LoggingLevel Debug00 { get; set; } = new LoggingLevel { Label = "Debug00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug00" };
        public LoggingLevel Debug01 { get; set; } = new LoggingLevel { Label = "Debug01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug01" };
        public LoggingLevel Debug02 { get; set; } = new LoggingLevel { Label = "Debug02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug02" };
        public LoggingLevel Debug03 { get; set; } = new LoggingLevel { Label = "Debug03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug03" };
        public LoggingLevel Debug04 { get; set; } = new LoggingLevel { Label = "Debug04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug04" };

        public LoggingLevel Arch00 { get; set; } = new LoggingLevel { Label = "Arch00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch00" };
        public LoggingLevel Arch01 { get; set; } = new LoggingLevel { Label = "Arch01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch01" };
        public LoggingLevel Arch02 { get; set; } = new LoggingLevel { Label = "Arch02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch02" };
        public LoggingLevel Arch03 { get; set; } = new LoggingLevel { Label = "Arch03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch03" };
        public LoggingLevel Arch04 { get; set; } = new LoggingLevel { Label = "Arch04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch04" };
        public LoggingLevel Arch05 { get; set; } = new LoggingLevel { Label = "Arch05", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch05" };
        public LoggingLevel Arch06 { get; set; } = new LoggingLevel { Label = "Arch06", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch06" };
        public LoggingLevel Arch07 { get; set; } = new LoggingLevel { Label = "Arch07", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch07" };
        public LoggingLevel Arch08 { get; set; } = new LoggingLevel { Label = "Arch08", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch08" };
        public LoggingLevel Arch09 { get; set; } = new LoggingLevel { Label = "Arch09", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch09" };
        public LoggingLevel Arch10 { get; set; } = new LoggingLevel { Label = "Arch10", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch10" };
        public LoggingLevel Arch11 { get; set; } = new LoggingLevel { Label = "Arch11", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch11" };
        public LoggingLevel Arch12 { get; set; } = new LoggingLevel { Label = "Arch12", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch12" };
        public LoggingLevel Arch13 { get; set; } = new LoggingLevel { Label = "Arch13", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch13" };
        public LoggingLevel Arch14 { get; set; } = new LoggingLevel { Label = "Arch14", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch14" };
        public LoggingLevel Arch15 { get; set; } = new LoggingLevel { Label = "Arch15", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch15" };
        public LoggingLevel Arch16 { get; set; } = new LoggingLevel { Label = "Arch16", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch16" };
        public LoggingLevel Arch17 { get; set; } = new LoggingLevel { Label = "Arch17", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch17" };
        public LoggingLevel Arch18 { get; set; } = new LoggingLevel { Label = "Arch18", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch18" };
        public LoggingLevel Arch19 { get; set; } = new LoggingLevel { Label = "Arch19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch19" };

        public LoggingLevel Trace00 { get; set; } = new LoggingLevel { Label = "Trace00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace00" };
        public LoggingLevel Trace01 { get; set; } = new LoggingLevel { Label = "Trace01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace01" };
        public LoggingLevel Trace02 { get; set; } = new LoggingLevel { Label = "Trace02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace02" };
        public LoggingLevel Trace03 { get; set; } = new LoggingLevel { Label = "Trace03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace03" };
        public LoggingLevel Trace04 { get; set; } = new LoggingLevel { Label = "Trace04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace04" };
        public LoggingLevel Trace05 { get; set; } = new LoggingLevel { Label = "Trace05", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace05" };
        public LoggingLevel Trace06 { get; set; } = new LoggingLevel { Label = "Trace06", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace06" };
        public LoggingLevel Trace07 { get; set; } = new LoggingLevel { Label = "Trace07", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace07" };
        public LoggingLevel Trace08 { get; set; } = new LoggingLevel { Label = "Trace08", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace08" };
        public LoggingLevel Trace09 { get; set; } = new LoggingLevel { Label = "Trace09", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace09" };
        public LoggingLevel Trace10 { get; set; } = new LoggingLevel { Label = "Trace10", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace10" };
        public LoggingLevel Trace11 { get; set; } = new LoggingLevel { Label = "Trace11", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace11" };
        public LoggingLevel Trace12 { get; set; } = new LoggingLevel { Label = "Trace12", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace12" };
        public LoggingLevel Trace13 { get; set; } = new LoggingLevel { Label = "Trace13", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace13" };
        public LoggingLevel Trace14 { get; set; } = new LoggingLevel { Label = "Trace14", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace14" };
        public LoggingLevel Trace15 { get; set; } = new LoggingLevel { Label = "Trace15", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace15" };
        public LoggingLevel Trace16 { get; set; } = new LoggingLevel { Label = "Trace16", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace16" };
        public LoggingLevel Trace17 { get; set; } = new LoggingLevel { Label = "Trace17", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace17" };
        public LoggingLevel Trace18 { get; set; } = new LoggingLevel { Label = "Trace18", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace18" };
        public LoggingLevel Trace19 { get; set; } = new LoggingLevel { Label = "Trace19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace19" };
        public LoggingLevel Trace20 { get; set; } = new LoggingLevel { Label = "Trace20", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace20" };
        public LoggingLevel Trace21 { get; set; } = new LoggingLevel { Label = "Trace21", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace21" };
        public LoggingLevel Trace22 { get; set; } = new LoggingLevel { Label = "Trace22", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace22" };
        public LoggingLevel Trace23 { get; set; } = new LoggingLevel { Label = "Trace23", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace23" };
        public LoggingLevel Trace24 { get; set; } = new LoggingLevel { Label = "Trace24", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace24" };
        public LoggingLevel Trace25 { get; set; } = new LoggingLevel { Label = "Trace25", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace25" };
        public LoggingLevel Trace26 { get; set; } = new LoggingLevel { Label = "Trace26", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace26" };
        public LoggingLevel Trace27 { get; set; } = new LoggingLevel { Label = "Trace27", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace27" };
        public LoggingLevel Trace28 { get; set; } = new LoggingLevel { Label = "Trace28", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace28" };
        public LoggingLevel Trace29 { get; set; } = new LoggingLevel { Label = "Trace29", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace29" };

    }
}
