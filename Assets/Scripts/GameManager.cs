using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public txt texto;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void restart()
    {
        StartCoroutine(xd());
        texto.gameObject.SetActive(true);
        
    }

    IEnumerator xd()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
