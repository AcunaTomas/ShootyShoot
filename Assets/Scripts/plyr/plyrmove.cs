using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrmove : MonoBehaviour
{
    public Proyectiles balas;
    public int mode = 0;
    public GameManager manager;
    public float waittime = 0.2f;
    public float elapsed = 0f;
    public Transform trs;
    private float z = 6.95f;
    public int health = 3;

    void Start()
    {
        trs = GetComponent<Transform>();
        manager.initializetext(health);

    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= waittime)
        {
            Bulletgen(mode);
            elapsed = 0;
        }
    }

    void OnMouseDown()
    {
        
    }
    void OnMouseDrag() {
        Vector3 a = Input.mousePosition;
        a.z = 16.9576f; //Valor en z calibrado manualmente, este suele dar posiciones con menos error

        a = Camera.main.ScreenToWorldPoint(a);
        
        trs.position =  new Vector3(  a.x , a.y , z);

    }

    private void Bulletgen(int mod)
    {
        switch (mod)
        {
            case 1:
                tripleShoot();
                break;
            default:
                normalShoot();
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    private void Die()
    {
        health += -1;
        if (health <= 0)
        {
            Destroy(gameObject);
            manager.restart();
        }
        manager.UpdateHP(health);
    }

    private void normalShoot()
    {
        Proyectiles b = Instantiate(balas,trs.position + new Vector3(0,+1,0), balas.transform.rotation);
        b.gameObject.SetActive(true);
        b.target = "Enemy";
    }
    
    private void tripleShoot()
    {
        Proyectiles a = Instantiate(balas, trs.position + new Vector3(+1, +1, 0), balas.transform.rotation);
        a.gameObject.SetActive(true);
        a.target = "Enemy";
        Proyectiles b = Instantiate(balas, trs.position + new Vector3(0, +1, 0), balas.transform.rotation);
        b.gameObject.SetActive(true);
        b.target = "Enemy";
        Proyectiles c = Instantiate(balas, trs.position + new Vector3(-1, +1, 0), balas.transform.rotation);
        c.gameObject.SetActive(true);
        c.target = "Enemy";
    }
    
    
    
    private void HPup(int a)
    {
        health += a;
        manager.UpdateHP(health);
    }

    private void ChangeShoot(int a)
    {
        if (mode == 0)
        {
            StartCoroutine(TemporaryShoot(a));
        }

    }

    IEnumerator TemporaryShoot(int a)
    {
        mode = a;
        yield return new WaitForSeconds(15);
        mode = 0;
    }

}
