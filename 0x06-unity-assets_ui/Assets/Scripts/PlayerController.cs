using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpHeight = 5.0f;
    public float gravity = -10.0f;
    public GameObject player;
    private Rigidbody rb;

    public Transform spawnPoint;
    //private Vector3 playerVelocity;

    public bool isGrounded;

    private Vector3 move;

    /*private CharacterController controller;

    private Vector3 playerVelocity;
    private bool groundedPlayer;*/


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        //Debug.Log(isGrounded);
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Jump") * jumpHeight, Input.GetAxis("Vertical") * speed);
        }            
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            player.transform.position = spawnPoint.position;
            rb.velocity = new Vector3(0, 0, 0);
        }

        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
        //Debug.Log("Grounded");
        if (other.gameObject.tag=="Floor")
            isGrounded = true;
        Debug.Log(isGrounded);
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit");
        //Debug.Log("Not Grounded");
        if (other.gameObject.tag=="Floor")
            isGrounded = false;
        Debug.Log(isGrounded);
    }
}
