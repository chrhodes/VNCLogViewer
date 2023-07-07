using System;

using VNCLogViewer.LoggingUIConfig;

namespace JSONConsoleApp.jsonDeserializeClass
{

    public class LoggingUIConfig_JsonRoot
    {
        public class ColorX
        {
            public int A { get; set; }
            public int B { get; set; }
            public int G { get; set; }
            public bool IsEmpty { get; set; }
            public bool IsKnownColor { get; set; }
            public bool IsNamedColor { get; set; }
            public bool IsSystemColor { get; set; }
            public string Name { get; set; }
            public int R { get; set; }
        }

        public class LoggingLevelX
        {
            public string Label { get; set; }
            public ColorX LabelColor { get; set; }
            public ColorX Color { get; set; }
            public bool IsChecked { get; set; }
            public string ToolTip { get; set; }
            public int Visibility { get; set; }
        }

        #region UIConfig Properties

        public string Name { get; set; }
        public LoggingLevelX Info00 { get; set; }
        public LoggingLevelX Info01 { get; set; }
        public LoggingLevelX Info02 { get; set; }
        public LoggingLevelX Info03 { get; set; }
        public LoggingLevelX Info04 { get; set; }
        public LoggingLevelX Debug00 { get; set; }
        public LoggingLevelX Debug01 { get; set; }
        public LoggingLevelX Debug02 { get; set; }
        public LoggingLevelX Debug03 { get; set; }
        public LoggingLevelX Debug04 { get; set; }
        public LoggingLevelX Arch00 { get; set; }
        public LoggingLevelX Arch01 { get; set; }
        public LoggingLevelX Arch02 { get; set; }
        public LoggingLevelX Arch03 { get; set; }
        public LoggingLevelX Arch04 { get; set; }
        public LoggingLevelX Arch05 { get; set; }
        public LoggingLevelX Arch06 { get; set; }
        public LoggingLevelX Arch07 { get; set; }
        public LoggingLevelX Arch08 { get; set; }
        public LoggingLevelX Arch09 { get; set; }
        public LoggingLevelX Arch10 { get; set; }
        public LoggingLevelX Arch11 { get; set; }
        public LoggingLevelX Arch12 { get; set; }
        public LoggingLevelX Arch13 { get; set; }
        public LoggingLevelX Arch14 { get; set; }
        public LoggingLevelX Arch15 { get; set; }
        public LoggingLevelX Arch16 { get; set; }
        public LoggingLevelX Arch17 { get; set; }
        public LoggingLevelX Arch18 { get; set; }
        public LoggingLevelX Arch19 { get; set; }
        public LoggingLevelX Trace00 { get; set; }
        public LoggingLevelX Trace01 { get; set; }
        public LoggingLevelX Trace02 { get; set; }
        public LoggingLevelX Trace03 { get; set; }
        public LoggingLevelX Trace04 { get; set; }
        public LoggingLevelX Trace05 { get; set; }
        public LoggingLevelX Trace06 { get; set; }
        public LoggingLevelX Trace07 { get; set; }
        public LoggingLevelX Trace08 { get; set; }
        public LoggingLevelX Trace09 { get; set; }
        public LoggingLevelX Trace10 { get; set; }
        public LoggingLevelX Trace11 { get; set; }
        public LoggingLevelX Trace12 { get; set; }
        public LoggingLevelX Trace13 { get; set; }
        public LoggingLevelX Trace14 { get; set; }
        public LoggingLevelX Trace15 { get; set; }
        public LoggingLevelX Trace16 { get; set; }
        public LoggingLevelX Trace17 { get; set; }
        public LoggingLevelX Trace18 { get; set; }
        public LoggingLevelX Trace19 { get; set; }
        public LoggingLevelX Trace20 { get; set; }
        public LoggingLevelX Trace21 { get; set; }
        public LoggingLevelX Trace22 { get; set; }
        public LoggingLevelX Trace23 { get; set; }
        public LoggingLevelX Trace24 { get; set; }
        public LoggingLevelX Trace25 { get; set; }
        public LoggingLevelX Trace26 { get; set; }
        public LoggingLevelX Trace27 { get; set; }
        public LoggingLevelX Trace28 { get; set; }
        public LoggingLevelX Trace29 { get; set; }

        #endregion

