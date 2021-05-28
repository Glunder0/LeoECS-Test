using UnityEngine;

namespace LeoESCTest.Settings
{
    [CreateAssetMenu(fileName = "New Spawner Settings", menuName = "Spawner Settings", order = 0)]
    public class SpawnerSettings : ScriptableObject
    {
        [SerializeField]
        private GameObject _spawnedPrefab;
        [SerializeField]
        private float _spawnDelay;
        [SerializeField]
        private float _spawnDelayJitter;
        
        public GameObject SpawnedPrefab => _spawnedPrefab;
        public float SpawnDelay => _spawnDelay;
        public float SpawnDelayJitter => _spawnDelayJitter;
    }
}