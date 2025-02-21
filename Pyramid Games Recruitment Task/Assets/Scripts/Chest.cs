using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject chestHinge;
    [SerializeField] private float openSpeed;

    private void Awake()
    {
        if (chestHinge == null)
            Debug.LogWarning("chestHinge property not assigned");
    }

    private void OnMouseDown()
    {
        StartCoroutine(OpenRoutine());
    }

    private IEnumerator OpenRoutine()
    {
        if (chestHinge == null)
            yield return null;

        float chestTopRotation = 0f;

        do
        {
            chestHinge.transform.localRotation = Quaternion.Euler(chestTopRotation, 0f, 0f);
            chestTopRotation -= Time.deltaTime * openSpeed;
            yield return null;
        } while (chestTopRotation > -90f);
    }
}
