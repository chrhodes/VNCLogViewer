using System.Drawing;
using System.Windows;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingUIConfigVNCARCH : LoggingUIConfig
    {
        public LoggingUIConfigVNCARCH()
        {
            Name = "VNCARCH Capture Filter";

            // TODO(crhodes)
            // Need updated colors here

            Arch00 = new LoggingLevel { Label = "CONSTRUCTOR", LabelColor = Color.Plum, Color = Color.Plum, ToolTip = "CONSTRUCTOR / Arch00" };
            Arch01 = new LoggingLevel { Label = "EVENT", LabelColor = Color.FromArgb(255, 255, 0), Color = Color.FromArgb(255, 255, 0), ToolTip = "EVENT / Arch01" };
            Arch02 = new LoggingLevel { Label = "EVENT_HANDLER", LabelColor = Color.Red, Color = Color.Red, ToolTip = "EVENT_HANDLER / Arch02" };
            Arch03 = new LoggingLevel { Label = "APPLICATION_INITIALIZE", LabelColor = Color.LightGray, Color = Color.LightGray, ToolTip = "APPLICATION_INITIALIZE / Arch03" };
            Arch04 = new LoggingLevel { Label = "CORE", LabelColor = Color.FromArgb(190, 190, 190), Color = Color.FromArgb(190, 190, 190), ToolTip = "CORE / Arch04" };
            Arch05 = new LoggingLevel { Label = "MODULE", LabelColor = Color.Fuchsia, Color = Color.Fuchsia, ToolTip = "MODULE / Arch05" };
            Arch06 = new LoggingLevel { Label = "MODULE_INITIALIZE", LabelColor = Color.LightGray, Color = Color.LightGray, ToolTip = "MODULE_INITIALIZE / Arch06" };
            Arch07 = new LoggingLevel { Label = "APPLICATION", Color = Color.FromArgb(100, 240, 100), ToolTip = "APPLICATION / Arch07" };
            Arch08 = new LoggingLevel { Label = "APPLICATIONSERVICES", Color = Color.FromArgb(100, 240, 100), ToolTip = "APPLICATIONSERVICES / Arch08" };
            Arch09 = new LoggingLevel { Label = "DOMAIN", Color = Color.FromArgb(255, 180, 0), ToolTip = "DOMAIN / Arch09" };

            Arch10 = new LoggingLevel { Label = "DOMAINSERVICES", Color = Color.FromArgb(255, 180, 0), ToolTip = "DOMAINSERVICES / Arch10" };
            Arch11 = new LoggingLevel { Label = "PERSISTENCE", Color = Color.FromArgb(160, 115, 225), ToolTip = "PERSISTENCE / Arch11" };
            Arch12 = new LoggingLevel { Label = "PERSISTENCE_LOW", Color = Color.FromArgb(160, 115, 255), ToolTip = "PERSISTENCE_LOW / Arch12" };
            Arch13 = new LoggingLevel { Label = "INFRASTRUCTURE", Color = Color.White, ToolTip = "INFRASTRUCTURE / Arch13" };
            Arch14 = new LoggingLevel { Label = "PRESENTATION", Color = Color.FromArgb(0, 220, 220), ToolTip = "PRESENTATION / Arch14" };
            Arch15 = new LoggingLevel { Label = "VIEW", Color = Color.FromArgb(0, 220, 220), ToolTip = "VIEW / Arch15" };
            Arch16 = new LoggingLevel { Label = "VIEW_LOW", Color = Color.FromArgb(0, 220, 220), ToolTip = "VIEW_LOW / Arch16" };
            Arch17 = new LoggingLevel { Label = "VIEWMODEL", Color = Color.FromArgb(90, 255, 255), ToolTip = "VIEWMODEL / Arch17" };
            Arch18 = new LoggingLevel { Label = "VIEWMODEL_LOW", Color = Color.Aqua, ToolTip = "VIEWMODEL_LOW / Arch18" };
            Arch19 = new LoggingLevel { Label = "Arch19", LabelColor = Color.FromArgb(200, 200, 200), Color = Color.FromArgb(200, 200, 200), ToolTip = "Arch19" };
        }
    }
}