using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Center;

    public Transform player;
    public Transform Camera;

    public Vector3 offset;

    public float speed = 1.0f;

  



    // Update is called once per frame
    void LateUpdate()
    {
       
        
            Vector3 CamPos = player.position + offset;                                   //where the camera wants to go
            Vector3 MoveCam = Vector3.Lerp(transform.position, CamPos, speed);            //a distance between two points as its own vector
            transform.position = MoveCam;
            transform.rotation = player.rotation;
            //transform.LookAt(Center.transform);

            Quaternion FinalRot = Quaternion.LookRotation(Center.transform.position - Camera.transform.position);    //SmoothLookat unity
            Camera.transform.rotation = Quaternion.Slerp(Camera.transform.rotation, FinalRot, speed);

          
        
           
    }
    
}
