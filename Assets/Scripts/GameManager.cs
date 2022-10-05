using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public txt texto;
    public txt scor;
    public txt hp;
    public int scoregoal = 300;
    private string endtext = "GAME OVER YEAH!!!";
    private float lvlduration = 90f;


    public int score;

    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(LvlTimelimit(lvlduration));
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
       /* if (score >= scoregoal)
        {
            endtext = "YOUR WINNER!";
            restart();
        } */
    }
    IEnumerator xd()
    {
        yield return new WaitForSeconds(1);
        texto.gameObject.SetActive(true);
        texto.text.text = endtext;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator LvlTimelimit(float a) //Controls level flow, divided in 3 parts, beginning, middle and end
    {
        yield return new WaitForSeconds(a/3);
        Debug.Log("First Third Reached");
        for (int i = 0; i < transform.childCount; i++)
        {
            var b = transform.GetChild(i).gameObject;
            if (b.CompareTag("Middle") == true)
            {
                b.SetActive(true);
            }
        }
        yield return new WaitForSeconds(a / 3);
        Debug.Log("Second Third Reached");
        for (int i = 0; i < transform.childCount; i++)
        {
            var b = transform.GetChild(i).gameObject;
            if (b.CompareTag("End") == true)
            {
                b.SetActive(true);
            }
            else
            {
                b.SetActive(false);
            }
        }
        yield return new WaitForSeconds(a / 3);
        endtext = "YOUR WINNER!";
        restart();
    }
}
