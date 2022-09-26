using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Generic Enemy;
    public float spawningInterval;
    void Start()
    {
        InvokeRepeating("Spawn",0.5f,spawningInterval);
    }

    void Spawn()
    {
        Generic E = Instantiate(Enemy,Enemy.transform.position, Enemy.transform.rotation);
        E.gameObject.SetActive(true);
    }


}
