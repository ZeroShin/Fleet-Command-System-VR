using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twingkle : MonoBehaviour
{
    public GameObject flick;

    void Start()
    {
        StartCoroutine(ShowReady());
    }
    
    IEnumerator ShowReady()
    {
        while(true)
        {
            flick.SetActive(false);
            yield return new WaitForSeconds(0.4f);
            flick.SetActive(true);
            yield return new WaitForSeconds(0.9f);
        }
    }

}
