using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Generic //Update and Start set per enemy
{
    public plyrmove plyr;
    public float dirx = 2;
    public int spawningmode = 0;
    void Update()
    {
        swift += time;
        if (swift >= 10f)
        {



        }
        else
        {
            transform.position += new Vector3(0, dir * Time.deltaTime, 0);
        }

    }

    void Start() //generic attribiutes set here: Score,Shooting frequency, Direction, etc. - Only use for overriding stuff
    {

        StartCoroutine(Timeout());
        InvokeRepeating("Attack", 2f, 2f);
    }


    private void Attack()
    {
        Proyectiles a = Instantiate(Bala, transform.position, Bala.transform.rotation);
        a.direction = -7;
        a.directionx = plyr.trs.position.x * 0.4f;
        a.target = "Player";
        a.setColors();
        a.gameObject.SetActive(true);
    }
}
