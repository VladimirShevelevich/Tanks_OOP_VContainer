using Game.Level.Enemy;
using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Game.Level.HUD
{
    [UsedImplicitly]
    public class HudPresenter : BaseDisposable, IInitializable
    {
        private readonly HudFactory _hudFactory;

        public HudPresenter(HudFactory hudFactory)
        {
            _hudFactory = hudFactory;
        }
        
        public void Initialize()
        {
            CreateView();            
        }        
        
        private void CreateView()
        {
            _hudFactory.CreateHud();
        }
    }
}