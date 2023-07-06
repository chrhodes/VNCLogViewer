using System.Drawing;
using System.Windows;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigMINSK : LoggingUIConfig
    {
        public LoggingUIConfigMINSK()
        {
            Name = "MINSK Capture Filter";

            Trace00 = new LoggingLevel { Label = "COMPILER", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "COMPILER / Trace00" };
            //Trace01 = new LoggingLevel { Label = "Trace01", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace01" };
            Trace02 = new LoggingLevel { Label = "TEST", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEST / Trace02" };
            //Trace03 = new LoggingLevel { Label = "Trace03", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace03" };
            //Trace04 = new LoggingLevel { Label = "Trace04", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace04" };
            //Trace05 = new LoggingLevel { Label = "Trace05", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace05" };
            //Trace06 = new LoggingLevel { Label = "Trace06", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace06" };
            //Trace07 = new LoggingLevel { Label = "Trace07", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace07" };
            //Trace08 = new LoggingLevel { Label = "Trace08", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace08" };
            //Trace09 = new LoggingLevel { Label = "Trace09", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace09" };
            Trace10 = new LoggingLevel { Label = "SYNTAX", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "SYNTAX / Trace10" };
            Trace11 = new LoggingLevel { Label = "LEXER", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "LEXER / Trace11" };
            Trace12 = new LoggingLevel { Label = "PARSER", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "PARSER / Trace12" };
            Trace13 = new LoggingLevel { Label = "BINDER", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "BINDER / Trace13" };
            Trace14 = new LoggingLevel { Label = "EVALUATOR", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "EVALUATOR / Trace14" };
            Trace15 = new LoggingLevel { Label = "TEXT", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEXT / Trace15" };
            //Trace16 = new LoggingLevel { Label = "Trace16", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace16" };
            //Trace17 = new LoggingLevel { Label = "Trace17", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace17" };
            //Trace18 = new LoggingLevel { Label = "Trace18", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace18" };
            //Trace19 = new LoggingLevel { Label = "Trace19", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace19" };
            Trace20 = new LoggingLevel { Label = "SYNTAX_LOW", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "SYNTAX_LOW / Trace20" };
            Trace21 = new LoggingLevel { Label = "LEXER_LOW", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "LEXER_LOW / Trace21" };
            Trace22 = new LoggingLevel { Label = "PARSER_LOW", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "PARSER_LOW / Trace22" };
            Trace23 = new LoggingLevel { Label = "BINDER_LOW", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "BINDER_LOW / Trace23" };
            //Trace24 = new LoggingLevel { Label = "Trace24", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace24" };
            Trace25 = new LoggingLevel { Label = "TEXT_LOW", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "TEXT_LOW / Trace25" };
            //Trace26 = new LoggingLevel { Label = "Trace26", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace26" };
            //Trace27 = new LoggingLevel { Label = "Trace27", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace27" };
            //Trace28 = new LoggingLevel { Label = "Trace28", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace28" };
            //Trace29 = new LoggingLevel { Label = "Trace29", Visibility = Visibility.Visible, Color = Color.FromArgb(200, 200, 200), IsChecked = true, ToolTip = "Trace29" };
    }
    }
}
