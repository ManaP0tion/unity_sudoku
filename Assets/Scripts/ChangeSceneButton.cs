using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : MonoBehaviour
{
    public void SetDifficulty()
    {
        SceneManager.LoadScene("SelectDifficultyScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("종료 시도");
    }
}
