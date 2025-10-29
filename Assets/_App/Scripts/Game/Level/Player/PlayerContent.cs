using System;
using Content;
using UnityEngine;

namespace Game.Level.Player
{
    [CreateAssetMenu(fileName = "PlayerContent", menuName = "Content/Player")]
    public class PlayerContent : RemotableContent<PlayerRemoteContent>
    {
        protected override string RemoteContentKey => ContentStatic.RemoteKeys.Player;
        [field: SerializeField] public GameObject ViewPrefab { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; set; }
        [field: SerializeField] public int InitialHealth { get; set; }
        
        public float Speed => Remote.Speed;
    }

    [Serializable]
    public class PlayerRemoteContent : RemoteContent
    {
        public float Speed;
    }
}