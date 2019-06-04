using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackScript : MonoBehaviour
{
    public float X;
    public float Y;

    private void Start()
    {
        X = 1;
        Y = 1;
    }

    private void Update()
    {
        X += Time.deltaTime * 5;
        Y += Time.deltaTime * 5;

        this.transform.localScale = new Vector3(X, Y, 10);


        if(X >= 30)
        {
            Destroy(gameObject);
        }
    }
}
