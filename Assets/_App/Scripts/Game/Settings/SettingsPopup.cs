using Game.Popups;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Settings
{
    public class SettingsPopup : Popup
    {
        [SerializeField] private Button _closeButton;

        private void Start()
        {
            _closeButton.OnClickAsObservable().Subscribe(_ =>
                Close()).
                AddTo(this);
        }
    }
}