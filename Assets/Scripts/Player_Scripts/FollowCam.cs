using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 5.0f;

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;

    public float damping = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        camTr.position = Vector3.Slerp(camTr.position,pos,Time.deltaTime*damping);

        camTr.LookAt(targetTr.position);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
