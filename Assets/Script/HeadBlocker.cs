using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBlocker : MonoBehaviour
{
    [Header("XRInteractionSetup - XROrigin - CameraOffset - Main Camera에 넣기.")]
    [Tooltip("머리가 닿았을 때 띄워줄 UI")]
    public GameObject blocker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cliff"))
        {
            blocker.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cliff"))
        {
            blocker.SetActive(false);
        }
    }
}
