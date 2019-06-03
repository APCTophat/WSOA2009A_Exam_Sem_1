using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float BossHealth;
    public float MaxHealth;
    public float BossCurrentHealth;
    public float SpecialAttack;


    
    void Start()
    {
        BossHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        BossCurrentHealth = BossHealth / MaxHealth;


        if(BossHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player_Bullet")
        {
            BossHealth = BossHealth - 10;
        }
       
    }


}
