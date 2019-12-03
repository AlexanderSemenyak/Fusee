using Fusee.Base.Common;
using System;
using System.Collections.Generic;

namespace Fusee.Base.Core
{
    public class AssetManager
    {
        private static AssetManager _instance;

        public static AssetManager Instance => _instance ?? (_instance = new AssetManager());

        private List<> activeAsyncs;

        public void OnUpdateFrame()
        {


        }
    }
}
