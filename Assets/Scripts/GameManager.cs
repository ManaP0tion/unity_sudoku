using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    GameObject CheckComplete;
    public bool isGameOver;
    // Start is called before the first frame update

    void Start()
    {
        isGameOver = false;
        winUI.SetActive(false);
        CheckComplete = GameObject.Find("SudokuField");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            winUI.SetActive(true);
            return;
        }
        if (CheckComplete.GetComponent<Board>().CheckGrid() == true)
        {
            setGameOver();
        }
    }
     public void setGameOver()
        {
            isGameOver = true;
        }

}
