using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float DestroyTime;
    public float speed;
    public float BossSpeed;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Center = GameObject.FindGameObjectWithTag("Center");
        Boss_Aimer = GameObject.FindGameObjectWithTag("Boss_Aimer");

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
        }
       
        if(gameObject.tag == "Player_Bullet")
        {
                Destroy(gameObject);
            
        }
    }
}
