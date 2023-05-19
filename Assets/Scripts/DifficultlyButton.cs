using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultlyButton : MonoBehaviour
{
    public void SetDifficultyEasy()
    {
        Difficulty.difficulty = 20;
        SceneManager.LoadScene("PlayScene");
    }

    public void SetDifficultyNormal()
    {
        Difficulty.difficulty = 35;
        SceneManager.LoadScene("PlayScene");
    }

    public void SetDifficultyHard()
    {
        Difficulty.difficulty = 50;
        SceneManager.LoadScene("PlayScene");
    }
}
