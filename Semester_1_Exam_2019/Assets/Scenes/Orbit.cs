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

    public float OrbitSpeed;
    



    void Start()
    {
        //transform.LookAt(Center.transform);
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Center.transform);
        //float HDirect = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(HDirect * 10, rb.velocity.y, rb.velocity.z);

        transform.RotateAround(Center.transform.position, new Vector3(X_axis,Y_axis,0), OrbitSpeed * Time.deltaTime);
     }  
}
