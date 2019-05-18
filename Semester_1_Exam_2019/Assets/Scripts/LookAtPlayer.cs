using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject Player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Target = Player.transform.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 NewDirection = Vector3.RotateTowards(transform.forward, Target, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(NewDirection);
    }
}
