using Game.Level.Player;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Level.HUD.Views
{
    public class HealthBarHUD : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        
        private PlayerContent _playerContent;
        private PlayerService _playerService;

        [Inject]
        public void Construct(PlayerContent playerContent, PlayerService playerService)
        {
            _playerContent = playerContent;
            _playerService = playerService;
        }

        private void Start()
        {
            SubscribeOnPlayerHealthChange();
        }

        private void SubscribeOnPlayerHealthChange()
        {
            _playerService.PlayerModel.CurrentHealth.Subscribe(UpdateHealthBar).
                AddTo(this);
        }

        private void UpdateHealthBar(int health)
        {
            var healthRelative = (float)health / _playerContent.InitialHealth;
            _healthBar.fillAmount = healthRelative;
        }
    }
}