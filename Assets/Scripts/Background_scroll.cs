using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_scroll : MonoBehaviour
{
    float scroll = 0f;
    public float mult = -0.01f;

    void Start()
    {

    }
    void Update()
    {
        scroll += mult;
        transform.position = new Vector3(transform.position.x, transform.position.y + mult, transform.position.z);
        if (scroll >= 8f || scroll <= -8f)
        {
            mult = mult *-1;
        }
    }
}
