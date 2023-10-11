using NLog;
using NLog.LayoutRenderers;
using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using NLogLib = NLog.LayoutRenderers;

namespace ALight.NLog.LayoutRenderer.Hash
{
    [NLogLib.LayoutRenderer("hash")]
    public class HashLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        protected override string Transform(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return HashHelper.HashMurmur(text);
            }

            return String.Empty;
        }
    }
}
