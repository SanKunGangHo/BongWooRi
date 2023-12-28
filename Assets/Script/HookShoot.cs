using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class HookShoot : MonoBehaviour
{
    [Tooltip("날아가는 속도")]
    public float shootSpeed = 7f;
    [Tooltip("맞은 곳의 위치값")]
    public Vector3 hookedPos;
    [Tooltip("플레이어")]
    public XROrigin Player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
        Player = GameObject.FindObjectOfType<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cliff"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player.MoveCameraToWorldLocation(transform.position);
        }
    }
}
