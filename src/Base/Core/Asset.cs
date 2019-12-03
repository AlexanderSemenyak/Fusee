using System;
using Fusee.Base.Common;

namespace Fusee.Base.Core
{
    public class Asset<T> : IAsset
        where T : new()
    {
        public string Id { get; private set; }
        public T Content { get; set; }
        public AssetStatus Status { get; set; }

        public event EventHandler onReady;
        public event EventHandler onError;

        public Asset(string id)
        {
            Id = id;
            Content = new T();
            Status = AssetStatus.None;

            onReady += delegate (object sender, EventArgs e) { Status = AssetStatus.Ready; };
            onError += delegate (object sender, EventArgs e) { Status = AssetStatus.Error; };

#if DEBUG
            onReady += delegate (object sender, EventArgs e) { Diagnostics.Debug("Asset " + Id + " ready"); };
            onError += delegate (object sender, EventArgs e) { Diagnostics.Debug("Asset " + Id + " error"); };
#endif
        }

        public Asset(string id, EventHandler onReady) : this(id)
        {
            this.onReady += onReady;
        }

        public Asset(string id, EventHandler onReady, EventHandler onError) : this(id, onReady)
        {
            this.onError += onError;
        }

        internal void FillAsset(AssetStatus assetStatus, T content)
        {
            switch (assetStatus)
            {
                case AssetStatus.Error:
                    onError.Invoke(this, EventArgs.Empty);
                    break;

                case AssetStatus.Ready:
                    Content = content;
                    onReady.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }

    public enum AssetStatus
    {
        None,
        Loading,
        Ready,
        Error
    }
}
