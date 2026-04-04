using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    void Start()
    {
        statusText.text = "";
    }

    public void EnterDangerZone()
    {
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        statusText.text = "Threat cleared! Land safely.";
    }

    public void SetTakeOff()
    {
        hasTakenOff = true;
    }

    public bool IsThreatCleared()
    {
        return threatCleared;
    }

    public bool HasTakenOff()
    {
        return hasTakenOff;
    }
}