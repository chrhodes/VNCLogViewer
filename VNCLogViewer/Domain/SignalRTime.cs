using System;
using System.Diagnostics;

namespace VNCLogViewer.Domain
{
    public class SignalRTime
    {
        public SignalRTime()
        {
            SendTime = DateTime.Now;

            SendTicks = Stopwatch.GetTimestamp();
            //HubReceivedTicks = 0;
            //ClientReceivedTicks = 0;
            //ClientMessageTicks = 4;
        }

        public double SendTicks { get; set; }
        public DateTime SendTime { get; set; }

        public double HubReceivedTicks { get; set; }
        public DateTime HubReceivedTime { get; set; }

        public double ClientReceivedTicks { get; set; }
        public DateTime ClientReceivedTime { get; set; }

        public double ClientMessageTicks { get; set; }
        public DateTime ClientMessageTime { get; set; }

    }
}
