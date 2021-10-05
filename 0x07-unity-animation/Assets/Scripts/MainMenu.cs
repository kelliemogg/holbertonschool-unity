using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void LevelSelect(string name)
    {
        if (name == "Exit")
            Debug.Log("Exited");
        else
            SceneManager.LoadScene(name);
    }
}
