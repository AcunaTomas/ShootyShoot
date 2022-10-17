using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour
{
    Camera c; //Aspect Ratio Hack
    void Start()
    {
        c = GetComponent<Camera>();

        Debug.Log(Camera.main.aspect);
        if (Camera.main.aspect >= 0.56f) //9:16
        {
            
            upgradeInit.playx = 38.5f;
            upgradeInit.playy = -850f;
        }
        else if (Camera.main.aspect >= 0.50f) //9:18
        {
            upgradeInit.playx = 38.5f;
            upgradeInit.playy = -980f;
        }
        else if (Camera.main.aspect >= 0.45f) //9:20
        {
            upgradeInit.playx = 38.5f;
            upgradeInit.playy = -1080f;
        }
    }
}
