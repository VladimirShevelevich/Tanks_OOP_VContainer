using System;
using Content;
using Game.Level;
using Game.Level.Config;
using R3;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class LevelLoader : IInitializable
    {
        private readonly LifetimeScope _gameScope;
        private LevelScope _levelScope;
        private readonly LevelConfig[] _levels;

        public LevelLoader(LifetimeScope lifetimeScope, LevelConfig[] levels)
        {
            _gameScope = lifetimeScope;
            _levels = levels;
        }
        
        public void Initialize()
        {
            CreateLevelScope();
        }

        private void CreateLevelScope()
        {
            _levelScope = _gameScope.CreateChild<LevelScope>(builder =>
            {
                builder.RegisterInstance(_levels[0]);
            });
        }
    }
}