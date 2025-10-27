using System;
using System.Collections.Generic;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "Create Content", fileName = "Content", order = 0)]
    public abstract class BaseContent<T> : ScriptableObject where T : RemoteContent
    {
        protected virtual string RemoteContentKey => "";
        protected T RemoteContent;
        
        public void ApplyRemoteContent(Dictionary<string, string> remoteContentDict)
        {
            if(RemoteContentKey == "")
                return;

            if (!remoteContentDict.TryGetValue(RemoteContentKey, out var remoteContentJson))
            {
                throw new Exception($"Remote content apply failed. Content key isn't found: {RemoteContentKey}");
            }

            var remoteContent = JsonUtility.FromJson<T>(RemoteContentKey);
            if (remoteContent == null)
            {
                throw new Exception($"Remote content apply failed. Deserialization failed. Content key: {RemoteContentKey}");
            }

            RemoteContent = remoteContent;
        }
    }

    public abstract class RemoteContent
    {
        
    }
}