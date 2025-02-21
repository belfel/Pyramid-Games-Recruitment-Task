using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private List<GameObject> wallsToSpawnOn = new List<GameObject>();

    private void Awake()
    {
        if (doorPrefab == null)
            Debug.LogWarning("doorPrefab property not assigned");

        if (wallsToSpawnOn.Count == 0)
            Debug.LogWarning("No locations added for the door to spawn");
    }

    private void Start()
    {
        SpawnDoor();
    }

    private void SpawnDoor()
    {
        if (wallsToSpawnOn.Count < 1)
            return;

        int randomIndex = Random.Range(0, wallsToSpawnOn.Count);
        Transform spawnTransform = wallsToSpawnOn[randomIndex].transform;
        Destroy(spawnTransform.gameObject);
        Instantiate(doorPrefab, spawnTransform.position, spawnTransform.rotation);
    }
}
