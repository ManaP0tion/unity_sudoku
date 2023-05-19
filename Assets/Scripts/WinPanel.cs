using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public GameObject WinPanelObject;
    GameObject CheckComplete;
    // Start is called before the first frame update
    void Start()
    {
        setInActive();
        CheckComplete = GameObject.Find("SudokuField");
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckComplete.GetComponent<Board>().CheckGrid() == true)
        {
            setActive();
        }
    }

    void setInActive()
    {
        WinPanelObject.SetActive(false);
    }
    void setActive()
    {
        WinPanelObject.SetActive(true);
    }
}
