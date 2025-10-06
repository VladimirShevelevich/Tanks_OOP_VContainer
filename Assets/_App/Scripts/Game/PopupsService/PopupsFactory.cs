using System;
using Game.Level.ResultScreen;
using Game.Popups.PopupFactories;
using JetBrains.Annotations;
using UniRx;
using VContainer;

namespace Game.Popups
{
    [UsedImplicitly]
    public class PopupsFactory
    {
        private readonly IObjectResolver _objectResolver;

        public PopupsFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void CreatePopup(PopupType popupType, CompositeDisposable disposer)
        {
            var type = FactoryType(popupType);
            var factory = _objectResolver.Resolve(type) as IPopupFactory;
            factory.Create(disposer);
        }

        private Type FactoryType(PopupType popupType)
        {
            switch (popupType)
            {
                case PopupType.Win:
                    return typeof(WinPopupFactory);
                case PopupType.GameOver:
                    return typeof(GameOverPopupFactory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(popupType), popupType, null);
            }
        }
    }
}