using JetBrains.Annotations;
using Tools.Disposable;
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
            var hud = _hudFactory.CreateHud();
            AddDisposable(new GameObjectDisposer(hud));
        }
    }
}