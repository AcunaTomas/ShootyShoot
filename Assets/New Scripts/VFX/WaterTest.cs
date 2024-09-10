using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTest : MonoBehaviour
{
    private float _speed = 1f;

    public float _Speed
    {
        get { return _speed ;}
        set {_speed = value; print("mutate");}
    }


    void Start()
    {
        //_Speed = 2f;
    }

    void Update()
    {
        transform.position += new Vector3(_Speed * Time.deltaTime, _Speed * Time.deltaTime,0);
    }
}
