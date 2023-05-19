using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPrefabObject : MonoBehaviour
{

    private int _row;
    private int _col;
    private GameObject _instance;

    public FieldPrefabObject(GameObject instance, int row, int col)
    {
        //Board board;

        _instance = instance;
        Row = row;
        Col = col;
    }

    public int Row { get => _row; set => _row = value; }
    public int Col { get => _col; set => _col = value; }

    public void SetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color32(114, 181, 255,255);
    }

    public void UnSetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
