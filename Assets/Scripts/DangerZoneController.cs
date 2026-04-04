using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private Transform target;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.EnterDangerZone();
        activeCountdown = StartCoroutine(MissileCountdown());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (activeCountdown != null)
            StopCoroutine(activeCountdown);

        missileLauncher.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(target);
    }
}