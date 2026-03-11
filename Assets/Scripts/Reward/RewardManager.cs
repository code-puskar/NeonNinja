using UnityEngine;

namespace NeonNinja
{
    public class RewardManager : MonoBehaviour
    {
        public static RewardManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public int Score { get; private set; } = 0;
        public int Multiplier { get; private set; } = 1;

        public GameObject goldenRunePrefab;
        public float runeSpawnChance = 0.05f;
        public int runeScoreValue = 500;

        public void AddScore(int amount)
        {
            Score += amount * Multiplier;
        }

        public void SetMultiplier(int multiplier)
        {
            Multiplier = multiplier;
        }

        public void OnEnemyKilled(Vector3 enemyPosition)
        {
            if (Random.value <= runeSpawnChance && goldenRunePrefab != null)
            {
                Instantiate(goldenRunePrefab, enemyPosition, Quaternion.identity);
            }
        }

        public void CollectRune()
        {
            AddScore(runeScoreValue);
        }
    }
}
