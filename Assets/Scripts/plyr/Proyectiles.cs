using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Timeout());
    }

    void Update()
    {
        transform.position += new Vector3( 0, 7 * Time.deltaTime, 0);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
