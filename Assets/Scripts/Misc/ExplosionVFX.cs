using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 scaleChange = new Vector3(10f,10f, 10f);
    void Start()
    {
        transform.localRotation = Quaternion.Euler(Random.Range(-80, 80), 0, 0);
        StartCoroutine(TimeOut());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.01f * Time.deltaTime, 0);

        transform.localScale += scaleChange;
        scaleChange += new Vector3(-1, -1, -1);
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
