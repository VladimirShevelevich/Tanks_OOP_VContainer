using UnityEngine;

namespace Game.Level.Player.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(transform.forward * Time.deltaTime * 10);
        }
    }
}