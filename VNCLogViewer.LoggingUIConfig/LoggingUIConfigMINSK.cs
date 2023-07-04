using System.Drawing;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigMINSK
    {
        public string Name { get; set; } = "MINSK";

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

        public LoggingLevel Arch00 { get; set; } = new LoggingLevel { Label = "CONSTRUCTOR", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "CONSTRUCTOR / Arch00" };
        public LoggingLevel Arch01 { get; set; } = new LoggingLevel { Label = "EVENT", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(255, 0, 0), IsChecked = true, ToolTip = "EVENT / Arch01" };
        public LoggingLevel Arch02 { get; set; } = new LoggingLevel { Label = "EVENT_HANDLER", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "EVENT_HANDLER / Arch02" };
        public LoggingLevel Arch03 { get; set; } = new LoggingLevel { Label = "APPLICATION_INITIALIZE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "APPLICATION_INITIALIZE / Arch03" };
        public LoggingLevel Arch04 { get; set; } = new LoggingLevel { Label = "CORE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "CORE / Arch04" };
        public LoggingLevel Arch05 { get; set; } = new LoggingLevel { Label = "MODULE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "MODULE / Arch05" };
        public LoggingLevel Arch06 { get; set; } = new LoggingLevel { Label = "MODULE_INITIALIZE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "MODULE_INITIALIZE / Arch06" };
        public LoggingLevel Arch07 { get; set; } = new LoggingLevel { Label = "APPLICATION", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "APPLICATION / Arch07" };
        public LoggingLevel Arch08 { get; set; } = new LoggingLevel { Label = "APPLICATIONSERVICES", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "APPLICATIONSERVICES / Arch08" };
        public LoggingLevel Arch09 { get; set; } = new LoggingLevel { Label = "DOMAIN", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "DOMAIN / Arch09" };
        public LoggingLevel Arch10 { get; set; } = new LoggingLevel { Label = "DOMAINSERVICES", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(0, 255, 255), IsChecked = true, ToolTip = "DOMAINSERVICES / Arch10" };
        public LoggingLevel Arch11 { get; set; } = new LoggingLevel { Label = "PERSISTENCE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(100, 240, 100), IsChecked = true, ToolTip = "PERSISTENCE / Arch11" };
        public LoggingLevel Arch12 { get; set; } = new LoggingLevel { Label = "PERSISTENCE_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(255, 180, 0), IsChecked = true, ToolTip = "PERSISTENCE_LOW / Arch12" };
        public LoggingLevel Arch13 { get; set; } = new LoggingLevel { Label = "INFRASTRUCTURE", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(186, 85, 211), IsChecked = true, ToolTip = "INFRASTRUCTURE / Arch13" };
        public LoggingLevel Arch14 { get; set; } = new LoggingLevel { Label = "PRESENTATION", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "PRESENTATION / Arch14" };
        public LoggingLevel Arch15 { get; set; } = new LoggingLevel { Label = "VIEW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "VIEW / Arch15" };
        public LoggingLevel Arch16 { get; set; } = new LoggingLevel { Label = "VIEW_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "VIEW_LOW / Arch16" };
        public LoggingLevel Arch17 { get; set; } = new LoggingLevel { Label = "VIEWMODEL", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "VIEWMODEL / Arch17" };
        public LoggingLevel Arch18 { get; set; } = new LoggingLevel { Label = "VIEWMODEL_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "VIEWMODEL_LOW / Arch18" };
        public LoggingLevel Arch19 { get; set; } = new LoggingLevel { Label = "Arch19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Arch19" };

        public LoggingLevel Trace00 { get; set; } = new LoggingLevel { Label = "COMPILER", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "COMPILER / Trace00" };
        public LoggingLevel Trace01 { get; set; } = new LoggingLevel { Label = "Trace01", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace01" };
        public LoggingLevel Trace02 { get; set; } = new LoggingLevel { Label = "TEST", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEST / Trace02" };
        public LoggingLevel Trace03 { get; set; } = new LoggingLevel { Label = "Trace03", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace03" };
        public LoggingLevel Trace04 { get; set; } = new LoggingLevel { Label = "Trace04", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace04" };
        public LoggingLevel Trace05 { get; set; } = new LoggingLevel { Label = "Trace05", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace05" };
        public LoggingLevel Trace06 { get; set; } = new LoggingLevel { Label = "Trace06", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace06" };
        public LoggingLevel Trace07 { get; set; } = new LoggingLevel { Label = "Trace07", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace07" };
        public LoggingLevel Trace08 { get; set; } = new LoggingLevel { Label = "Trace08", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace08" };
        public LoggingLevel Trace09 { get; set; } = new LoggingLevel { Label = "Trace09", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace09" };
        public LoggingLevel Trace10 { get; set; } = new LoggingLevel { Label = "SYNTAX", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "SYNTAX / Trace10" };
        public LoggingLevel Trace11 { get; set; } = new LoggingLevel { Label = "LEXER", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "LEXER / Trace11" };
        public LoggingLevel Trace12 { get; set; } = new LoggingLevel { Label = "PARSER", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "PARSER / Trace12" };
        public LoggingLevel Trace13 { get; set; } = new LoggingLevel { Label = "BINDER", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "BINDER / Trace13" };
        public LoggingLevel Trace14 { get; set; } = new LoggingLevel { Label = "EVALUATOR", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "EVALUATOR / Trace14" };
        public LoggingLevel Trace15 { get; set; } = new LoggingLevel { Label = "TEXT", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEXT / Trace15" };
        public LoggingLevel Trace16 { get; set; } = new LoggingLevel { Label = "Trace16", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace16" };
        public LoggingLevel Trace17 { get; set; } = new LoggingLevel { Label = "Trace17", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace17" };
        public LoggingLevel Trace18 { get; set; } = new LoggingLevel { Label = "Trace18", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace18" };
        public LoggingLevel Trace19 { get; set; } = new LoggingLevel { Label = "Trace19", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace19" };
        public LoggingLevel Trace20 { get; set; } = new LoggingLevel { Label = "SYNTAX_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "SYNTAX_LOW / Trace20" };
        public LoggingLevel Trace21 { get; set; } = new LoggingLevel { Label = "LEXER_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "LEXER_LOW / Trace21" };
        public LoggingLevel Trace22 { get; set; } = new LoggingLevel { Label = "PARSER_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "PARSER_LOW / Trace22" };
        public LoggingLevel Trace23 { get; set; } = new LoggingLevel { Label = "BINDER_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "BINDER_LOW / Trace23" };
        public LoggingLevel Trace24 { get; set; } = new LoggingLevel { Label = "Trace24", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace24" };
        public LoggingLevel Trace25 { get; set; } = new LoggingLevel { Label = "TEXT_LOW", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEXT_LOW / Trace25" };
        public LoggingLevel Trace26 { get; set; } = new LoggingLevel { Label = "Trace26", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace26" };
        public LoggingLevel Trace27 { get; set; } = new LoggingLevel { Label = "Trace27", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace27" };
        public LoggingLevel Trace28 { get; set; } = new LoggingLevel { Label = "Trace28", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace28" };
        public LoggingLevel Trace29 { get; set; } = new LoggingLevel { Label = "Trace29", Visibility = System.Windows.Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace29" };
    }
}
