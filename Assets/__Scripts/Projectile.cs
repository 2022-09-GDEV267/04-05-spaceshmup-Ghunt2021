using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header("Set In Inspector")]


    [Header("Set Dynamically")]



    private BoundsCheck bndCheck;



    void Awake()
    {

        bndCheck = GetComponent<BoundsCheck>();

    }


    void Update()
    {

        if (bndCheck.offUp)
        {                                                // a

            Destroy(gameObject);

        }


    }
}
