using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int NumOfSheilds_1;
    public int NumOfSheilds_2;
    public int NumOfSheilds_3;
    public int Ammo;

    public float ShootIntervals;
    public float RefillAmmo;

    public GameObject SheildPrefab_1;
    public GameObject SheildPrefab_2;
    public GameObject SheildPrefab_3;
    public GameObject PlayerBullet;
    public GameObject BossBullet;
    public GameObject Aimer;
    public GameObject Boss_Aimer;
    public GameObject Player;

    public bool Ammo_1;
    public bool Ammo_2;
    public bool Ammo_3;
    public bool CanShoot;

    void Start()
    {
        SpawnWalls();
        SetUp();

    }

    void Update()
    {
        Shooting();
        
    }

    void SpawnWalls()
    {
        for (int i = 0; i < 360; i += NumOfSheilds_1)     //ring 1
        {
            var radius = 10f;
            var x = radius * Mathf.Cos(Mathf.Deg2Rad * i);
            var y = radius * Mathf.Sin(Mathf.Deg2Rad * i);
            Instantiate(SheildPrefab_1, new Vector3(x, 0, y), Quaternion.identity);
        }
        for (int i = 0; i < 360; i += NumOfSheilds_2)     //ring 2
        {
            var radius_2 = 15f;
            var x_2 = radius_2 * Mathf.Cos(Mathf.Deg2Rad * i);
            var y_2 = radius_2 * Mathf.Sin(Mathf.Deg2Rad * i);
            Instantiate(SheildPrefab_2, new Vector3(x_2, 0, y_2), Quaternion.identity);
        }
        for (int i = 0; i < 360; i += NumOfSheilds_3)     //ring 3
        {
            var radius_2 = 20f;
            var x_3 = radius_2 * Mathf.Cos(Mathf.Deg2Rad * i);
            var y_3 = radius_2 * Mathf.Sin(Mathf.Deg2Rad * i);
            Instantiate(SheildPrefab_3, new Vector3(x_3, 0, y_3), Quaternion.identity);
        }
    }

    void SetUp()
    {
        Aimer = GameObject.FindGameObjectWithTag("Aimer");
        Boss_Aimer = GameObject.FindGameObjectWithTag("Boss_Aimer");
        Player = GameObject.FindGameObjectWithTag("Player");
        ShootIntervals = 5f;
        RefillAmmo = 1;
        Ammo_1 = Ammo_2 = Ammo_3 = true;
        Ammo = 3;
    }

    void Shooting()
    {
        CanShoot = Player.GetComponent<Player>().CanShoot;
        //player
        if(CanShoot == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Ammo >= 1)
                {
                    Instantiate(PlayerBullet, Aimer.transform.position, Quaternion.identity);
                    Ammo = Ammo - 1;
                }

            }
        }
        
        
        if(Ammo < 3)
        {
            RefillAmmo -= Time.deltaTime;
            if (RefillAmmo <= 0)
            {
                Ammo = Ammo + 1;
                RefillAmmo = 1;
            }
        }

        if (Ammo <= 0)
        {
            Ammo_1 = Ammo_2 = Ammo_3 = false;
        }
        if(Ammo == 1)
        {
            Ammo_1 = true;
            Ammo_2 = Ammo_3 = false;
        }
        if (Ammo == 2)
        {
            Ammo_1 = Ammo_2 = true;
            Ammo_3 = false;
        }
        if (Ammo == 3)
        {
            Ammo_1 = Ammo_2 = Ammo_3 = true;
            
        }
        //Boss
        ShootIntervals -= Time.deltaTime;
        if (ShootIntervals <= 0)
        {
            Instantiate(BossBullet, Boss_Aimer.transform.position, Quaternion.identity);
            ShootIntervals = 2;
        }
    }
}
