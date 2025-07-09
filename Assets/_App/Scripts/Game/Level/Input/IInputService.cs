using UniRx;
using UnityEngine;

namespace Game.Level.Input
{
    public interface IInputService
    {
        Vector2 Axis();
        bool ShootKeyDown();
    }
}