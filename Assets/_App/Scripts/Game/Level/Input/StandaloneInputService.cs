using UnityEngine;

namespace Game.Level.Input
{
    public class StandaloneInputService : IInputService
    {
        public Vector2 Axis()
        {
            return new Vector2(
                UnityEngine.Input.GetAxis("Horizontal"), 
                UnityEngine.Input.GetAxis("Vertical")); 
        }

        public bool ShootKeyDown()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }
    }
}