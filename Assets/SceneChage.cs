using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChage : MonoBehaviour
{
    public void RuleScene()
    {
        SceneManager.LoadScene("Rule");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
