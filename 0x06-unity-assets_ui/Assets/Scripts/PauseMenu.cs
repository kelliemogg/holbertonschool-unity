using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseCanvas;
    public Button resumeButton;
    public Button restartButton;
    public Button menuButton;
    public Button optionsButton;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;

        timeScript = GetComponent<Timer>();

        Button ResumeButton = resumeButton.GetComponent<Button>();
        ResumeButton.onClick.AddListener(Resume);

        Button RestartButton = restartButton.GetComponent<Button>();
        RestartButton.onClick.AddListener(Restart);

        Button MenuButton = menuButton.GetComponent<Button>();
        MenuButton.onClick.AddListener(MainMenu);

        Button OptionsButton = optionsButton.GetComponent<Button>();
        OptionsButton.onClick.AddListener(Options);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void MainMenu()
    {
        Debug.Log("Main menu clicked");
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Pause()
    {
        Debug.Log("Paused");
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true);
        timeScript.Pause();

    }
    public void Resume()
    {
        Debug.Log("Resume");
        isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
        timeScript.Resume();
    }
}
