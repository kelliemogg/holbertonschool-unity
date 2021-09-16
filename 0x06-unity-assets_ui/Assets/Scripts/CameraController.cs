using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform plyrTrans;
    public Vector3 offset;
    public float smoothFactor = 0.5f;

    public bool lookAtPlyr = false;
    public bool rotateAroundPlyr = true;
    public float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - plyrTrans.position;
    }
    
    // LateUpdate is called after Update
    void LateUpdate()
    {
        if (rotateAroundPlyr)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

                offset = camTurnAngle * offset;
            }
        
        Vector3 newPost = plyrTrans.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPost, smoothFactor);

        if (lookAtPlyr || rotateAroundPlyr)
        {
            transform.LookAt(plyrTrans);
        }
    }
}
