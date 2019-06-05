using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    private float BossHealth;
    public float MaxHealth;
    public float BossCurrentHealth;
    public float ActivateSpecialAttack;
    public float SpecialAttackMAX;
    public float CurrentSpecialAttack;
    public float Charge;
    public float MaxHealthSet;
    public float ChargeSet;

    public GameObject SpecialAttackObject;

    public bool InLevel_1;
    public bool InLevel_2;
    public bool InLevel_3;


    private void Awake()
    {
        SceneCheck();

        if(InLevel_1 == true)
        {
            MaxHealth = 100;
            ChargeSet = 10;
        }
        if (InLevel_2 == true)
        {
            MaxHealth = 150;
            ChargeSet = 9;
        }
        if (InLevel_3 == true)
        {
            MaxHealth = 200;
            ChargeSet = 8;
        }
    }
    void Start()
    {
        BossHealth = MaxHealth;
        ActivateSpecialAttack = 0;
        SpecialAttackMAX = 10;
        Charge = ChargeSet;
    }

   
    void Update()
    {
        BossCurrentHealth = BossHealth / MaxHealth;
        if(BossHealth <= 0)
        {
            FindObjectOfType<GameManager>().Invoke("NextLevel", 0f);
            //Destroy(gameObject);
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
            Charge = ChargeSet;
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
