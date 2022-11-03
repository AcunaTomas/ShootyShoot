using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 scaleChange = new Vector3(2f, 2f, 2f);
    void Start()
    {
        StartCoroutine(TimeOut());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.01f * Time.deltaTime, 0);
        transform.localScale += scaleChange;
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
