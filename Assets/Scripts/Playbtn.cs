using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class Playbtn : MonoBehaviour
{
    public TextMeshProUGUI thistext;
    public GameObject background;
    public GameObject Menu;
    public GameObject opti;
    public GameManager gman;
    public GameObject cont;
    private bool state = true;

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
        Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"level_index", upgradeInit.level},
                {"points", upgradeInit.score},
                {"upgrade_choice", upgradeInit.chosenUpgrade},
                {"powerup_obtained", upgradeInit.powerup_obtained}
            };
        Debug.Log(parameters["level_index"].ToString());
        Debug.Log(parameters["points"].ToString());
        Debug.Log(parameters["upgrade_choice"].ToString());
        Debug.Log(parameters["powerup_obtained"].ToString());
        AnalyticsService.Instance.CustomData("level_complete", parameters);
        
        if (a == "Menu")
        {
            upgradeInit.lvlduration = 60f;
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            upgradeInit.lvlduration += 10f; 
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
        opti.SetActive(upgradeInit.showOpt);
        upgradeInit.showOpt = !upgradeInit.showOpt;
    }

    public void sound()
    {
        AudioListener.volume = volume;
        if (volume == 1)
        {
            volume = 0;
            state = true;
            thistext.text = "Sound On";
        }
        else
        {
            volume = 1;
            state = false;
            thistext.text = "Sound Off";
        }
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"sound_state", state},
        };
        Debug.Log(parameters["sound_state"]);
        AnalyticsService.Instance.CustomData("sound_toggle", parameters);
    }
}

