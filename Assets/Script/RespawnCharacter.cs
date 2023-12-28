using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    [Tooltip("플레이어를 수행하는 XROrigin")]
    public CharacterController controller;
    private void Update()
    {
        if(controller.isGrounded == true)
        {
            this.gameObject.transform.position = GameData.instance.Savepoint.transform.position;
        }
    }
}
