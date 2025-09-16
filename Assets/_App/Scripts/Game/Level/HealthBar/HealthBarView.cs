using UnityEngine;
using UnityEngine.UI;

namespace Game.Level.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        
        private Camera _camera;
        private Transform _targetTransform;

        public void SetTargetTransform(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }

        public void SetValue(float value)
        {
            _filler.fillAmount = value;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.position = _targetTransform.position;
            transform.rotation = Quaternion.LookRotation(_camera.transform.forward, _camera.transform.up);
        }
    }
}