        public LoggingUIConfig ConvertJSONToLoggingUIConfig()
        {
            LoggingUIConfig loggingUIConfig = new LoggingUIConfig();

            loggingUIConfig.Name = Name;

            // HACK(crhodes)
            // Can brute force this by checking each property or can be clever and
            // Reflect on the class and only update the ones that are not null
            //
            // Here are the, ugh, hard coded ones

            if (Info00 is not null) loggingUIConfig.Info00 = ConvertJSONToLoggingLevel(Info00);
            if (Info01 is not null) loggingUIConfig.Info01 = ConvertJSONToLoggingLevel(Info01);
            if (Info02 is not null) loggingUIConfig.Info02 = ConvertJSONToLoggingLevel(Info02);
            if (Info03 is not null) loggingUIConfig.Info03 = ConvertJSONToLoggingLevel(Info03);
            if (Info04 is not null) loggingUIConfig.Info04 = ConvertJSONToLoggingLevel(Info04);

            if (Debug00 is not null) loggingUIConfig.Debug00 = ConvertJSONToLoggingLevel(Debug00);
            if (Debug01 is not null) loggingUIConfig.Debug01 = ConvertJSONToLoggingLevel(Debug01);
            if (Debug02 is not null) loggingUIConfig.Debug02 = ConvertJSONToLoggingLevel(Debug02);
            if (Debug03 is not null) loggingUIConfig.Debug03 = ConvertJSONToLoggingLevel(Debug03);
            if (Debug04 is not null) loggingUIConfig.Debug04 = ConvertJSONToLoggingLevel(Debug04);

            if (Arch00 is not null) loggingUIConfig.Arch00 = ConvertJSONToLoggingLevel(Arch00);
            if (Arch01 is not null) loggingUIConfig.Arch01 = ConvertJSONToLoggingLevel(Arch01);
            if (Arch02 is not null) loggingUIConfig.Arch02 = ConvertJSONToLoggingLevel(Arch02);
            if (Arch03 is not null) loggingUIConfig.Arch03 = ConvertJSONToLoggingLevel(Arch03);
            if (Arch04 is not null) loggingUIConfig.Arch04 = ConvertJSONToLoggingLevel(Arch04);
            if (Arch05 is not null) loggingUIConfig.Arch05 = ConvertJSONToLoggingLevel(Arch05);
            if (Arch06 is not null) loggingUIConfig.Arch06 = ConvertJSONToLoggingLevel(Arch06);
            if (Arch07 is not null) loggingUIConfig.Arch07 = ConvertJSONToLoggingLevel(Arch07);
            if (Arch08 is not null) loggingUIConfig.Arch08 = ConvertJSONToLoggingLevel(Arch08);
            if (Arch09 is not null) loggingUIConfig.Arch09 = ConvertJSONToLoggingLevel(Arch09);
            if (Arch10 is not null) loggingUIConfig.Arch10 = ConvertJSONToLoggingLevel(Arch10);
            if (Arch11 is not null) loggingUIConfig.Arch11 = ConvertJSONToLoggingLevel(Arch11);
            if (Arch12 is not null) loggingUIConfig.Arch12 = ConvertJSONToLoggingLevel(Arch12);
            if (Arch13 is not null) loggingUIConfig.Arch13 = ConvertJSONToLoggingLevel(Arch13);
            if (Arch14 is not null) loggingUIConfig.Arch14 = ConvertJSONToLoggingLevel(Arch14);
            if (Arch15 is not null) loggingUIConfig.Arch15 = ConvertJSONToLoggingLevel(Arch15);
            if (Arch16 is not null) loggingUIConfig.Arch16 = ConvertJSONToLoggingLevel(Arch16);
            if (Arch17 is not null) loggingUIConfig.Arch17 = ConvertJSONToLoggingLevel(Arch17);
            if (Arch18 is not null) loggingUIConfig.Arch18 = ConvertJSONToLoggingLevel(Arch18);
            if (Arch19 is not null) loggingUIConfig.Arch19 = ConvertJSONToLoggingLevel(Arch19);

            if (Trace00 is not null) loggingUIConfig.Trace00 = ConvertJSONToLoggingLevel(Trace00);
            if (Trace01 is not null) loggingUIConfig.Trace01 = ConvertJSONToLoggingLevel(Trace01);
            if (Trace02 is not null) loggingUIConfig.Trace02 = ConvertJSONToLoggingLevel(Trace02);
            if (Trace03 is not null) loggingUIConfig.Trace03 = ConvertJSONToLoggingLevel(Trace03);
            if (Trace04 is not null) loggingUIConfig.Trace04 = ConvertJSONToLoggingLevel(Trace04);
            if (Trace05 is not null) loggingUIConfig.Trace05 = ConvertJSONToLoggingLevel(Trace05);
            if (Trace06 is not null) loggingUIConfig.Trace06 = ConvertJSONToLoggingLevel(Trace06);
            if (Trace07 is not null) loggingUIConfig.Trace07 = ConvertJSONToLoggingLevel(Trace07);
            if (Trace08 is not null) loggingUIConfig.Trace08 = ConvertJSONToLoggingLevel(Trace08);
            if (Trace09 is not null) loggingUIConfig.Trace09 = ConvertJSONToLoggingLevel(Trace09);
            if (Trace10 is not null) loggingUIConfig.Trace10 = ConvertJSONToLoggingLevel(Trace10);
            if (Trace11 is not null) loggingUIConfig.Trace11 = ConvertJSONToLoggingLevel(Trace11);
            if (Trace12 is not null) loggingUIConfig.Trace12 = ConvertJSONToLoggingLevel(Trace12);
            if (Trace13 is not null) loggingUIConfig.Trace13 = ConvertJSONToLoggingLevel(Trace13);
            if (Trace14 is not null) loggingUIConfig.Trace14 = ConvertJSONToLoggingLevel(Trace14);
            if (Trace15 is not null) loggingUIConfig.Trace15 = ConvertJSONToLoggingLevel(Trace15);
            if (Trace16 is not null) loggingUIConfig.Trace16 = ConvertJSONToLoggingLevel(Trace16);
            if (Trace17 is not null) loggingUIConfig.Trace17 = ConvertJSONToLoggingLevel(Trace17);
            if (Trace18 is not null) loggingUIConfig.Trace18 = ConvertJSONToLoggingLevel(Trace18);
            if (Trace19 is not null) loggingUIConfig.Trace19 = ConvertJSONToLoggingLevel(Trace19);
            if (Trace20 is not null) loggingUIConfig.Trace20 = ConvertJSONToLoggingLevel(Trace20);
            if (Trace21 is not null) loggingUIConfig.Trace21 = ConvertJSONToLoggingLevel(Trace21);
            if (Trace22 is not null) loggingUIConfig.Trace22 = ConvertJSONToLoggingLevel(Trace22);
            if (Trace23 is not null) loggingUIConfig.Trace23 = ConvertJSONToLoggingLevel(Trace23);
            if (Trace24 is not null) loggingUIConfig.Trace24 = ConvertJSONToLoggingLevel(Trace24);
            if (Trace25 is not null) loggingUIConfig.Trace25 = ConvertJSONToLoggingLevel(Trace25);
            if (Trace26 is not null) loggingUIConfig.Trace26 = ConvertJSONToLoggingLevel(Trace26);
            if (Trace27 is not null) loggingUIConfig.Trace27 = ConvertJSONToLoggingLevel(Trace27);
            if (Trace28 is not null) loggingUIConfig.Trace28 = ConvertJSONToLoggingLevel(Trace28);
            if (Trace29 is not null) loggingUIConfig.Trace29 = ConvertJSONToLoggingLevel(Trace29);

            return loggingUIConfig;
        }

        private LoggingLevel ConvertJSONToLoggingLevel(LoggingLevelX loggingLevelX)
        {
            LoggingLevel loggingLevel = new LoggingLevel
            {
                Label = loggingLevelX.Label,
                ToolTip = loggingLevelX.ToolTip,
                Color = ConvertToColor(loggingLevelX.Color),
                LabelColor = ConvertToColor(loggingLevelX.LabelColor),
                IsChecked = loggingLevelX.IsChecked,
                Visibility = (System.Windows.Visibility)loggingLevelX.Visibility
            };

            return loggingLevel;
        }

        private System.Drawing.Color ConvertToColor(ColorX colorX)
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(colorX.A, colorX.R, colorX.G, colorX.B);

            return color;
        }
    
    }

}
