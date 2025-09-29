using System;
using Game.Popups.PopupFactories;
using JetBrains.Annotations;
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
        
        public void CreatePopup(PopupType popupType)
        {
            var type = FactoryType(popupType);
            var factory = _objectResolver.Resolve(type) as IPopupFactory;
            factory.Create();
        }

        private Type FactoryType(PopupType popupType)
        {
            switch (popupType)
            {
                case PopupType.Win:
                    return typeof(WinPopupFactory);
                case PopupType.GameOver:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(popupType), popupType, null);
            }

            throw new InvalidOperationException();
        }
    }
}