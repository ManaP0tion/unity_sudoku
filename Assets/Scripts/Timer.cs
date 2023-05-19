using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TMP_Text timer;
    GameObject CheckComplete;
    

     void Start()
    {
        timer = GetComponentInChildren<TMP_Text>();
        CheckComplete = GameObject.Find("SudokuField");
        
    }

    void Update()
    {
        float time = Time.timeSinceLevelLoad;
        int seconds = (int)time % 60;
        time /= 60;
        int minutes = (int)(time % 60);

        timer.text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));

        if(CheckComplete.GetComponent<Board>().CheckGrid() == true)
        {
            PauseGame();
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
