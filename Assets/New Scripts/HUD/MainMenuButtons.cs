using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    private Camera Camera;
    void Awake()
    {
        Camera = GetComponent<Camera>();
    }
    void OnGUI()
    {
        Event m_Event = Event.current;
        if (m_Event.type == EventType.MouseDown) Click();
/*         Vector3 mpos = Input.mousePosition;
        mpos.z = 16.9576f;
        RaycastHit hit;
        Physics.Raycast(Camera.ScreenToWorldPoint(mpos), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
        hit.collider.gameObject.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
        Debug.Log(hit.collider);
         Debug.DrawRay(Camera.ScreenToWorldPoint(mpos), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        //Debug.Log(Camera.ScreenToWorldPoint(mpos)); */
    }

    void Click()
    {
        Vector3 mpos = Input.mousePosition;
        mpos.z = 16.9576f;
        RaycastHit hit;
        Physics.Raycast(Camera.ScreenToWorldPoint(mpos), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
        hit.collider.gameObject.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
        Debug.Log(hit.collider);
         Debug.DrawRay(Camera.ScreenToWorldPoint(mpos), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        
    }
}
