using UnityEngine;

public class CameraController : MonoBehaviour
{
    // camera follows the player object at an offset
    public GameObject player;
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // camera reacts to click drag camera movement
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    // camera reacts to mouse movement

    private float yaw;
    private float pitch;

    void Start()
    {
        target = player.transform;
    }
    void FixedUpdate ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * dragSpeed, -Input.GetAxis("Mouse X") * dragSpeed, 0));
            return;
        }
        if (!Input.GetMouseButton(0))
        {
            return;
        }
        yaw = transform.rotation.eulerAngles.x;
        pitch = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(yaw, pitch, 0);

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
 
        transform.Rotate(-move, Space.World);
    }
}
