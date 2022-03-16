using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    private Vector3 target_Offset;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private float X;
    private float Y;
    public bool isInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        target_Offset = transform.position - target.position;

        if (PlayerPrefs.GetInt("isInvertedY") == 1)
        {
            isInverted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Steady cam follows player
        transform.position = Vector3.Lerp(transform.position, target.position+target_Offset, 0.1f);

        // Rotates when mouse is dragged
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * dragSpeed, -Input.GetAxis("Mouse X") * dragSpeed, 0));
            return;
        }
        if (!Input.GetMouseButton(0)) return;
        X = transform.rotation.eulerAngles.x;
        Y = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(X, Y, 0);

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
        transform.Rotate(-move, Space.World);
    }
}
