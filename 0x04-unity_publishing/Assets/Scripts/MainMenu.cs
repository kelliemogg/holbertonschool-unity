using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public Color colorblindMat = new Color32(255, 112, 0, 1);

    // Start is called before the first frame update
    public void PlayMaze()
    {
        if (colorblindMode.isOn == true)
        {
            trapMat.color = colorblindMat;
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("maze");
    }
    // Quit Maze
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
