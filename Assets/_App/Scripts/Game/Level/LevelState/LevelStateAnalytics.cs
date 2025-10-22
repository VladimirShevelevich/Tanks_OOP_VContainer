using Game.Analytics;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Game.Level.LevelState
{
    [UsedImplicitly]
    public class LevelStateAnalytics : BaseDisposable, IInitializable
    {
        private readonly LevelStateService _levelStateService;
        private readonly AnalyticsService _analyticsService;

        public LevelStateAnalytics(LevelStateService levelStateService, AnalyticsService analyticsService)
        {
            _levelStateService = levelStateService;
            _analyticsService = analyticsService;
        }
        
        public void Initialize()
        {
            AddDisposable(
                _levelStateService.CurrentState.Subscribe(HandleLevelStateChange));
        }

        private void HandleLevelStateChange(LevelStateType levelStateType)
        {
            SendAnalytics(levelStateType);
        }

        private void SendAnalytics(LevelStateType levelStateType)
        {
            if (levelStateType != LevelStateType.Win && levelStateType != LevelStateType.GameOver) 
                return;
            
            var analyticsCtx = _analyticsService.GetAnalyticsContext();
            Debug.Log($"Sending analytics event {levelStateType}, {analyticsCtx}");
        }
    }
}