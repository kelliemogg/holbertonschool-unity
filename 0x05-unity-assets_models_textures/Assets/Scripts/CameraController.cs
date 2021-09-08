using UnityEngine;

public class CameraController : MonoBehaviour
{
    // camera follows the player object at an offset
    public GameObject player;
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationsSpeed = 5.0f;

    void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate ()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            offset = camTurnAngle * offset;
        }
        
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(target);
    }
}
