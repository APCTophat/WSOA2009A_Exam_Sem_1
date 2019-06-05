using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialAttackScript : MonoBehaviour
{
    public float X;
    public float Y;
    public float Scale;


    public bool InLevel_1;
    public bool InLevel_2;
    public bool InLevel_3;


    private void Awake()
    {
        SceneCheck();
    }
    private void Start()
    {
        X = 1;
        Y = 1;

        if(InLevel_1 == true)
        {
            Scale = 5;
        }
        if (InLevel_2 == true)
        {
            Scale = 10;
        }
        if (InLevel_3 == true)
        {
            Scale = 15;
        }
    }

    private void Update()
    {
        X += Time.deltaTime * Scale;
        Y += Time.deltaTime * Scale;

        this.transform.localScale = new Vector3(X, Y, 10);


        if(X >= 30)
        {
            Destroy(gameObject);
        }
    }

    void SceneCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level_1")
        {
            InLevel_1 = true;
        }
        else
        {
            if (sceneName == "Level_2")
            {
                InLevel_2 = true;
            }
            else
            {
                if (sceneName == "Level_3")
                {
                    InLevel_3 = true;
                }
            }
        }


    }

}
