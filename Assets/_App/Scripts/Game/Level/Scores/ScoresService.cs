using System;
using JetBrains.Annotations;
using UniRx;

namespace Game.Level.Scores
{
    [UsedImplicitly]
    public class ScoresService : IScoresService
    {
        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;
        private readonly ReactiveProperty<int> _currentScore = new();

        public void AddScores(int amount)
        {
            _currentScore.Value += amount;
        }
    }
}