using System.Drawing;
using System.Windows;

namespace VNCLogViewer.LoggingUIConfig
{
    // NOTE(crhodes)
    // This is the default and is used unless overridden

    public class LoggingUIConfig
    {
        public string Name { get; set; }

        // TODO(crhodes)
        // Add Error, Warning

        public LoggingLevel Info00 { get; set; } = new LoggingLevel { Label = "Info00",  ToolTip = "Info00 / 100" };
        public LoggingLevel Info01 { get; set; } = new LoggingLevel { Label = "Info01",  ToolTip = "Info01 / 101" };
        public LoggingLevel Info02 { get; set; } = new LoggingLevel { Label = "Info02",  ToolTip = "Info02 / 102" };
        public LoggingLevel Info03 { get; set; } = new LoggingLevel { Label = "Info03",  ToolTip = "Info03 / 103" };
        public LoggingLevel Info04 { get; set; } = new LoggingLevel { Label = "Info04",  ToolTip = "Info0 / 104" };

        public LoggingLevel Debug00 { get; set; } = new LoggingLevel { Label = "Debug00",  ToolTip = "Debug00 / 1000" };
        public LoggingLevel Debug01 { get; set; } = new LoggingLevel { Label = "Debug01",  ToolTip = "Debug01 / 1001" };
        public LoggingLevel Debug02 { get; set; } = new LoggingLevel { Label = "Debug02",  ToolTip = "Debug02 / 1002" };
        public LoggingLevel Debug03 { get; set; } = new LoggingLevel { Label = "Debug03",  ToolTip = "Debug03 / 1003" };
        public LoggingLevel Debug04 { get; set; } = new LoggingLevel { Label = "Debug04",  ToolTip = "Debug04 / 1004" };

        public LoggingLevel Arch00 { get; set; } = new LoggingLevel { Label = "Arch00",  ToolTip = "Arch00 / 9000" };
        public LoggingLevel Arch01 { get; set; } = new LoggingLevel { Label = "Arch01",  ToolTip = "Arch01 / 9001" };
        public LoggingLevel Arch02 { get; set; } = new LoggingLevel { Label = "Arch02",  ToolTip = "Arch02 / 9002" };
        public LoggingLevel Arch03 { get; set; } = new LoggingLevel { Label = "Arch03",  ToolTip = "Arch03 / 9003" };
        public LoggingLevel Arch04 { get; set; } = new LoggingLevel { Label = "Arch04",  ToolTip = "Arch04 / 9004" };
        public LoggingLevel Arch05 { get; set; } = new LoggingLevel { Label = "Arch05",  ToolTip = "Arch05 / 9005" };
        public LoggingLevel Arch06 { get; set; } = new LoggingLevel { Label = "Arch06",  ToolTip = "Arch06 / 9006" };
        public LoggingLevel Arch07 { get; set; } = new LoggingLevel { Label = "Arch07",  ToolTip = "Arch07 / 9007" };
        public LoggingLevel Arch08 { get; set; } = new LoggingLevel { Label = "Arch08",  ToolTip = "Arch08 / 9008" };
        public LoggingLevel Arch09 { get; set; } = new LoggingLevel { Label = "Arch09",  ToolTip = "Arch09 / 9009" };

        public LoggingLevel Arch10 { get; set; } = new LoggingLevel { Label = "Arch10",  ToolTip = "Arch10 / 9010" };
        public LoggingLevel Arch11 { get; set; } = new LoggingLevel { Label = "Arch11",  ToolTip = "Arch11 / 9011" };
        public LoggingLevel Arch12 { get; set; } = new LoggingLevel { Label = "Arch12",  ToolTip = "Arch12 / 9012" };
        public LoggingLevel Arch13 { get; set; } = new LoggingLevel { Label = "Arch13",  ToolTip = "Arch13 / 9013" };
        public LoggingLevel Arch14 { get; set; } = new LoggingLevel { Label = "Arch14",  ToolTip = "Arch14 / 9014" };
        public LoggingLevel Arch15 { get; set; } = new LoggingLevel { Label = "Arch15",  ToolTip = "Arch15 / 9015" };
        public LoggingLevel Arch16 { get; set; } = new LoggingLevel { Label = "Arch16",  ToolTip = "Arch16 / 9016" };
        public LoggingLevel Arch17 { get; set; } = new LoggingLevel { Label = "Arch17",  ToolTip = "Arch17 / 9017" };
        public LoggingLevel Arch18 { get; set; } = new LoggingLevel { Label = "Arch18",  ToolTip = "Arch18 / 9018" };
        public LoggingLevel Arch19 { get; set; } = new LoggingLevel { Label = "Arch19",  ToolTip = "Arch19 / 9019" };

