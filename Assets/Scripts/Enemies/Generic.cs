using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour //Enemy Template class - create enemies by deriving from this class 
{
    private int type = 1;
    public Proyectiles Bala;
    private bool invis = true;
    public int hp = 3;
    public float dir = -4f;
    public float swift = 0.3f;
    public float time = 0.05f;
    public int score = 15;

    public int getType()
    {
        return type;
    }




    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(0.2f);
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
            Debug.Log(hp);
        if (hp < 1)
        {
           var man = GameObject.Find("GameManager");
           man.gameObject.SendMessage("Score", score);
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
