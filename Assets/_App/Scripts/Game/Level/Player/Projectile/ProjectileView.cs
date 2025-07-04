using UnityEngine;

namespace Game.Level.Player.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        private float _speed;

        public void Init(float speed)
        {
            _speed = speed;
        }
        
        private void Update()
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }
}