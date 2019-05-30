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
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGane()
    {
        Application.Quit();
    }
   

   
}
