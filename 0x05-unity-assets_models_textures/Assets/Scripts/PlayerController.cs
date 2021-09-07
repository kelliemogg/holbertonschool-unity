using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 8.0f;
    public GameObject player;
    public float gravity = -8.0f;
    public bool isGrounded;
    public float jumpForce = 5.0f;

    /// gets rb for GameObject
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
                //This locks the RigidBody so that it does not move or rotate in the Z axis.
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true)
        {
            // GetAxis detects the user input (WASD or Arrows)
            float xDirection = Input.GetAxis("Horizontal");
            float zDirection = Input.GetAxis("Vertical");
            float jump = Input.GetAxis("Jump");

            // Vector3 is a variable that takes in 3 inputs (x, y, z)
            Vector3 moveDirection = new Vector3(xDirection * speed, jump * jumpForce, zDirection * speed);

            rb.AddForce(moveDirection * speed);
        }
    }
}
