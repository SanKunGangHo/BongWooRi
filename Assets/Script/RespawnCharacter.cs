using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    [Tooltip("�÷��̾ �����ϴ� XROrigin")]
    public CharacterController controller;
    private void Update()
    {
        if(controller.isGrounded == true)
        {
            this.gameObject.transform.position = GameData.instance.Savepoint.transform.position;
        }
    }
}
