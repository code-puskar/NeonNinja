using UnityEngine;

[CreateAssetMenu(fileName = "NewRuneConfig", menuName = "NeonNinja/Config/RuneConfig")]
public class RuneConfig : ScriptableObject
{
    public int pointValue = 500;
    [Range(0f, 1f)]
    public float spawnChance = 0.1f;
    public Color primaryColor = Color.yellow;
    public GameObject runePrefab; // Reference to the actual visual representation of the rune
}
