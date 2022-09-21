using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour
{

void Start()
    {
        StartCoroutine(Timeout());
    }
    public string target = "";
    public float direction = 7;

    void Update()
    {
        transform.position += new Vector3( 0, direction * Time.deltaTime, 0);
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
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
