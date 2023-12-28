using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    [Tooltip("세이브 포인트마다 트랜스폼 넣어주세요.")]
    public GameObject _savePoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.instance.Savepoint = _savePoint;
        }
    }

    public void OnButtonClick()
    {
        GameData.instance.Savepoint = _savePoint;
    }
}
