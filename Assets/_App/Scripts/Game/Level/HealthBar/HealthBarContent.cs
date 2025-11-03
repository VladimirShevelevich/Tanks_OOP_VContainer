using Content;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Level.HealthBar
{
    [CreateAssetMenu(fileName = "HealthBar", menuName = "Content/HealthBar")]
    public class HealthBarContent : BaseContent
    {
        [field: SerializeField] public AssetReference ViewPrefabRef { get; private set; }
    }
}