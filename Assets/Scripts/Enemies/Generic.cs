using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    private int type = 1;
    public Proyectiles Bala;
    private int hp = 4;
    public float dir = -4f;
    public float swift = 0f;
    public float time = 0.05f;

    public int getType()
    {
        return type;
    }

    void Start()
    {
        StartCoroutine(Timeout());
        InvokeRepeating("Attack", 2f, 2f);
    }

   void Update()
    {
        swift += time;
        if (swift <= -14f || swift >= 14f)
        {
            dir = dir * -1;
            time = time * -1;


        }
        transform.position += new Vector3( 0, dir * Time.deltaTime, 0);
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(6);
        transform.position += new Vector3( -4 * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(3);
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

    private void Attack()
    {
        Proyectiles a = Instantiate(Bala, transform.position, Bala.transform.rotation);
        a.direction = -7;
        a.target = "Player";
        a.gameObject.SetActive(true);
    }

}
