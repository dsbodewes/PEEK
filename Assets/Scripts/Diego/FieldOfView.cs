using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool inRadius;

    public NavMeshAgent enemy;

    public AudioSource WalkAudio;

    public Volume volume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;

    private float maxVignetteIntensity = 1f;
    private float minVignetteIntensity = 0.3f;
    public float vignetteIncreaseSpeed = 0.07f;

    private float maxChromaticAberrationIntensity = 1f;
    private float minChromaticAberrationIntensity = 0.1f;
    public float chromaticAberrationIncreaseSpeed = 0.25f;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromaticAberration);
    }

    private void Update()
    {
        if (canSeePlayer)
        {
            float targetVignetteIntensity = Mathf.Clamp(vignette.intensity.value + vignetteIncreaseSpeed * Time.deltaTime, minVignetteIntensity, maxVignetteIntensity);
            vignette.intensity.value = targetVignetteIntensity;

            float targetChromaticAberrationIntensity = Mathf.Clamp(chromaticAberration.intensity.value + chromaticAberrationIncreaseSpeed * Time.deltaTime, minChromaticAberrationIntensity, maxChromaticAberrationIntensity);
            chromaticAberration.intensity.value = targetChromaticAberrationIntensity;
        }
        else
        {
            vignette.intensity.value = minVignetteIntensity;
            chromaticAberration.intensity.value = minChromaticAberrationIntensity;
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;

            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;

        if (canSeePlayer)
        {
            enemy.SetDestination(playerRef.transform.position);
            angle = 360;
            WalkAudio.Play();
        }
        else
        {
            WalkAudio.Stop();
            angle = 90;
        }
    }
}