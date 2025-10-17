using Game.Popups;
using JetBrains.Annotations;

namespace Game.Settings
{
    [UsedImplicitly]
    public class SettingsService
    {
        private readonly PopupsService _popupsService;

        public SettingsService(PopupsService popupsService)
        {
            _popupsService = popupsService;
        }
        
        public void OpenSettingsPopup()
        {
            _popupsService.CreatePopup(PopupType.Settings);
        }
    }
}