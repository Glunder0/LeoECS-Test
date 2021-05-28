using UnityEngine;

namespace LeoESCTest.Settings
{
    [CreateAssetMenu(fileName = "New Projectile Spawn Settings", menuName = "Projectile Spawn Settings", order = 0)]
    public class ProjectileSpawnSettings : ScriptableObject
    {
        [SerializeField]
        private GameObject _projectilePrefab;
        [SerializeField]
        private float _spawnHeight;

        public GameObject ProjectilePrefab => _projectilePrefab;
        public float SpawnHeight => _spawnHeight;
    }
}