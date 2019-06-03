using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Player;
    public GameObject GameManager;

    public Image BossHealth;
    public Image BossSpecial;
    public Image StaminaBar;
    public Image JumpBar;
    public Image Ammo_1;
    public Image Ammo_2;
    public Image Ammo_3;

    private float BossHP_Value;
    private float BossSP_Value;
    private float Stamina_Value;
    private float JumpBar_Value;

    private bool Ammo_1_True;
    private bool Ammo_2_True;
    private bool Ammo_3_True;

    
    void Start()
    {
        SetUp();
    }


    void Update()
    {
        GetValues();
        SetValues();
    }

    void SetUp()
    {
        BossHealth = GameObject.Find("TheBossHealthBar").GetComponent<Image>();
        BossSpecial = GameObject.Find("BossSpecialBar").GetComponent<Image>();
        StaminaBar  = GameObject.Find("StaminaBar").GetComponent<Image>();
        JumpBar  = GameObject.Find("JumpBar").GetComponent<Image>();
        Ammo_1  = GameObject.Find("Ammo_1").GetComponent<Image>();
        Ammo_2  = GameObject.Find("Ammo_2").GetComponent<Image>();
        Ammo_3  = GameObject.Find("Ammo_3").GetComponent<Image>();

        Boss = GameObject.FindGameObjectWithTag("Center");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    void GetValues()
    {
        BossHP_Value = Boss.GetComponent<BossScript>().BossCurrentHealth;
        BossSP_Value = Boss.GetComponent<BossScript>().SpecialAttack;
        Stamina_Value = Player.GetComponent<Player>().Stamina;
        JumpBar_Value = Player.GetComponent<Player>().Jump;
    }
    void SetValues()
    {
        BossHealth.fillAmount = BossHP_Value;
        BossSpecial.fillAmount = BossSP_Value;
        StaminaBar.fillAmount = Stamina_Value;
        JumpBar.fillAmount = JumpBar_Value;
    
    }
}
