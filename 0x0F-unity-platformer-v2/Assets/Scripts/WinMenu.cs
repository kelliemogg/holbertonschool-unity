using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public GameObject Player;
    public Button menuButton;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        Button MenuButton = menuButton.GetComponent<Button>();
        menuButton.onClick.AddListener(MainMenu);
        Button NextButton = nextButton.GetComponent<Button>();
        nextButton.onClick.AddListener(Next);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Next()
    {
        SceneManager.LoadScene("Next");
    }
}
