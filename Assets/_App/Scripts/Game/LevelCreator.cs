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
        private int _currentLevelIndex;

        public LevelCreator(LifetimeScope gameScope, LevelConfig[] levels)
        {
            _gameScope = gameScope;
            _levels = levels;
        }
        
        public void Initialize()
        {
            CreateLevel();
        }

        public void TriggerLevelReload()
        {
            ReloadCurrentLevel();
        }

        private void ReloadCurrentLevel()
        {
            _levelScope.Dispose();
            CreateLevel();
        }

        private void CreateLevel()
        {
            _levelScope = _gameScope.CreateChild<LevelScope>(
                RegisterLevelConfig);
        }

        private void RegisterLevelConfig(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levels[_currentLevelIndex]);
        }
    }
}