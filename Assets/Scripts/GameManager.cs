using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextlevel = "1";
    public txt texto;
    public txt scor;
    public txt hp;
    public int scoregoal = 300;
    private string endtext = "GAME OVER \n YEAH!!!";
    private float lvlduration = 90f;

    public GameObject nextlvl;
    public GameObject restartbtn;

    public plyrmove plyr;

    public GameObject menu;
    public GameObject background;

    public GameObject upg1;
    public GameObject upg2;

    public GameObject pauseah;

    public AudioSource ded;
    public int score;

    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
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
        ded.Play();
        score += s;
        scor.text.text = "Score: " + score;

    }
    IEnumerator xd()
    {
        yield return new WaitForSeconds(1);
        texto.gameObject.SetActive(true);
        texto.text.text = endtext;
        background.SetActive(true);
        menu.SetActive(true);
        restartbtn.SetActive(true);

        Time.timeScale = 0;
    }

    IEnumerator xdw()
    {
        yield return new WaitForSeconds(1);
        texto.gameObject.SetActive(true);
        texto.text.text = endtext;
        background.SetActive(true);
        menu.SetActive(true);
        nextlvl.SetActive(true);
        Time.timeScale = 0;
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
            else
            {
                b.SetActive(false);
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
        for (int i = 0; i < transform.childCount; i++)
        {
            var b = transform.GetChild(i).gameObject;
            b.SetActive(false);
        }
        endtext = "YOUR WINNER!";
        yield return new WaitForSeconds(5);
        pauseah.SetActive(false);
        StartCoroutine(xdw());
    }

    public string getNext()
    {
        return nextlevel;
    }

    public void upgrade()
    {
        texto.text.text = "Choose an Upgrade";
        menu.SetActive(false);
        nextlvl.SetActive(false);
        upg1.SetActive(true);
        upg2.SetActive(true);
    }

    //A disaster of an upgrade system - hope it works
    public void moreShot()
    {
        plyr.shot();
    }
    public void moreSize()
    {
        plyr.size();
    }
}
