using JetBrains.Annotations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.Projectile
{
    [UsedImplicitly]
    public class ProjectileFactory
    {
        private readonly ProjectileContent _projectileContent;
        private readonly IObjectResolver _objectResolver;

        public ProjectileFactory(ProjectileContent projectileContent, IObjectResolver objectResolver)
        {
            _projectileContent = projectileContent;
            _objectResolver = objectResolver;
        }

        public ProjectileView Create(Vector3 position, Quaternion rotation, ProjectileSourceType sourceType)
        {
            var view = Object.Instantiate(_projectileContent.ProjectilePrefab, position, rotation);
            _objectResolver.InjectGameObject(view.gameObject);
            view.SetSourceType(sourceType);
            return view;
        }
    }
}