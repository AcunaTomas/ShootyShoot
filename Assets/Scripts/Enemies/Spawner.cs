using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Generic Enemy;
    public float spawningInterval;
    void Start()
    {
        StartCoroutine(WasteTime());
    }

    IEnumerator Spawn(float interval)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var original = transform.GetChild(i).gameObject;

            var E = Instantiate(original, original.transform.position, original.transform.rotation);

            E.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(spawningInterval);
        StartCoroutine(Spawn(spawningInterval));

    }

    private void Activate(string tag)
    {
        if (gameObject.CompareTag(tag))
        {
            gameObject.SetActive(true);
        }
    }

    IEnumerator WasteTime()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Spawn(spawningInterval));
    }
}
