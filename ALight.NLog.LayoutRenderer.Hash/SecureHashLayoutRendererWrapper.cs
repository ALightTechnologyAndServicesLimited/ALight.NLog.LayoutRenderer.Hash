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
        private bool objectPool = true;

        public bool ObjectPool
        {
            get { return objectPool; }
            set { objectPool = value; }
        }

        protected override string Transform(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return HashHelper.HashSHA256(text, objectPool);
            }

            return String.Empty;
        }

        protected override void CloseLayoutRenderer()
        {
            HashHelper.DisposeSHA256();
        }
    }
}