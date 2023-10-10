using System;
using System.Text;
using NLog;
using NLogLib = NLog.LayoutRenderers;

namespace ALight.NLog.LayoutRenderer.Hash
{
    [NLogLib.LayoutRenderer("hash")]
    public class HashLayoutRenderer : NLogLib.LayoutRenderer
    {
        public string Value { get; set; }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (!String.IsNullOrEmpty(Value))
            {
                builder.Append(HashHelper.HashMurmur(Value));
            }
        }
    }
}
