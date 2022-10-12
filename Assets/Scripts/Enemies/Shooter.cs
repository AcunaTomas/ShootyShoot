using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Generic //Update and Start set per enemy
{
    public plyrmove plyr;
    public float dirx = 2;
    public int spawningmode = 0;
    private Transform mouth;
    void Update()
    {
        swift += Time.deltaTime;
        if (swift <= 3f)
        {
            transform.position += new Vector3(0, dir * Time.deltaTime, 0);


        }
        else if (swift <= (timeout * 0.85f))
        {
            
        }
        else
        {
            transform.position += new Vector3(-dirx * Time.deltaTime, -dir * Time.deltaTime, 0);
        }

    }

    void Start() //generic attribiutes set here: Score,Shooting frequency, Direction, etc. - Only use for overriding stuff
    {
        mouth = transform.Find("Sphere.001");
        StartCoroutine(Timeout());
        InvokeRepeating("Attack", 2f, 2f);
    }


    private void Attack()
    {
        StartCoroutine(mouthMove());
        Proyectiles a = Instantiate(Bala, transform.position, Bala.transform.rotation);
        a.direction = -7;
        a.directionx = plyr.trs.position.x * 0.4f;
        a.target = "Player";
        a.setColors();
        a.gameObject.SetActive(true);
        
    }

    IEnumerator mouthMove()
    {
        mouth.position += new Vector3(0f,-0.5f,0);
        yield return new WaitForSeconds(0.3f);
        mouth.position += new Vector3(0f,0.5f,0);
    }
}
