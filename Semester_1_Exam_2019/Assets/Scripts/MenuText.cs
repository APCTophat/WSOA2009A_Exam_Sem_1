using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuText : MonoBehaviour
{

    public Text PlayText;
    public Button PlayButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGane()
    {
        Application.Quit();
    }
   
    public void MainMenu()
    {
        Debug.Log("got to the menu");
        SceneManager.LoadScene("MenueScene");
    }

   
}
