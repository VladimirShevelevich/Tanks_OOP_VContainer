using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
        [SerializeField] private BaseContent[] _contents;

        public void ApplyRemoteContent(Dictionary<string, string> remoteContent)
        {
            foreach (var content in _contents)
            {
                if (content is not RemotableContent<RemoteContent> remotable) 
                    continue;
                
                try
                {
                    remotable.ApplyRemoteContent(remoteContent);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        public void RegisterContent(IContainerBuilder builder)
        {
            foreach (var content in _contents)
            {
                var type = content.GetType();
                builder.RegisterInstance(content).As(type);
            }
        }
    }

    public class BaseContent : ScriptableObject
    {
            
    }
}