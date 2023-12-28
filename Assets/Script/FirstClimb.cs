using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstClimb : MonoBehaviour
{
    [Header("Scene - 플레이어가 잡는 첫번째 바위마다")]
    [Tooltip("리스폰 포인트를 조절할 수 있다.")]
    public RespawnCharacter respawn;

    private void Start()
    {
        respawn = GetComponent<RespawnCharacter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawn.enabled = true;
        }
    }
}
