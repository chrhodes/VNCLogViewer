using System.Drawing;

namespace VNCLogViewer.LoggingUIConfig
{
    // NOTE(crhodes)
    // This controls the UI Checkbox Colors and the Log message colors.

    public class LoggingColors
    {
        // This should make it obvious if we need to pick a color.
        private static Color defaultColor = Color.FromArgb(30, 150, 255);

        public Color APPLICATION_START { get; set; } = Color.FromArgb(30, 150, 255);
        public  Color APPLICATION_END { get; set; } = Color.FromArgb(20, 90, 150);

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
