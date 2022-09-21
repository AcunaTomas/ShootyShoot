using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coptero : Generic //Update and Start set per enemy
{
    public float dirx = 2;
    void Update()
    {
        swift += time;
        if (swift >= 10f)
        {
            if (swift >=20f)
            {
                transform.position += new Vector3(dirx * Time.deltaTime, -dir * Time.deltaTime, 0);
            }


        }
        else
        {
            transform.position += new Vector3(0, dir * Time.deltaTime, 0);
        }

    }

    void Start() //generic attribiutes set here: Score,Shooting frequency, Direction, etc.
    {

        StartCoroutine(Timeout());
        InvokeRepeating("Attack", 2f, 2f);
        score = 55;
        hp = 8;
    }
}
