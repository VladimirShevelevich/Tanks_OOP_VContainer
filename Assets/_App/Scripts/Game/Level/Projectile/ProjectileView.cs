using UnityEngine;
using VContainer;

namespace Game.Level.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        private ProjectileContent _projectileContent;
        public ProjectileSourceType SourceType { get; private set; }

        [Inject]
        public void Construct(ProjectileContent projectileContent)
        {
            _projectileContent = projectileContent;
        }

        public void SetSourceType(ProjectileSourceType sourceType)
        {
            SourceType = sourceType;
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