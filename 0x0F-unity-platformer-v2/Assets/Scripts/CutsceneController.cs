using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject Player;
    public GameObject playerFollowCamera;
    public GameObject timerCanvas;
    public GameObject introCam;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void introCheck()
    {
        introCam.SetActive(false);
        playerFollowCamera.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
    }

    // Switch to main camera
    void mainCheck()
    {
        MainCamera.SetActive(true);
        playerFollowCamera.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
    }
}
