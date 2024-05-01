using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject victoryPanel;
    public Text scoreText;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            victoryPanel.SetActive(true);
            scoreText.text = "X " + gameManager.GetComponent<CheckPoint>().CheckScore();
        }
    }
}