        public LoggingLevel Trace00 { get; set; } = new LoggingLevel { Label = "Trace00",  ToolTip = "Trace00 / 10000" };
        public LoggingLevel Trace01 { get; set; } = new LoggingLevel { Label = "Trace01",  ToolTip = "Trace01 / 10001" };
        public LoggingLevel Trace02 { get; set; } = new LoggingLevel { Label = "Trace02",  ToolTip = "Trace02 / 10002" };
        public LoggingLevel Trace03 { get; set; } = new LoggingLevel { Label = "Trace03",  ToolTip = "Trace03 / 10003" };
        public LoggingLevel Trace04 { get; set; } = new LoggingLevel { Label = "Trace04",  ToolTip = "Trace04 / 10004" };
        public LoggingLevel Trace05 { get; set; } = new LoggingLevel { Label = "Trace05",  ToolTip = "Trace05 / 10005" };
        public LoggingLevel Trace06 { get; set; } = new LoggingLevel { Label = "Trace06",  ToolTip = "Trace06 / 10006" };
        public LoggingLevel Trace07 { get; set; } = new LoggingLevel { Label = "Trace07",  ToolTip = "Trace07 / 10007" };
        public LoggingLevel Trace08 { get; set; } = new LoggingLevel { Label = "Trace08",  ToolTip = "Trace08 / 10008" };
        public LoggingLevel Trace09 { get; set; } = new LoggingLevel { Label = "Trace09",  ToolTip = "Trace09 / 10009" };

        public LoggingLevel Trace10 { get; set; } = new LoggingLevel { Label = "Trace10",  ToolTip = "Trace10 / 10010" };
        public LoggingLevel Trace11 { get; set; } = new LoggingLevel { Label = "Trace11",  ToolTip = "Trace11 / 10011" };
        public LoggingLevel Trace12 { get; set; } = new LoggingLevel { Label = "Trace12",  ToolTip = "Trace12 / 10012" };
        public LoggingLevel Trace13 { get; set; } = new LoggingLevel { Label = "Trace13",  ToolTip = "Trace13 / 10013" };
        public LoggingLevel Trace14 { get; set; } = new LoggingLevel { Label = "Trace14",  ToolTip = "Trace14 / 10014" };
        public LoggingLevel Trace15 { get; set; } = new LoggingLevel { Label = "Trace15",  ToolTip = "Trace15 / 10015" };
        public LoggingLevel Trace16 { get; set; } = new LoggingLevel { Label = "Trace16",  ToolTip = "Trace16 / 10016" };
        public LoggingLevel Trace17 { get; set; } = new LoggingLevel { Label = "Trace17",  ToolTip = "Trace17 / 10017" };
        public LoggingLevel Trace18 { get; set; } = new LoggingLevel { Label = "Trace18",  ToolTip = "Trace18 / 10018" };
        public LoggingLevel Trace19 { get; set; } = new LoggingLevel { Label = "Trace19",  ToolTip = "Trace19 / 10019" };

        public LoggingLevel Trace20 { get; set; } = new LoggingLevel { Label = "Trace20",  ToolTip = "Trace20 / 10020" };
        public LoggingLevel Trace21 { get; set; } = new LoggingLevel { Label = "Trace21",  ToolTip = "Trace21 / 10021" };
        public LoggingLevel Trace22 { get; set; } = new LoggingLevel { Label = "Trace22",  ToolTip = "Trace22 / 10022" };
        public LoggingLevel Trace23 { get; set; } = new LoggingLevel { Label = "Trace23",  ToolTip = "Trace23 / 10023" };
        public LoggingLevel Trace24 { get; set; } = new LoggingLevel { Label = "Trace24",  ToolTip = "Trace24 / 10024" };
        public LoggingLevel Trace25 { get; set; } = new LoggingLevel { Label = "Trace25",  ToolTip = "Trace25 / 10025" };
        public LoggingLevel Trace26 { get; set; } = new LoggingLevel { Label = "Trace26",  ToolTip = "Trace26 / 10026" };
        public LoggingLevel Trace27 { get; set; } = new LoggingLevel { Label = "Trace27",  ToolTip = "Trace27 / 10027" };
        public LoggingLevel Trace28 { get; set; } = new LoggingLevel { Label = "Trace28",  ToolTip = "Trace28 / 10028" };
        public LoggingLevel Trace29 { get; set; } = new LoggingLevel { Label = "Trace29",  ToolTip = "Trace29 / 10029" };

    }
}
