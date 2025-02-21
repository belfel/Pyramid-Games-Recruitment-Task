using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorHinge;
    [SerializeField] private float openSpeed = 1f;

    private void Awake()
    {
        if (doorHinge == null)
            Debug.LogWarning("doorHinge property not assigned");
    }

    private void OnMouseDown()
    {
        StartCoroutine(OpenRoutine());
    }

    private IEnumerator OpenRoutine()
    {
        if (doorHinge == null)
            yield return null;

        float doorRotation = 0f;

        do
        {
            doorHinge.transform.localRotation = Quaternion.Euler(0f, doorRotation, 0f);
            doorRotation -= Time.deltaTime * openSpeed;
            yield return null;
        } while (doorRotation > -90f);
    }
}
