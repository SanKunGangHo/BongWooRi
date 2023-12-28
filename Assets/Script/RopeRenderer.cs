using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject box2;
    public Vector3 cube1Pos, cube2Pos;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        cube1Pos = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, cube1Pos);
        lr.SetPosition(1, box2.GetComponent<Transform>().position);
    }
}
