using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    [Tooltip("도착점")]
    public GameObject EndPoint;
    public XROrigin xr;
    public Transform zipPos;
    private bool isZip = true;
    public bool isLeftHand;
    public bool isRightHand;
    public Animator zipAnimator;

    public GameObject Player;

    public AudioSource ziplineSFX; //짚라인 타는 소리

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isZip)
        {
        ZipMove();
        }
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log(1);
        if(other.gameObject.CompareTag("LeftHand") )
        {
            Debug.Log("LeftHand");
            isLeftHand = true;
           // xr.MoveCameraToWorldLocation(EndPoint.transform.position);
        }

        if(other.gameObject.CompareTag("RightHand") )
        {
            Debug.Log("RightHand");
            isRightHand = true;
           // xr.MoveCameraToWorldLocation(EndPoint.transform.position);
        }
        if(other.gameObject.CompareTag("Zip"))
        {
            isZip = false;
        }
        if(isLeftHand && isRightHand)
        {
            ziplineSFX.Play();
        }
    }

    void ZipMove()
    {
        if(isLeftHand && isRightHand)
        {
            zipAnimator.SetBool("isDown", true);
            Player.transform.position = zipPos.position;
        }
    }
}
