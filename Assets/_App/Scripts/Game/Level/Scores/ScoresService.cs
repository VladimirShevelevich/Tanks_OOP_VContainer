using System;
using JetBrains.Annotations;
using UniRx;

namespace Game.Level.Scores
{
    [UsedImplicitly]
    public class ScoresService
    {
        public IReadOnlyReactiveProperty<int> CurrentScore;
        private readonly ReactiveProperty<int> _currentScore = new();
        
        public void AddScores(int amount)
        {
            _currentScore.Value += amount;
        }
    }
}