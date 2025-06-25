using Content;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentProvider _contentProvider;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_contentProvider);
            builder.RegisterEntryPoint<LevelLoader>();
        }
    }
}