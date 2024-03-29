using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Generic : MonoBehaviour //Enemy Template class - create enemies by deriving from this class 
{
    
    private int type = 1;
    public Proyectiles Bala;
    public PPup Power;
    private bool invis = true;
    public int hp = 3;
    public float dir = -4f;
    public float swift = 0.3f;
    public float time = 0.05f;
    public byte chance = 220;
    public int score = 15;
    public float timeout =25f;



    public int getType()
    {
        return type;
    }




    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(1f);
        invis = false;
        yield return new WaitForSeconds(25f);
        Destroy(gameObject);
    }

    private void Die()
    {
        if (invis == true)
        {
            
        }
        else
        {
        hp += -1;
            if (hp < 1)
            {
                var man = GameObject.Find("GameManager");

                var rand = new System.Random();
                byte[] b = new byte[1];
                rand.NextBytes(b);
                if (b[0] > chance)
                {
                    PPup v = Instantiate(Power, transform.position, Power.transform.rotation);
                    v.gameObject.SetActive(true);
                    Debug.Log(b[0]);
                }

                man.gameObject.SendMessage("Score", score);
                man.gameObject.SendMessage("Explode", transform);
                Destroy(gameObject); 
        }
        
        }

        
    }

    private void Attack()
    {
        Proyectiles a = Instantiate(Bala, transform.position, Bala.transform.rotation);
        a.direction = -7;
        a.target = "Player";
        a.setColors();
        a.gameObject.SetActive(true);
    }


}
