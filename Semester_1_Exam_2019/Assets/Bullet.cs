using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player_Bulllet;
    public GameObject Boss_Bullet;

    public bool IsPlayerBullet;
    public bool IsBossBullet;

    public float DestroyTime;
    public float speed;


    void Start()
    {
        if(gameObject.tag == "Player_Bullet")
        {
            IsPlayerBullet = true;
            Rigidbody PL_Rb = gameObject.GetComponent<Rigidbody>();
        }
        if(gameObject.tag == "Boss_Bullet")
        {
            IsBossBullet = true;
            Rigidbody BO_Rb = gameObject.GetComponent<Rigidbody>();
        }
    }
 

    void Update()
    {
        Destroy(gameObject, DestroyTime);
    }
}
