using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hook_Gun : MonoBehaviour
{
    [Tooltip("훅샷에 붙은 머리")]
    public GameObject head;
    [Tooltip("소환할 머리")]
    public GameObject summonHead;
    GameObject head_Summoned;
    //소환된 머리

    public LineRenderer lineRenderer;
    //본체가 가진 라인 렌더러
    bool isShoot;
    //총을 쏘았는가?

    private void Update()
    {
        if (isShoot)
        {
            lineRenderer.SetPosition(0, GetComponentInParent<Transform>().position);
            lineRenderer.SetPosition(1, head_Summoned.transform.GetChild(0).transform.position);
        }
        
    }

    private void Start()
    {
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.enabled = false;
        isShoot = false;
    }

    public void OnShoot()
    {
        head.SetActive(false);
        head_Summoned = Instantiate(summonHead, head.transform.position, GetComponentInParent<Transform>().rotation);
        isShoot = true;
        lineRenderer.enabled = true;
    }

    


}
