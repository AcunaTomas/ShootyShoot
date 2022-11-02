using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Playbtn : MonoBehaviour
{
    public TextMeshProUGUI thistext;
    public GameObject background;
    public GameObject Menu;
    public GameObject opti;
    public GameManager gman;
    public GameObject cont;

    private bool show = true;

    private float volume = 0f;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void next() //Shoddy Implementation, I know - Upgrades for only the first 2 levels
    {
        if (gman.getNext() == "2" || gman.getNext() == "3")
        {
            gman.upgrade();
        }
        else
        {
            nextlvl();
        }

    }

    private void nextlvl()
    {
        string a = gman.getNext();
        if (a == "Menu")
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            SceneManager.LoadScene("Level " + a);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void menu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void pause()
    {
        Time.timeScale = 0;
        background.SetActive(true);
        Menu.SetActive(true);
        cont.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale = 1;
        background.SetActive(false);
        Menu.SetActive(false);
        cont.SetActive(false);
    }

    public void shot()
    {
        gman.moreShot();
        nextlvl();
    }

    public void size()
    {
        gman.moreSize();
        nextlvl();
    }


    public void options()
    {
        opti.SetActive(show);
        show = !show;
    }

    public void sound()
    {
        AudioListener.volume = volume;
        if (volume == 1)
        {
            volume = 0;
            thistext.text = "Sound On";
        }
        else
        {
            volume = 1;
            thistext.text = "Sound Off";
        }
    }
}

