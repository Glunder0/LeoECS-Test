using UnityEngine;

namespace LeoESCTest.Settings
{
    [CreateAssetMenu(fileName = "New Explosion Settings", menuName = "Explosion Settings", order = 0)]
    public class ExplosionSettings : ScriptableObject
    {
        [SerializeField]
        private GameObject _explosionEffectPrefab;
        [SerializeField]
        private float _explosionRadius;
        [SerializeField]
        private int _explosionDamage;

        public GameObject ExplosionEffectPrefab => _explosionEffectPrefab;
        public float ExplosionRadius => _explosionRadius;
        public int ExplosionDamage => _explosionDamage;
    }
}