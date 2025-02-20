using UnityEngine;

public class RTS_Camera : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float rotationSpeed = 1f;

    private void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessMovement()
    {
        float speed = movementSpeed;
        Vector3 movement = Vector3.zero;
        Vector3 cameraForward = new Vector3(transform.forward.x, 0f, transform.forward.z);

        movement += transform.right * Input.GetAxisRaw("Horizontal");
        movement += cameraForward * Input.GetAxisRaw("Vertical");

        movement.Normalize();
        movement *= speed * Time.deltaTime;
        transform.position += movement;
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
