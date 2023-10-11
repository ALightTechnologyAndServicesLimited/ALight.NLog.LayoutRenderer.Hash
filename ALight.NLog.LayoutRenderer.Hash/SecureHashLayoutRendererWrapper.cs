using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using NLogLib = NLog.LayoutRenderers;

namespace ALight.NLog.LayoutRenderer.Hash
{
    [NLogLib.LayoutRenderer("securehash")]
    public class SecureHashLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        protected override string Transform(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return HashHelper.HashSHA256(text);
            }

            return String.Empty;
        }
    }
}