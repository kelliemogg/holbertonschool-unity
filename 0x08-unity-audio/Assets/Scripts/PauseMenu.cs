using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isOnPause;

    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetButtonDown("escape"))
        {
            isOnPause = !isOnPause;
            if (!isOnPause)
            {
                Pause();
            }
            if (isOnPause)
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        isOnPause = true;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        isOnPause = false;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
