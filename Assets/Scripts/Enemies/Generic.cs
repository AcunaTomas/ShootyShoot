using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    private int type = 1;
    private int hp = 4;


    public int getType()
    {
        return type;
    }

    void Start()
    {
        StartCoroutine(Timeout());
    }

    void Update()
    {
        transform.position += new Vector3( 0, -7 * Time.deltaTime, 0);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    private void Die()
    {
        if (hp == 0)
        {
           Destroy(gameObject); 
        }
        hp += -1;
        
    }

}
