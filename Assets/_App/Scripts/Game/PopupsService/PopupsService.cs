using JetBrains.Annotations;

namespace Game.Popups
{
    [UsedImplicitly]
    public class PopupsService
    {
        private readonly PopupsFactory _popupsFactory;

        public PopupsService(PopupsFactory popupsFactory)
        {
            _popupsFactory = popupsFactory;
        }
        
        public void CreatePopup(PopupType popupType) =>
            _popupsFactory.CreatePopup(popupType);
    }   
}