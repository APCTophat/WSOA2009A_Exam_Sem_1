using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject Center;
    public GameObject Player;

  public Rigidbody rb;

    public int X_axis;
    public int Y_axis;
    public int Z_axis;


    public float OrbitSpeed;
    



    void Start()
    {
        Center = GameObject.FindGameObjectWithTag("Center");
       rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Sheild_1")
        {
            transform.RotateAround(Center.transform.position, new Vector3(X_axis, Y_axis, Z_axis), OrbitSpeed * Time.deltaTime);
        }
        if(gameObject.tag == "Sheild_2")
        {
            transform.RotateAround(Center.transform.position, new Vector3(X_axis, Y_axis, Z_axis), -OrbitSpeed * Time.deltaTime);
        }
       
     }  
}
