using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGuide : MonoBehaviour
{
    public AudioSource tutorialGuide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            Debug.Log("RightHand");
            tutorialGuide.Play();
        }
    }


}
