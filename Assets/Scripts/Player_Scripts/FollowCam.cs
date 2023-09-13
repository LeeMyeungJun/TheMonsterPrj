using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] 
    Transform target;

    [SerializeField] 
    float rotSpeed = 2f;
    [SerializeField] 
    float dist = 5;

    [SerializeField] 
    float minAngle = -20;
    [SerializeField]
    float maxAngle = 45;

    [SerializeField]
    Vector2 offset;

    float rotX;
    float rotY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        rotX += Input.GetAxis("Mouse Y") * -1 * rotSpeed;
        rotX = Mathf.Clamp(rotX, minAngle, maxAngle);

        rotY += Input.GetAxis("Mouse X") * rotSpeed;

        var targetRotation = Quaternion.Euler(rotX, rotY, 0);
        var focusPosition = target.position + new Vector3(offset.x, offset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, dist);
        transform.rotation = targetRotation;
    }
}
