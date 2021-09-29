using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text TimerText;
    public Canvas WinCanvas;
    public Timer timeScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Winner");
        if (other.gameObject.name == "Player")
        {
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
            player.GetComponent<Timer>().enabled = false;
            player.GetComponent<Timer>().Win();
            WinCanvas.gameObject.SetActive(true);
        }
    }
}
