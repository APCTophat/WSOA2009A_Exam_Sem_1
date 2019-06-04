using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Center;
    public GameObject PlayerPointer;

    public Transform CurrentPosition;
    public Transform CurPos;
    public Transform latePos;

    public Vector3 TargetPosition;

    public float OrbitSpeed;
    public float Smooth;
    public float Z;
    public float Stamina;
    public float StaminaMax;
    public float CurrentStamina;
    public float JumpReady;
    public float JumpMax;
    public float CurrentJump;

    public bool IsJumping;
    public bool IsRotating;
    public bool JumpCorrect;
    public bool CanShoot;
    
    
    void Start()
    {
        SetUp();
    }
    

    void Update()
    {
        Movement();
        Jump();
        TheStamina();
    }



    void Movement()
    {
        CurrentPosition = this.transform;
        float Dist = Vector3.Distance(CurrentPosition.position, TargetPosition);

        if (IsJumping == false)
        {
            float HDirect = Input.GetAxis("Horizontal");
            if(Stamina >= 1)
            {
                PlayerPointer.transform.RotateAround(Center.transform.position, new Vector3(0, 1, 0), -HDirect);
            }
           
            if(HDirect != 0)
            {
                Stamina -= Time.deltaTime * 10;
            }
            if(HDirect == 0)
            {
                Stamina += Time.deltaTime * 3;
            }
        }
      

        if(IsJumping == true)
        {
            if(JumpCorrect == false)
            {
                PlayerPointer.transform.RotateAround(Center.transform.position, PlayerPointer.transform.right, 1);
                if (IsRotating == true)
                {
                    Z += Time.deltaTime * Smooth;
                    if (Z > 180)
                    {
                        Z = 180;
                        IsRotating = false;
                    }
                }
                transform.localRotation = Quaternion.Euler(0, 0, -Z);
            }
            if(JumpCorrect == true)
            {
                PlayerPointer.transform.RotateAround(Center.transform.position, -PlayerPointer.transform.right, 1);
                if (IsRotating == true)
                {
                    Z -= Time.deltaTime * Smooth;
                    if (Z < 0)
                    {
                        Z = 0;
                        IsRotating = false;
                    }
                }
                transform.localRotation = Quaternion.Euler(0, 0, -Z);
            }
        }

        if(Dist <= 0.5)
        {
            IsJumping = false;
          
        }
    }

    void Jump()
    {
        CurrentJump = JumpReady / JumpMax;
        JumpReady += Time.deltaTime;
        if(JumpReady >= JumpMax)
        {
            JumpReady = JumpMax;
        }
        if(IsJumping == false)
        {
            if(Stamina >= 25 && JumpReady == JumpMax)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    TargetPosition = -this.transform.position;
                    IsJumping = true;
                    IsRotating = true;
                    JumpCorrect = !JumpCorrect;
                    Stamina = Stamina - 25;
                    JumpReady = 0;
                }
            }
            
        }

        if(IsJumping == true)
        {
            CanShoot = false;
        }
        else
        {
            CanShoot = true;
        }
      
    }

    void SetUp()
    {
        Center = GameObject.FindGameObjectWithTag("Center");
        PlayerPointer = GameObject.FindGameObjectWithTag("PlayerPointer");

        Z = 0f;

        IsJumping = false;
        JumpCorrect = true;

        StaminaMax = 100;
        Stamina = StaminaMax;

        JumpMax = 5;
        JumpReady = JumpMax;
    }

    void TheStamina()
    {
        CurrentStamina = Stamina / StaminaMax;
        Stamina += Time.deltaTime * 3;
        if (Stamina >= StaminaMax)
        {
            Stamina = StaminaMax;
        }
        if(Stamina <= 0)
        {
            Stamina = 0;
        }
    }
}
