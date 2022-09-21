using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public txt texto;
    public txt scor;
    public txt hp;

    private int score;

    void Start()
    {
        Application.targetFrameRate = 60;

    }

    public void initializetext(int s)
    {
        hp.text.text= "HP: " + s;
        scor.text.text = "Score:"; //This triggers a null reference exception and idk why
    }

    public void UpdateHP(int s)
    {
        hp.text.text= "HP: " + s;
    }
    public void restart()
    {
        StartCoroutine(xd());
        
        
    }

    private void Score(int s)
    {
        Debug.Log("score");
        score += s;
        scor.text.text = "Score: " + score;
    }
    IEnumerator xd()
    {
        yield return new WaitForSeconds(1);
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
