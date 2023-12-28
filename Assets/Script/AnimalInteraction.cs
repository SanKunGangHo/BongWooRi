using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteraction : MonoBehaviour
{
    public GameObject animal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animal.SetActive(true);
        }
    }
}
