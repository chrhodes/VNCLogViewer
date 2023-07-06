using System.Buffers.Text;
using System.Drawing;
using System.Runtime.CompilerServices;

using luic = VNCLogViewer.LoggingUIConfig;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigDEFAULT : LoggingUIConfig
    {
        public LoggingUIConfigDEFAULT()
        {
            Name = "Default Capture Filter";
        }

        //public luic.LoggingLevel Info00 { get; set; } = new luic.LoggingLevel { Label = "Info00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info00" };
        //public luic.LoggingLevel Info01 { get; set; } = new luic.LoggingLevel { Label = "Info01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info01" };
        //public luic.LoggingLevel Info02 { get; set; } = new luic.LoggingLevel { Label = "Info02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info02" };
        //public luic.LoggingLevel Info03 { get; set; } = new luic.LoggingLevel { Label = "Info03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info03" };
        //public luic.LoggingLevel Info04 { get; set; } = new luic.LoggingLevel { Label = "Info04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Info04" };

        //public luic.LoggingLevel Debug00 { get; set; } = new luic.LoggingLevel { Label = "Debug00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug00" };
        //public luic.LoggingLevel Debug01 { get; set; } = new luic.LoggingLevel { Label = "Debug01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug01" };
        //public luic.LoggingLevel Debug02 { get; set; } = new luic.LoggingLevel { Label = "Debug02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug02" };
        //public luic.LoggingLevel Debug03 { get; set; } = new luic.LoggingLevel { Label = "Debug03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug03" };
        //public luic.LoggingLevel Debug04 { get; set; } = new luic.LoggingLevel { Label = "Debug04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Debug04" };

        //public luic.LoggingLevel Arch00 { get; set; } = new luic.LoggingLevel { Label = "Arch00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch00" };
        //public luic.LoggingLevel Arch01 { get; set; } = new luic.LoggingLevel { Label = "Arch01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch01" };
        //public luic.LoggingLevel Arch02 { get; set; } = new luic.LoggingLevel { Label = "Arch02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch02" };
        //public luic.LoggingLevel Arch03 { get; set; } = new luic.LoggingLevel { Label = "Arch03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch03" };
        //public luic.LoggingLevel Arch04 { get; set; } = new luic.LoggingLevel { Label = "Arch04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch04" };
        //public luic.LoggingLevel Arch05 { get; set; } = new luic.LoggingLevel { Label = "Arch05", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch05" };
        //public luic.LoggingLevel Arch06 { get; set; } = new luic.LoggingLevel { Label = "Arch06", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch06" };
        //public luic.LoggingLevel Arch07 { get; set; } = new luic.LoggingLevel { Label = "Arch07", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch07" };
        //public luic.LoggingLevel Arch08 { get; set; } = new luic.LoggingLevel { Label = "Arch08", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch08" };
        //public luic.LoggingLevel Arch09 { get; set; } = new luic.LoggingLevel { Label = "Arch09", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch09" };
        //public luic.LoggingLevel Arch10 { get; set; } = new luic.LoggingLevel { Label = "Arch10", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch10" };
        //public luic.LoggingLevel Arch11 { get; set; } = new luic.LoggingLevel { Label = "Arch11", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch11" };
        //public luic.LoggingLevel Arch12 { get; set; } = new luic.LoggingLevel { Label = "Arch12", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch12" };
        //public luic.LoggingLevel Arch13 { get; set; } = new luic.LoggingLevel { Label = "Arch13", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch13" };
        //public luic.LoggingLevel Arch14 { get; set; } = new luic.LoggingLevel { Label = "Arch14", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch14" };
        //public luic.LoggingLevel Arch15 { get; set; } = new luic.LoggingLevel { Label = "Arch15", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch15" };
        //public luic.LoggingLevel Arch16 { get; set; } = new luic.LoggingLevel { Label = "Arch16", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch16" };
        //public luic.LoggingLevel Arch17 { get; set; } = new luic.LoggingLevel { Label = "Arch17", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch17" };
        //public luic.LoggingLevel Arch18 { get; set; } = new luic.LoggingLevel { Label = "Arch18", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch18" };
        //public luic.LoggingLevel Arch19 { get; set; } = new luic.LoggingLevel { Label = "Arch19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch19" };

        //public luic.LoggingLevel Trace00 { get; set; } = new luic.LoggingLevel { Label = "Trace00", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace00" };
        //public luic.LoggingLevel Trace01 { get; set; } = new luic.LoggingLevel { Label = "Trace01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace01" };
        //public luic.LoggingLevel Trace02 { get; set; } = new luic.LoggingLevel { Label = "Trace02", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace02" };
        //public luic.LoggingLevel Trace03 { get; set; } = new luic.LoggingLevel { Label = "Trace03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace03" };
        //public luic.LoggingLevel Trace04 { get; set; } = new luic.LoggingLevel { Label = "Trace04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace04" };
        //public luic.LoggingLevel Trace05 { get; set; } = new luic.LoggingLevel { Label = "Trace05", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace05" };
        //public luic.LoggingLevel Trace06 { get; set; } = new luic.LoggingLevel { Label = "Trace06", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace06" };
        //public luic.LoggingLevel Trace07 { get; set; } = new luic.LoggingLevel { Label = "Trace07", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace07" };
        //public luic.LoggingLevel Trace08 { get; set; } = new luic.LoggingLevel { Label = "Trace08", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace08" };
        //public luic.LoggingLevel Trace09 { get; set; } = new luic.LoggingLevel { Label = "Trace09", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace09" };
        //public luic.LoggingLevel Trace10 { get; set; } = new luic.LoggingLevel { Label = "Trace10", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace10" };
        //public luic.LoggingLevel Trace11 { get; set; } = new luic.LoggingLevel { Label = "Trace11", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace11" };
        //public luic.LoggingLevel Trace12 { get; set; } = new luic.LoggingLevel { Label = "Trace12", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace12" };
        //public luic.LoggingLevel Trace13 { get; set; } = new luic.LoggingLevel { Label = "Trace13", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace13" };
        //public luic.LoggingLevel Trace14 { get; set; } = new luic.LoggingLevel { Label = "Trace14", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace14" };
        //public luic.LoggingLevel Trace15 { get; set; } = new luic.LoggingLevel { Label = "Trace15", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace15" };
        //public luic.LoggingLevel Trace16 { get; set; } = new luic.LoggingLevel { Label = "Trace16", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace16" };
        //public luic.LoggingLevel Trace17 { get; set; } = new luic.LoggingLevel { Label = "Trace17", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace17" };
        //public luic.LoggingLevel Trace18 { get; set; } = new luic.LoggingLevel { Label = "Trace18", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace18" };
        //public luic.LoggingLevel Trace19 { get; set; } = new luic.LoggingLevel { Label = "Trace19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace19" };
        //public luic.LoggingLevel Trace20 { get; set; } = new luic.LoggingLevel { Label = "Trace20", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace20" };
        //public luic.LoggingLevel Trace21 { get; set; } = new luic.LoggingLevel { Label = "Trace21", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace21" };
        //public luic.LoggingLevel Trace22 { get; set; } = new luic.LoggingLevel { Label = "Trace22", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace22" };
        //public luic.LoggingLevel Trace23 { get; set; } = new luic.LoggingLevel { Label = "Trace23", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace23" };
        //public luic.LoggingLevel Trace24 { get; set; } = new luic.LoggingLevel { Label = "Trace24", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace24" };
        //public luic.LoggingLevel Trace25 { get; set; } = new luic.LoggingLevel { Label = "Trace25", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace25" };
        //public luic.LoggingLevel Trace26 { get; set; } = new luic.LoggingLevel { Label = "Trace26", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace26" };
        //public luic.LoggingLevel Trace27 { get; set; } = new luic.LoggingLevel { Label = "Trace27", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace27" };
        //public luic.LoggingLevel Trace28 { get; set; } = new luic.LoggingLevel { Label = "Trace28", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace28" };
        //public luic.LoggingLevel Trace29 { get; set; } = new luic.LoggingLevel { Label = "Trace29", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace29" };
    }
}
