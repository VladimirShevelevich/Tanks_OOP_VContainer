using UnityEngine;
using UnityEngine.UI;

namespace Game.Level.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        
        public void SetValue(float value)
        {
            _healthBar.fillAmount = value;
        }

        public void SetPosition(Vector3 position)
        {
            
        }
    }
}