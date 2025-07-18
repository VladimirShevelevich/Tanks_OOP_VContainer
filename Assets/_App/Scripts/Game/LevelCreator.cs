using Game.Level;
using Game.Level.Config;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    [UsedImplicitly]
    public class LevelCreator : IInitializable
    {
        private readonly LifetimeScope _gameScope;
        private LevelScope _levelScope;
        private readonly LevelConfig[] _levels;

        public LevelCreator(LifetimeScope gameScope, LevelConfig[] levels)
        {
            _gameScope = gameScope;
            _levels = levels;
        }
        
        public void Initialize()
        {
            CreateLevelScope();
        }

        public void TriggerLevelReload()
        {
            Debug.Log("Level reload");
        }

        private void CreateLevelScope()
        {
            _levelScope = _gameScope.CreateChild<LevelScope>(
                RegisterLevelConfig);
        }

        private void RegisterLevelConfig(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levels[0]);
        }
    }
}