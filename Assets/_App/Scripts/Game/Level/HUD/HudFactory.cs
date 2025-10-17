using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.HUD
{
    [UsedImplicitly]
    public class HudFactory : BaseDisposable
    {
        private readonly IObjectResolver _objectResolver;
        private readonly HudContent _hudContent;
        private readonly Canvas _uiCanvas;

        public HudFactory(IObjectResolver objectResolver, HudContent hudContent, Canvas uiCanvas)
        {
            _objectResolver = objectResolver;
            _hudContent = hudContent;
            _uiCanvas = uiCanvas;
        }

        public GameObject CreateHud()
        {
            var go = Object.Instantiate(_hudContent.HudPrefab, _uiCanvas.transform);
            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}