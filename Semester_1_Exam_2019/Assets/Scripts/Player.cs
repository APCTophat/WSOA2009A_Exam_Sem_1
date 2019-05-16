using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Center;

    public float OrbitSpeed;
    
    void Start()
    {
        
    }
    

    void Update()
    {
        float HDirect = Input.GetAxis("Horizontal");
        transform.RotateAround(Center.transform.position, new Vector3(0, 1 , 0), -HDirect);
    }
}
