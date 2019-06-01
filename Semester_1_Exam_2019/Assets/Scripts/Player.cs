using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Center;
    public GameObject PlayerPointer;

    public Transform CurrentPosition;

    public Vector3 TargetPosition;

    public float OrbitSpeed;
    public float Smooth;
    public float Z;

    public bool IsJumping;
    public bool IsRotating;
    public bool JumpCorrect;
    
    void Start()
    {
        SetUp();
    }
    

    void Update()
    {
        Movement();
        Jump();

      
    }



    void Movement()
    {
        CurrentPosition = this.transform;
        float Dist = Vector3.Distance(CurrentPosition.position, TargetPosition);

        if (IsJumping == false)
        {
            float HDirect = Input.GetAxis("Horizontal");
            PlayerPointer.transform.RotateAround(Center.transform.position, new Vector3(0, 1, 0), -HDirect);
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
       
            
            
          
       

           


            
           //Quaternion target = Quaternion.Euler(0, 0, 180);
           //transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * Smooth);


           

        }

        if(Dist <= 0.5)
        {
            IsJumping = false;
          //  PlayerPointer.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TargetPosition = -this.transform.position;
            IsJumping = true;
            IsRotating = true;
            JumpCorrect = !JumpCorrect;
        }
    }

    void SetUp()
    {
        Center = GameObject.FindGameObjectWithTag("Center");
        PlayerPointer = GameObject.FindGameObjectWithTag("PlayerPointer");

        Z = 0f;

        IsJumping = false;
        JumpCorrect = true;
    }
}
