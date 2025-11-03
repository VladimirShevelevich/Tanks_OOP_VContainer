using Content;
using UnityEngine;

namespace Game.Level
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Content/Levels")]
    public class LevelsContent : BaseContent
    {
        [field: SerializeField] public LevelScope[] Levels { get; private set; }
    }
}