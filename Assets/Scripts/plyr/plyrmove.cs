using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrmove : MonoBehaviour
{

    public Proyectiles balas;
    public int mode = 1;
    public GameManager manager;
    private float waittime = 0.2f;
    private float wideness = 0.5f;
    public float elapsed = 0f;
    public Transform trs;
    private float z = 6.95f;
    public int health = 3;

    private Transform spin;

    void Start()
    {
        waittime = upgradeInit.shot;
        wideness = upgradeInit.size;
        Debug.Log(waittime);
        Debug.Log(wideness);
        trs = GetComponent<Transform>();
        spin = trs.Find("Plane");
        manager.initializetext(health);

    }

    void Update()
    {
        elapsed += Time.deltaTime;
        spin.Rotate(0f * Time.deltaTime, 360f * Time.deltaTime, 0f * Time.deltaTime, Space.Self);
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
        if (a.x > 0)
        {
            trs.rotation = Quaternion.Euler(-90,0,-20);
        }
        else if (a.x < 0)
        {
            trs.rotation = Quaternion.Euler(-90,0,20); 
        }
        else
        {
            trs.rotation = Quaternion.Euler(-90,0,0); 
        }

    }

    private void Bulletgen(int mod)
    {
        switch (mod)
        {
            case 1:
                tripleShoot();
                break;
            case 2:
                fastShoot();
                break;
            case 3:
                wideShot();
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
        Proyectiles a = Instantiate(balas, trs.position + new Vector3(+0.5f, +1, 0), balas.transform.rotation);
        a.gameObject.SetActive(true);
        a.target = "Enemy";
        Proyectiles b = Instantiate(balas, trs.position + new Vector3(0, +1, 0), balas.transform.rotation);
        b.gameObject.SetActive(true);
        b.target = "Enemy";
        Proyectiles c = Instantiate(balas, trs.position + new Vector3(-0.5f, +1, 0), balas.transform.rotation);
        c.gameObject.SetActive(true);
        c.target = "Enemy";
    }
    
    private void fastShoot()
    {
        Proyectiles a = Instantiate(balas, trs.position + new Vector3(0, +1, 0), balas.transform.rotation);
        a.gameObject.SetActive(true);
        a.target = "Enemy";
        a.direction = 11;
    }

    private void wideShot()
    {
        Proyectiles a = Instantiate(balas, trs.position + new Vector3(0, +1, 0), balas.transform.rotation);
        a.gameObject.SetActive(true);
        a.transform.localScale = new Vector3(wideness,0.41f,0.0678454f);
        a.target = "Enemy";
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
        else if (mode != a)
        {
            StopCoroutine(TemporaryShoot(a));
            StartCoroutine(TemporaryShoot(a));
        }

    }

    IEnumerator TemporaryShoot(int a)
    {
        mode = a;
        yield return new WaitForSeconds(15);
        mode = 0;
    }

    public void shot()
    {
        upgradeInit.shot += -0.05f;
    }
    public void size()
    {
        upgradeInit.size += 0.1f;
    }

}
