using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int NumOfSheilds_1;
    public int NumOfSheilds_2;
    public int NumOfSheilds_3;
    public int Ammo;

    public float ShootIntervals;
    public float ShootInterValsVariable;
    public float RefillAmmo;
    public float RefillAmmoVariable;

    public GameObject SheildPrefab_1;
    public GameObject SheildPrefab_2;
    public GameObject SheildPrefab_3;
    public GameObject PlayerBullet;
    public GameObject BossBullet;
    public GameObject Aimer;
    public GameObject Boss_Aimer;
    public GameObject Player;
    public GameObject TheBoss;
    public GameObject GameOver;
    public GameObject GameWon;

    public bool Ammo_1;
    public bool Ammo_2;
    public bool Ammo_3;
    public bool CanShoot;
    public bool InLevel_1;
    public bool InLevel_2;
    public bool InLevel_3;

    public string sceneName;

    void Start()
    {
        SpawnWalls();
        
    }
    private void Awake()
    {
        SceneCheck();
        SetUp();
    }

    void Update()
    {
        Shooting();
        CheatSheet();
    }

    void SpawnWalls()    //spawn the walls dependant on what level the player is on, just spawns the walls in the correct position and radius size
    {
        if(InLevel_1 == true)
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
        }
        if(InLevel_2 == true)
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
        if (InLevel_3 == true)
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

    }

    void SetUp()        //spawns the Boss, Player, gets gameobjects for reference and sets variables.
    {
        Instantiate(TheBoss, Vector3.zero, Quaternion.identity);
        Instantiate(Player, new Vector3(0, 0, -25), Quaternion.identity);

        Aimer = GameObject.FindGameObjectWithTag("Aimer");
        Boss_Aimer = GameObject.FindGameObjectWithTag("Boss_Aimer");
        Player = GameObject.FindGameObjectWithTag("Player");

        Ammo_1 = Ammo_2 = Ammo_3 = true;         //constant variables not dependant on level
        Ammo = 3;

        if(InLevel_1 == true)                   //variables dependent on level
        {
            ShootInterValsVariable = 2f;
            RefillAmmoVariable = 1f;
        }
        if (InLevel_2 == true)
        {
            ShootInterValsVariable = 1.5f;
            RefillAmmoVariable = 1.5f;
        }
        if (InLevel_3 == true)
        {
            ShootInterValsVariable = 1f;
            RefillAmmoVariable = 2f;
        }
        ShootIntervals = ShootInterValsVariable;
        RefillAmmo = RefillAmmoVariable;

        GameWon.SetActive(false);
    }

    void Shooting()
    {
        CanShoot = Player.GetComponent<Player>().CanShoot;
        //player
        if(CanShoot == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
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
                RefillAmmo = RefillAmmoVariable;
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
            ShootIntervals = ShootInterValsVariable;
        }
    }

    void SceneCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Level_1")
        {
            InLevel_1 = true;
        }
        else
        {
            if(sceneName == "Level_2")
            {
                InLevel_2 = true;
            }
            else
            {
                if(sceneName == "Level_3")
                {
                    InLevel_3 = true;
                }
            }
        }
        Time.timeScale = 1f;

    }

    void CheatSheet()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level_1");
        }
        if (Time.timeScale == 0f)
        {
            GameOver.SetActive(true);
        }
    }

    void NextLevel()
    {
        if(sceneName == "Level_1" || sceneName == "Level_2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(sceneName == "Level_3")
        {
            GameWon.SetActive(true);
        }
      
    }
}
