using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private Transform target;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudioSource;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.EnterDangerZone();

        if (warningAudioSource != null)
            warningAudioSource.Play();

        activeCountdown = StartCoroutine(MissileCountdown());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (activeCountdown != null)
            StopCoroutine(activeCountdown);

        if (warningAudioSource != null)
            warningAudioSource.Stop();

        missileLauncher.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(target);
    }
}