﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int NumOfSheilds;

    public GameObject SheildPrefab_1;
    public GameObject SheildPrefab_2;
    public GameObject PlayerBullet;
    public GameObject BossBullet;

    void Start()
    {
        for (int i = 0; i < 360; i += NumOfSheilds)     //ring 1
        {
            var radius = 10f;
            var x = radius * Mathf.Cos(Mathf.Deg2Rad * i);
            var y = radius * Mathf.Sin(Mathf.Deg2Rad * i);
            Instantiate(SheildPrefab_1,new Vector3(x,0,y) , Quaternion.identity);
        }
        for (int i = 0; i < 360; i += NumOfSheilds)     //ring 2
        {
            var radius_2 = 15f;
            var x_2 = radius_2 * Mathf.Cos(Mathf.Deg2Rad * i);
            var y_2 = radius_2 * Mathf.Sin(Mathf.Deg2Rad * i);
            Instantiate(SheildPrefab_2, new Vector3(x_2, 0, y_2), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(PlayerBullet, new Vector3(0, 20, 0), Quaternion.identity);
        }
    }
}
