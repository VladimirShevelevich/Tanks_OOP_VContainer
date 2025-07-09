using UnityEngine;
using VContainer;

namespace Game.Level.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        private ProjectileContent _projectileContent;

        [Inject]
        public void Construct(ProjectileContent projectileContent)
        {
            _projectileContent = projectileContent;
        }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += transform.forward * (Time.deltaTime * _projectileContent.Speed);
        }
    }
}