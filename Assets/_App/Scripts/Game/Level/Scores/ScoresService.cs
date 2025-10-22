using System;
using Game.Analytics;
using JetBrains.Annotations;
using UniRx;

namespace Game.Level.Scores
{
    [UsedImplicitly]
    public class ScoresService : IScoresService, IAnalyticsContextProvider
    {
        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;
        private readonly ReactiveProperty<int> _currentScore = new();

        public void AddScores(int amount)
        {
            _currentScore.Value += amount;
        }

        void IAnalyticsContextProvider.UpdateAnalyticsContext(AnalyticsContext context)
        {
            context.Score = _currentScore.Value;
        }
    }
}