using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coptero : Generic //Update and Start set per enemy
{
    public float dirx = 2;
    public int spawningmode = 0;
    void Update()
    {
        swift += Time.deltaTime;
        if (swift >= 3f)
        {
            if (swift >=(timeout * 0.90f))
            {
                transform.position += new Vector3(dirx * Time.deltaTime, -dir * Time.deltaTime, 0);
            }


        }
        else
        {
            transform.position += new Vector3(0, dir * Time.deltaTime, 0);
        }

    }

    void Start() //generic attribiutes set here: Score,Shooting frequency, Direction, etc. - Only use for overriding stuff
    {

        StartCoroutine(Timeout());
        
    }
}
