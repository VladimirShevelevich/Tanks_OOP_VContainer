using System;
using System.Collections.Generic;
using Game.Level.Player;
using Newtonsoft.Json;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "Create Content", fileName = "Content", order = 0)]
    public abstract class RemotableContent<T> : BaseContent where T : RemoteContent
    {
        [SerializeField] protected T Remote;
        protected abstract string RemoteContentKey { get; }

        public void ApplyRemoteContent(Dictionary<string, string> remoteContentDict)
        {
            if (!remoteContentDict.TryGetValue(RemoteContentKey, out var remoteContentJson))
            {
                throw new Exception($"Remote content apply failed. Content key isn't found: {RemoteContentKey}");
            }

            var remoteContent = JsonConvert.DeserializeObject<T>(remoteContentJson);
            if (remoteContent == null)
            {
                throw new Exception($"Remote content apply failed. Deserialization failed. Content key: {RemoteContentKey}");
            }

            Remote = remoteContent;
        }
    }

    public abstract class RemoteContent
    {
        
    }
}