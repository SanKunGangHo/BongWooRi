using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    [Tooltip("���̺� ����Ʈ���� Ʈ������ �־��ּ���.")]
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
