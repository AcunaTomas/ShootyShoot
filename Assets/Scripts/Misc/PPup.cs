using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPup : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0,-2 * Time.deltaTime,0);
    }
}
