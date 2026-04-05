
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; // degrees/second
    [SerializeField] private float yawSpeed = 45f;   // degrees/second
    [SerializeField] private float rollSpeed = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 5f; // units/second

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Pitch (Up/Down arrows)
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right * pitch);

        // Yaw (Left/Right arrows)
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * yaw);

        // Roll (Q and E keys)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * rollSpeed * Time.deltaTime);
        }
    }

    private void HandleThrust()
    {
        // Forward movement
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}