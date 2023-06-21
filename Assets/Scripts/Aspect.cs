using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;


public class Aspect : MonoBehaviour
{
    Camera c; //Aspect Ratio Hack

    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
            Debug.Log("It works...?");
        }
        catch (ConsentCheckException conunacdespuesdelax)
        {
            Debug.Log("WARNING: CONSENT FAILED, CALL AUTHORITES");
        }

    } 

    void Awake()
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
        else if (Camera.main.aspect >= 0.44f) //9:20
        {
            upgradeInit.playx = 38.5f;
            upgradeInit.playy = -1080f;
        }
    }
}
