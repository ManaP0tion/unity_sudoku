using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Board : MonoBehaviour
{
    int[,] solvedGrid = new int[9, 9]; // answer
    public int[,] riddleGrid = new int[9, 9]; // hidden grid
    public int[] CountElements = Enumerable.Repeat<int>(0, 10).ToArray<int>();
    public GameManager gameManager;
    string str;

    // 난이도 설정
    int placesToErace = Difficulty.difficulty;

    // 3x3 배열 
    public Transform square00, square01, square02,
        square10, square11, square12,
        square20, square21, square22;

    public GameObject SudokuCell_Prefab;

    void Start()
    {
        InitGrid(ref solvedGrid);
        DebugGrid(ref solvedGrid);
        ShuffleGrid(ref solvedGrid, 3);
        CreateRiddleGrid();
        CreateButtons();
        Debug.Log("difficulty: " + placesToErace);
        UpdateCountElement();
    }

    void Update()
    {
        CheckGrid();// 디버깅을 위해 결과 체크
    }

    void InitGrid(ref int[,] grid) // 9x9 배열 생성
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
            }
        }

        // debug
        int n1 = 8 * 3;
        int n2 = 8 / 3;
        int n = (n1 + n2 + 0) % 9 + 1;
        print(n1 + "+" + n2 + "+" + 0);
        print(n);
    }

    void DebugGrid(ref int[,] grid) // grid 값 출력을 위한 함수임
    {
        str = "";
        int sep = 0;
        for (int i = 0; i < 9; i++)
        {
            str += "|";
            for (int j = 0; j < 9; j++)
            {
                str += grid[i, j].ToString();

                sep = j % 3;
                if (sep == 2)
                {
                    str += "|";
                }
            }

            str += "\n";
        }
        print(str);
    }

    void ShuffleGrid(ref int[,] grid, int shuffleAmount)
    {
        for (int i = 0; i < shuffleAmount; i++)
        {
            int value1 = Random.Range(1, 10);
            int value2 = Random.Range(1, 10);

            //Mix two cells
            MixTwoGridCells(grid, value1, value2);
        }
        DebugGrid(ref grid);
    }


    void MixTwoGridCells(int[,] grid, int value1, int value2)
    {
        int x1 = 0, x2 = 0, y1 = 0, y2 = 0;

        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (grid[i + k, j + l] == value1)
                        {
                            x1 = i + k;
                            y1 = j + l;
                        }

                        if (grid[i + k, j + l] == value2)
                        {
                            x2 = i + k;
                            y2 = j + l;
                        }
                    }
                }
                grid[x1, y1] = value2;
                grid[x2, y2] = value1;
            }
        }
    }

    void CreateRiddleGrid()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                riddleGrid[i, j] = solvedGrid[i, j];
            }
        }

        //Erase from riddleGrid
        for (int i = 0; i < placesToErace; i++)
        {
            int x1 = Random.Range(0, 9);
            int y1 = Random.Range(0, 9);

            // Reroll untill we find one without a 0
            while (riddleGrid[x1, y1] == 0)
            {
                x1 = Random.Range(0, 9);
                y1 = Random.Range(0, 9);
            }

            // if we found one with no 0
            riddleGrid[x1, y1] = 0;
        }
        DebugGrid(ref riddleGrid);
    }


    public int GetRiddleGrid(int row, int col)
    {
        return riddleGrid[row, col];
    }

    void CreateButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject newButton = Instantiate(SudokuCell_Prefab);
                SudokuCell sudokuCell = newButton.GetComponent<SudokuCell>();
                sudokuCell.SetValue(i, j, riddleGrid[i, j], i + "," + j, this);
                newButton.name = i.ToString() + j.ToString();

                if (i < 3)
                {
                    if (j < 3)
                    {
                        newButton.transform.SetParent(square00, false);
                    }
                    if (j > 2 && j < 6)
                    {
                        newButton.transform.SetParent(square01, false);
                    }
                    if (j >= 6)
                    {
                        newButton.transform.SetParent(square02, false);
                    }
                }

                if (i >= 3 && i < 6)
                {
                    if (j < 3)
                    {
                        newButton.transform.SetParent(square10, false);
                    }
                    if (j > 2 && j < 6)
                    {
                        newButton.transform.SetParent(square11, false);
                    }
                    if (j >= 6)
                    {
                        newButton.transform.SetParent(square12, false);
                    }
                }

                if (i >= 6)
                {
                    if (j < 3)
                    {
                        newButton.transform.SetParent(square20, false);
                    }
                    if (j > 2 && j < 6)
                    {
                        newButton.transform.SetParent(square21, false);
                    }
                    if (j >= 6)
                    {
                        newButton.transform.SetParent(square22, false);
                    }
                }

            }
        }
    }
    public void UpdatePuzzle(int row, int col, int value)
    {
        riddleGrid[row, col] = value;
        UpdateCountElement();
    }

    public bool CheckGrid()        //플레이어의 결과 확인
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (riddleGrid[i, j] != solvedGrid[i, j])
                {
                    return false;
                }
            }
        }
        Debug.Log("Complete");
        return true;
    }

    public void UpdateCountElement()
    {
        // Initialize to 0 in EveryUpdate
        for (int i = 1; i <= 9; i++)
        {
            CountElements[i] = 0;
        }

        // 배열에 존재하는 1~9 의 개수를 확인한다
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    if (riddleGrid[i, j] == k)
                    {
                        CountElements[k]++;
                    }
                }
            }
        }

        for (int i = 1; i <= 9; i++)
            Debug.Log(i + "개수: " + CountElements[i]);
    }
}
