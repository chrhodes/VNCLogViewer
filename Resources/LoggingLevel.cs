using System;
using System.Drawing;

namespace VNCLogViewer.Resources
{
    public struct LoggingLevel
    {
        public string Label { get; set; }
        public Color Color { get; set; }
        public Boolean IsChecked { get; set; }
        public string ToolTip { get; set; }
        public System.Windows.Visibility Visibility { get; set; }
    }
}
