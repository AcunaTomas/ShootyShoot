using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_scroll : MonoBehaviour
{
    float scroll = 0f;
    private float mult = -0.5f;

    void Start()
    {

    }
    void Update()
    {
        scroll += mult * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + (mult * Time.deltaTime), transform.position.z);
        if (scroll >= 60f || scroll <= -60f)
        {
            mult = mult *-1;
        }
    }
}
