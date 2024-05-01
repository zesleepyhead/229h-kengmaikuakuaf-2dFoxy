using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gameManager;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<CheckPoint>().AddScore();

            Destroy(gameObject);
        }
    }
}
