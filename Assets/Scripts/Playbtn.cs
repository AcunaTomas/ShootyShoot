using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playbtn : MonoBehaviour
{
    public GameObject background;
    public GameObject Menu;

    public GameManager gman;
    public GameObject cont;
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void next()
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
}

