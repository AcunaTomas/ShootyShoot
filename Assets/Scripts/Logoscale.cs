using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logoscale : MonoBehaviour
{
    RectTransform rectTrs;
    void Start()
    {
        rectTrs = GetComponent<RectTransform>();
        rectTrs.anchoredPosition = new Vector2(upgradeInit.logox, upgradeInit.logoy);
        Debug.Log(rectTrs.anchoredPosition);

    }

}
