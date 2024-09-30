using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField]
    float defaultTimer = 0.8f;

    float timer = 0f;

    string SceneName = "";

    public void StartTransition(string Scene2Load)
    {    
        SceneName = Scene2Load;
        timer = defaultTimer;
    }

    void Update()
    {
        
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            return;    
        }
        if (SceneName != "")
        {
            SceneManager.LoadScene(SceneName);
        }

    }


}
