using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider))]
public class TresDMenuButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Play()
    {
        print("You have presionado el boton bolar");
        transform.localPosition = new Vector3(0,0,0.0091f);
    }
}
