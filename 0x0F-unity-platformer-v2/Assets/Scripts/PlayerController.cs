using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {     
        //cap.GetComponent<MeshRenderer>().material.color = Color.red;
        if (player.transform.position.y < -6)
        {
            player.transform.position = spawnPoint.position;
        }
    }
}
