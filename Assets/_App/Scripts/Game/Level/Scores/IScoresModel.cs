using UniRx;

namespace Game.Level.Scores
{
    public interface IScoresService
    {
        IReadOnlyReactiveProperty<int> CurrentScore { get; }
    }
}