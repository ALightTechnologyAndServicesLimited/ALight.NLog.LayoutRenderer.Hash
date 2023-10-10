using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using NLogLib = NLog.LayoutRenderers;

namespace ALight.NLog.LayoutRenderer.Hash
{
    [NLogLib.LayoutRenderer("securehash")]
    public class SecureHashLayoutRenderer : NLogLib.LayoutRenderer
    {
        public string Value { get; set; }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (!String.IsNullOrEmpty(Value))
            {
                builder.Append(HashHelper.HashSHA256(Value));
            }
        }
    }
}
