using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShmupPlus;


public class Mine : Enemy
{

    [Header("Set Dynamically: Mine")]

    public Vector3[] points;

    public float birthTime;

    public float maxLifetime;

    // Start is called before the first frame update
    void Start()
    {
        birthTime = Time.time;
        maxLifetime = birthTime + maxLifetime;
    }

    public override void Move()
    {

        if (Time.time > maxLifetime)
        {


            // This Mine has finished its life


            Destroy(this.gameObject);                                      // d


            return;


        }

    }
}
