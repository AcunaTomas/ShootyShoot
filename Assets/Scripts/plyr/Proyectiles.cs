using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    public string target = "";
    public float direction = 7;
    public float directionx = 0;
    void Start()
    {
        StartCoroutine(Timeout());
    }

    void Update()
    {
        transform.Translate(directionx * Time.deltaTime, direction * Time.deltaTime, 0);
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == target)
        {
            other.transform.SendMessage("Die");
            Destroy(gameObject);
        }
        
    }
    public void setColors()
    {
        var cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
