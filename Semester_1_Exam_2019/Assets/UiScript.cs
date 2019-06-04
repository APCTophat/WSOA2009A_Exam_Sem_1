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

    void SetUp()     //finds all relevant GameObjects that is needed in the script for referencing
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

    void GetValues()       //gets the values from other scripts and sets them to variables in this script
    {
        BossHP_Value = Boss.GetComponent<BossScript>().BossCurrentHealth;
        BossSP_Value = Boss.GetComponent<BossScript>().CurrentSpecialAttack;
        Stamina_Value = Player.GetComponent<Player>().CurrentStamina;
        JumpBar_Value = Player.GetComponent<Player>().CurrentJump;

        Ammo_1_True = GameManager.GetComponent<GameManager>().Ammo_1;
        Ammo_2_True = GameManager.GetComponent<GameManager>().Ammo_2;
        Ammo_3_True = GameManager.GetComponent<GameManager>().Ammo_3;
    }
    void SetValues()
    {
        BossHealth.fillAmount = BossHP_Value;
        BossSpecial.fillAmount = BossSP_Value;
        StaminaBar.fillAmount = Stamina_Value;
        JumpBar.fillAmount = JumpBar_Value;

        Ammo_1.enabled = Ammo_1_True;
        Ammo_2.enabled = Ammo_2_True;
        Ammo_3.enabled = Ammo_3_True;
    
    }
}
