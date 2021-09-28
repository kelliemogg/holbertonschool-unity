using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button resumeButton;
    public Button restartButton;
    public Button menuButton;
    public Button optionsButton;
    public bool isOnPause;

    // Start is called before the first frame update
    void Start()
    {
        Button ResumeButton = resumeButton.GetComponent<Button>();
        ResumeButton.onClick.AddListener(Resume);

        Button RestartButton = restartButton.GetComponent<Button>();
        RestartButton.onClick.AddListener(Restart);

        Button MenuButton = menuButton.GetComponent<Button>();
        MenuButton.onClick.AddListener(MainMenu);

        Button OptionsButton = optionsButton.GetComponent<Button>();
        OptionsButton.onClick.AddListener(Options);

        isOnPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isOnPause = true;
        pauseCanvas.gameObject.SetActive(true);
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
