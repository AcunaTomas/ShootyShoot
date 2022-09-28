using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPup : MonoBehaviour
{
    public int mode = 1;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(0,-2 * Time.deltaTime,0);
    }
}
