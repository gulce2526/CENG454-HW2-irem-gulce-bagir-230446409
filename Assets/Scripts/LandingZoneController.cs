using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!examManager.IsThreatCleared())
        {
            examManager.ShowMessage("You must clear the threat first!");
            return;
        }

        examManager.MissionComplete();
    }
}