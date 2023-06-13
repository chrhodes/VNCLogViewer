using System.Drawing;
using System.Reflection.Emit;

namespace JSONConsoleApp
{

    public struct LoggingLevel
    {

/* Unmerged change from project 'VNCLogViewer (net6.0-windows)'
Before:
        public string Label { get => label; set => label = value; }
        public Color Color { get => color; set => color = value; }
        public string ToolTip { get => toolTip; set => toolTip = value; }
After:
        public string Label { get => Label; set => Label = value; }
        public Color Color { get => Color; set => Color = value; }
        public string ToolTip { get => ToolTip; set => ToolTip = value; }
*/
        public string Label { get; set; }
        public Color Color { get; set; }
        public string ToolTip { get; set; }
    }

    public class LoggingUIConfig
    {

        public LoggingLevel Info01 { get; set; } = new LoggingLevel { Label = "Info01", Color = Color.FromArgb(30, 150, 255), ToolTip = "" };


/* Unmerged change from project 'VNCLogViewer (net6.0-windows)'
Before:
        public LoggingLevel Info011 { get => Info01; set => Info01 = value; }
After:
        public LoggingLevel Info011 { get => Info011; set => Info011 = value; }
*/
        /* Unmerged change from project 'VNCLogViewer (net6.0-windows)'
        Before:
                public LoggingLevel Info021 { get => Info02; set => Info02 = value; }
        After:
                public LoggingLevel Info021 { get => Info021; set => Info021 = value; }
        */
        public LoggingLevel Info02 { get; set; }
    }

    // NOTE(crhodes)
    // This controls the UI Checkbox Colors and the Log message colors.

    public class LoggingConfiguration
    {
        // This should make it obvious if we need to pick a color.
        private static Color defaultColor = Color.FromArgb(30, 150, 255);
        private static Color APPLICATION_START = Color.FromArgb(30, 150, 255);
        private static Color APPLICATION_END = Color.FromArgb(20, 90, 150);

        public Color Info00 { get; set; } = defaultColor;
        public Color Info01 { get; set; } = defaultColor;
        public Color Info02 { get; set; } = defaultColor;
        public Color Info03 { get; set; } = defaultColor;
        public Color Info04 { get; set; } = defaultColor;
        public Color Info05 { get; set; } = defaultColor;

        public Color Debug00 { get; set; } = defaultColor;
        public Color Debug01 { get; set; } = defaultColor;
        public Color Debug02 { get; set; } = Color.Red;
        public Color Debug03 { get; set; } = defaultColor;
        public Color Debug04 { get; set; } = defaultColor;
        public Color Debug05 { get; set; } = defaultColor;

        public Color Trace00 { get; set; } = defaultColor;
        public Color Trace01 { get; set; } = Color.FromArgb(255, 0, 0);     // EVENT_HANDLER    // DIAGNOSTIC
        public Color Trace02 { get; set; } = Color.FromArgb(210, 210, 210); // APPLICATION_INITIALIZE
        public Color Trace03 { get; set; } = defaultColor;
        public Color Trace04 { get; set; } = defaultColor;
        public Color Trace05 { get; set; } = defaultColor;
        public Color Trace06 { get; set; } = defaultColor;
        public Color Trace07 { get; set; } = Color.FromArgb(0, 220, 220);   // PRESENTATION
        public Color Trace08 { get; set; } = defaultColor;
        public Color Trace09 { get; set; } = Color.FromArgb(170, 170, 170); // CORE
        public Color Trace10 { get; set; } = Color.FromArgb(100, 240, 100); // APPLICATION
        public Color Trace11 { get; set; } = defaultColor;
        public Color Trace12 { get; set; } = Color.FromArgb(255, 180, 0);   // DOMAIN   // PARSER
        public Color Trace13 { get; set; } = Color.FromArgb(160, 115, 225); // PERSISTENCE  // COMPILER
        public Color Trace14 { get; set; } = defaultColor;
        public Color Trace15 { get; set; } = defaultColor;
        public Color Trace16 { get; set; } = Color.FromArgb(255, 255, 255); // INFRASTRUCTURE   // SYNTAX
        public Color Trace17 { get; set; } = Color.FromArgb(0, 220, 220);   // VIEW // BINDER
        public Color Trace18 { get; set; } = Color.FromArgb(90, 255, 255);  // VIEWMODEL
        public Color Trace19 { get; set; } = Color.FromArgb(255, 0, 255);   // MODULE
        public Color Trace20 { get; set; } = Color.FromArgb(100, 240, 100); // APPLICATION_SERVICES // LEXER
        public Color Trace21 { get; set; } = Color.FromArgb(255, 225, 0);   // EVENT    // EVALUATOR
        public Color Trace22 { get; set; } = Color.FromArgb(255, 180, 0);   // DOMAIN SERVICES
        public Color Trace23 { get; set; } = Color.FromArgb(160, 115, 225); // PERSISTENCE_LOW
        public Color Trace24 { get; set; } = defaultColor;
        public Color Trace25 { get; set; } = Color.FromArgb(221, 160, 221); // CONSTRUCTOR
        public Color Trace26 { get; set; } = defaultColor;
        public Color Trace27 { get; set; } = Color.FromArgb(0, 200, 200);   // VIEW_LOW
        public Color Trace28 { get; set; } = Color.FromArgb(0, 255, 255);   // VIEWMODEL_LOW
        public Color Trace29 { get; set; } = Color.FromArgb(255, 219, 255); // MODULE_INITIALIZE;
        public Color Trace30 { get; set; } = defaultColor;
    }
}
