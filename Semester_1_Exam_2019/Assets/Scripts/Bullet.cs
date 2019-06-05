using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public GameObject Player_Bulllet;
    public GameObject Boss_Bullet;
    public GameObject Player;
    public GameObject Center;
    public GameObject Boss_Aimer;

    public Rigidbody rb;

    public bool IsPlayerBullet;
    public bool IsBossBullet;
    public bool InLevel_1;
    public bool InLevel_2;
    public bool InLevel_3;

    public float DestroyTime;
    public float speed;
    public float BossSpeed;


    void Start()
    {
        SceneCheck();
        Player = GameObject.FindGameObjectWithTag("Player");
        Center = GameObject.FindGameObjectWithTag("Center");
        Boss_Aimer = GameObject.FindGameObjectWithTag("Boss_Aimer");

        if(InLevel_1 == true)
        {
            BossSpeed = 10;
        }
        if (InLevel_2 == true)
        {
            BossSpeed = 15;
        }
        if (InLevel_3 == true)
        {
            BossSpeed = 20;
        }



        if (gameObject.tag == "Player_Bullet")
        {
            IsPlayerBullet = true;
            Rigidbody PL_Rb = gameObject.GetComponent<Rigidbody>();
            transform.rotation = Player.transform.rotation;
            rb.velocity = transform.forward * speed;
            
            
        }
        if(gameObject.tag == "Boss_Bullet")
        {
            IsBossBullet = true;
            Rigidbody BO_Rb = gameObject.GetComponent<Rigidbody>();
            transform.rotation = Boss_Aimer.transform.rotation;
            rb.velocity = transform.forward * BossSpeed;

        }
    }
 

    void Update()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Boss_Bullet")
        {
           if(collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }    
           if(collision.gameObject.tag == "SpecialAttack")
            {
                Destroy(gameObject);
            } 
        }
       
        if(gameObject.tag == "Player_Bullet")
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
