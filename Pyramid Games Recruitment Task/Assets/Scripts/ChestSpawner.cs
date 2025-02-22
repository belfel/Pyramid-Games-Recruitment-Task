using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private Vector2 spawnRangeX;
    [SerializeField] private Vector2 spawnRangeZ;

    private GameObject chest;

    public void SpawnChest()
    {
        if (chest != null)
            Destroy(chest);

        Vector2 spawnPos = new Vector2(Random.Range(spawnRangeX.x, spawnRangeX.y), Random.Range(spawnRangeZ.x, spawnRangeZ.y));
        chest = Instantiate(chestPrefab, new Vector3 (spawnPos.x, 0f, spawnPos.y), Quaternion.identity);
        chest.transform.LookAt(Vector3.zero);
    }
}
