using System;
using UnityEngine;

namespace Player.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(transform.forward * Time.deltaTime * 10);
        }
    }
}