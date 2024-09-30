using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider))]
public class TresDMenuButton : MonoBehaviour
{
    public UnityEvent OnclickCallBack;
    float timer = 0f;
    bool ButtonEnabled = true;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            ButtonEnabled = true;
            //transform.localPosition = new Vector3(0,0,0.01032368f);
        }
    }

    void Play()
    {
        if (!ButtonEnabled)
        {
            return;
        }
        print("You have presionado el boton bolar");
        //transform.localPosition = new Vector3(0,0,0.0091f);
        timer =  0.8f;
        ButtonEnabled = false;
        OnclickCallBack.Invoke();
    }
}
