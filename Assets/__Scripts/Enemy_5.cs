using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShmupPlus;


public class Enemy_5 : Enemy
{

    [Header("Set in Inspector: Enemy_5")]

    public float sinEccentricity = 0.6f;

    public float lifeTime = 8;

    public float firstMineTime = 2;

    public float secondMineTime = 4;

    public float thirdMineTime = 6;

    public GameObject minePrefab;

    [Header("Set Dynamically: Enemy_5")]

    public Vector3 p0;

    public Vector3 p1;

    public Vector3[] points;

    public float birthTime;

    public float mineLayingInterval1;

    public float mineLayingInterval2;

    public float mineLayingInterval3;

    // Again, Start works well because it is not used by the Enemy superclass


    void Start()
    {



        // Pick any point on the left side of the screen


        p0 = Vector3.zero;                                                   // b


        p0.x = -bndCheck.camWidth - bndCheck.radius;


        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);




        // Pick any point on the right side of the screen


        p1 = Vector3.zero;


        p1.x = bndCheck.camWidth + bndCheck.radius;


        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);




        // Possibly swap sides


        if (Random.value > 0.5f)
        {


            // Setting the .x of each point to its negative will move it to


            //   the other side of the screen


            p0.x *= -1;


            p1.x *= -1;


        }




        // Set the birthTime to the current time


        birthTime = Time.time;                                               // c

        StartCoroutine(PlaceMine1());

        StartCoroutine(PlaceMine2());

        StartCoroutine(PlaceMine3());

        //float mineLayingInterval2 = birthTime + secondMineTime;

        //float mineLayingInterval3 = birthTime + thirdMineTime;
    }



    public void placeMine()
    {
        GameObject mineExploder = Instantiate<GameObject>(minePrefab);

        mineExploder.transform.position = transform.position;

        Rigidbody rigidB = mineExploder.GetComponent<Rigidbody>();

    }

    IEnumerator PlaceMine1()
    {
        yield return new WaitForSeconds(mineLayingInterval1);
        placeMine();
    }

    IEnumerator PlaceMine2()
    {
        yield return new WaitForSeconds(mineLayingInterval2);
        placeMine();
    }

    IEnumerator PlaceMine3()
    {
        yield return new WaitForSeconds(mineLayingInterval3);
        placeMine();
    }

    public override void Update()
    {
        Move();

        if (showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }

        if (bndCheck != null && bndCheck.offDown)
        {
            // We're off the bottom, so destroy this GameObject
            Destroy(gameObject);
        }
        if (Time.time == mineLayingInterval1)
        {
            placeMine();
        }
        if (Time.time == mineLayingInterval2)
        {
            placeMine();
        }
        if (Time.time == mineLayingInterval3)
        {
            placeMine();
        }
    }

    public override void Move()
    {


        // Bezier curves work based on a u value between 0 & 1


        float u = (Time.time - birthTime) / lifeTime;




        // If u>1, then it has been longer than lifeTime since birthTime


        if (u > 1)
        {


            // This Enemy_2 has finished its life


            Destroy(this.gameObject);                                      // d


            return;


        }




        // Adjust u by adding a U Curve based on a Sine wave


        u = u + sinEccentricity * (Mathf.Sin(u * Mathf.PI * 2));




        // Interpolate the two linear interpolation points


        pos = (1 - u) * p0 + u * p1;


    }

}