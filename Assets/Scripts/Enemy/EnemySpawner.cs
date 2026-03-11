using UnityEngine;

namespace NeonNinja
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public float baseSpawnInterval = 2f;
        public float speedMultiplierIncrease = 0.1f;
        
        private float currentSpawnInterval;
        private float nextSpawnTime;
        private int waveCount = 0;

        void Start()
        {
            currentSpawnInterval = baseSpawnInterval;
        }

        void Update()
        {
            if (GameManager.Instance != null && !GameManager.Instance.IsPlaying) return;

            if (Time.time >= nextSpawnTime)
            {
                SpawnEnemy();
                nextSpawnTime = Time.time + currentSpawnInterval;
                waveCount++;

                if (waveCount % 10 == 0)
                {
                    currentSpawnInterval = Mathf.Max(0.5f, currentSpawnInterval - speedMultiplierIncrease);
                }
            }
        }

        private void SpawnEnemy()
        {
            if (enemyPrefab != null)
            {
                Vector3 spawnPos = new Vector3(transform.position.x + 15f, Random.Range(-3f, 3f), 0);
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
