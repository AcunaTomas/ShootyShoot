using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnscale : MonoBehaviour
{
    RectTransform rectTrs;
    void Start()
    {

        rectTrs = GetComponent<RectTransform>();
        rectTrs.anchoredPosition = new Vector2(upgradeInit.playx, upgradeInit.playy);
        Debug.Log(rectTrs.anchoredPosition);
        

    }
}
