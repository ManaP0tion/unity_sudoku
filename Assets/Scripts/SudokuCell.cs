using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SudokuCell : MonoBehaviour
{
    Board board;

    int row;
    int col;
    int value;
    string id;
    public TMP_Text text;

    public void SetValue(int _row, int _col, int value, string _id, Board _board)
    {
        row = _row;
        col = _col; 
        id= _id;
        board = _board;
        

        if (value != 0)
        {
            text.text = value.ToString();
            GetComponentInParent<Button>().enabled = false;
        }
        else
        {
            text.text = " ";
            text.color = new Color32(110, 255, 255, 255);
        }
    }
    public void ButtonClicked()
    {
        Debug.Log("col: " + col + " row: " + row);
        InputButton.instance.ActivateInputButton(this);
    }

    public void UpdateValue(int newValue)
    {
        value = newValue;

        if (value != 0)
        {
            text.text = value.ToString();
        }
        else
        {
            text.text = "";
        }
        board.UpdatePuzzle(row, col, value);
    }
}
