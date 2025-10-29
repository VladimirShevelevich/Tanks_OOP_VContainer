using System;
using Game.Analytics;
using Game.Level;
using Game.Level.Config;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    [UsedImplicitly]
    public class LevelCreator : IAnalyticsContextProvider, IInitializable
    {
        private readonly LifetimeScope _gameScope;
        private LevelScope _levelScope;
        private readonly LevelScope[] _levels;
        private int _currentLevelIndex;

        public LevelCreator(LifetimeScope gameScope, LevelScope[] levels)
        {
            _gameScope = gameScope;
            _levels = levels;
        }
        
        public void Initialize()
        {
            CreateLevelByCurrentIndex();
        }

        public void ReloadLevel()
        {
            CreateLevelByCurrentIndex();
        }

        public void LoadNextLevel()
        {
            _currentLevelIndex++;
            CreateLevelByCurrentIndex();
        }
        
        private void CreateLevelByCurrentIndex()
        {
            _levelScope?.Dispose();
            var levelPrefab = _levels[_currentLevelIndex % _levels.Length];
            _levelScope = _gameScope.CreateChildFromPrefab<LevelScope>(levelPrefab);
        }

        void IAnalyticsContextProvider.UpdateAnalyticsContext(AnalyticsContext context)
        {
            context.Level = _currentLevelIndex;
        }
    }
}