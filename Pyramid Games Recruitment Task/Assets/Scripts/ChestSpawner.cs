using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;

    public void SpawnChest()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-12f, 12f), Random.Range(-12f, 12f));
        GameObject chestGO = Instantiate(chestPrefab, new Vector3 (spawnPos.x, 0f, spawnPos.y), Quaternion.identity);
        chestGO.transform.LookAt(Vector3.zero);
    }
}
