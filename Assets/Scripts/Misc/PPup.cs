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
            other.gameObject.transform.SendMessage("HPup", 1);
            other.gameObject.transform.SendMessage("ChangeShoot", mode);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.position += new Vector3(0,-2 * Time.deltaTime,0);
    }
}
