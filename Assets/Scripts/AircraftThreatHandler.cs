using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Missile")) return;

        Destroy(other.gameObject);
        RespawnAircraft();
    }

    private void RespawnAircraft()
    {
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        examManager.MissileHit();
    }
}