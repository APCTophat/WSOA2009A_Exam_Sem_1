using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float BossHealth;
    public float MaxHealth;
    public float BossCurrentHealth;
    public float ActivateSpecialAttack;
    public float SpecialAttackMAX;
    public float CurrentSpecialAttack;
    public float Charge;

    public GameObject SpecialAttackObject;

    
    void Start()
    {
        BossHealth = MaxHealth;
        ActivateSpecialAttack = 0;
        SpecialAttackMAX = 10;
        Charge = 10;
    }

   
    void Update()
    {
        BossCurrentHealth = BossHealth / MaxHealth;
        if(BossHealth <= 0)
        {
            Destroy(gameObject);
        }

        SpecialAttack(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player_Bullet")
        {
            BossHealth = BossHealth - 10;
        }
       
    }

    void SpecialAttack()
    {
        CurrentSpecialAttack = ActivateSpecialAttack / SpecialAttackMAX;

        Charge -= Time.deltaTime;
        ActivateSpecialAttack = 10 - Charge;

        if(Charge <= 0)
        {
            Instantiate(SpecialAttackObject, new Vector3(0,0.5f,0), Quaternion.Euler(-90,0,0));
            Charge = 10;
        }
    }

}
