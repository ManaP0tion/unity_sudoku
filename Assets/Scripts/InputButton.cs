using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputButton : MonoBehaviour
{
    public int[] count_element = new int[10];
    private GameObject GO;

    public TMP_Text count1_text, count2_text, count3_text,
        count4_text,  count5_text, count6_text, count7_text, count8_text, count9_text;

    public static InputButton instance;
    SudokuCell lastCell;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateInputButton(SudokuCell cell)
    {
        this.gameObject.SetActive(true);
        this.lastCell = cell;
    }
    public void ClickedButton(int num)
    {
        lastCell.UpdateValue(num);
        this.gameObject.SetActive(false);
    }

    // 현재 그리드에 있는 1~9까지의 개수를 나타냄
    public void UpdateElementCount()
    {
        GO = GameObject.Find("SudokuField");

        for (int i = 1; i <= 9; i++)
        {
            count_element[i] = GO.GetComponent<Board>().CountElements[i];
        }
        count1_text.text = count_element[1].ToString();
        count2_text.text = count_element[2].ToString();
        count3_text.text = count_element[3].ToString();
        count4_text.text = count_element[4].ToString();
        count5_text.text = count_element[5].ToString();
        count6_text.text = count_element[6].ToString();
        count7_text.text = count_element[7].ToString();
        count8_text.text = count_element[8].ToString();
        count9_text.text = count_element[9].ToString();
    }

    private void Update()
    {
        UpdateElementCount();  
    }
}
