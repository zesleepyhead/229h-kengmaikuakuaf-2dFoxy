using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    public Text ammoText;
    private int ammo = 0;

    void Update()
    {
        scoreText.text = "X " + score;
        ammoText.text = "X " + ammo;
    }

    public void AddScore()
    {
        score += 1;
    }

    public void AddAmmo()
    {
        ammo += 1;
    }

    public int CheckScore()
    {
        return score;
    }

    public int CheckAmmo()
    {
        return ammo;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
