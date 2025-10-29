using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Content
{
    [UsedImplicitly]
    public class RemoteContentLoader
    {
        private const string CONTENT_PATH = "RemoteContent";
        private readonly ContentProvider _contentProvider;

        public RemoteContentLoader(ContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public async void Load()
        {
            var contentJson = await Resources.LoadAsync(CONTENT_PATH);
            var json = ((TextAsset)contentJson).text;
            var remoteContent = .FromJson<Dictionary<string, string>>(json);
            _contentProvider.ApplyRemoteContent(remoteContent);
        }
    }
}