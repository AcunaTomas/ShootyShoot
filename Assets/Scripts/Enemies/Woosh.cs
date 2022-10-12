using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woosher : Generic //Update and Start set per enemy
{
    public plyrmove plyr;
    public float dirx = 2;
    public int spawningmode = 0;
    public bool attack;
    private Transform heli;
    void Start() //generic attribiutes set here: Score,Shooting frequency, Direction, etc. - Only use for overriding stuff
    {
        heli = transform.Find("Sphere.015").GetChild(0);
        StartCoroutine(Timeout());
        
    }
    void Update()
    {
        transform.position += new Vector3(0, dir * Time.deltaTime, 0);
        heli.Rotate(0f * Time.deltaTime, 0f * Time.deltaTime, 360f * Time.deltaTime, Space.Self);
    }




}
