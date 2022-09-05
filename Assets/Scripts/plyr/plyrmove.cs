using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrmove : MonoBehaviour
{
    public Proyectiles balas;
    public Transform trs;
    private float z = 6.95f;

    void Start()
    {
        trs = GetComponent<Transform>();
        InvokeRepeating("Bulletgen",0.5f,0.2f);
    }

    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Hi");
    }
    void OnMouseDrag() {
        Vector3 a = Input.mousePosition;
        a.z = Camera.main.nearClipPlane;
        a = Camera.main.ScreenToWorldPoint(a);
        
        Debug.Log(a + "Mouse");
        Debug.Log(trs.position + "Object");
        trs.position =  new Vector3(  a.x * 30 , -6.95f, z);

    }

    void Bulletgen()
    {
        Proyectiles b = Instantiate(balas,trs.position, trs.rotation);
        b.gameObject.SetActive(true);
    }
}
