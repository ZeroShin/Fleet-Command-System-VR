using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respown : MonoBehaviour
{
    GameObject enemy;
    GameObject ally;
    // Start is called before the first frame update
    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        ally = GameObject.FindWithTag("Ally");
        enemy.SetActive(false);
        ally.SetActive(false);
    }

    private void LateUpdate()
    {
        enemy.SetActive(true);
        ally.SetActive(true);
        gameObject.SetActive(false);
    }

}
