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
        for (int i = 0; i < transform.childCount; i++)
        {
            var original = transform.GetChild(i).gameObject;

            var E = Instantiate(original, original.transform.position, original.transform.rotation);

            E.gameObject.SetActive(true);
        }
        

    }

    private void Activate(string tag)
    {
        if (gameObject.CompareTag(tag))
        {
            gameObject.SetActive(true);
        }
    }
}
