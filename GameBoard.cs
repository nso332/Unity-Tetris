using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour {
    //sets the gameboard object group to be centered with the camera
    public static Transform[,] gameBoard = new Transform[10, 20];

    //public static void DebugingPrintArray()
    //{
    //    string debugingArray = "";

    //    int iMax = gameBoard.GetLength(0) - 1;
    //    int jMax = gameBoard.GetLength(1) - 1;

    //    for(int j = jMax; j>= 0; j--)
    //    {
    //        for (int i = 0; i <= iMax; i++)
    //        {
    //            if (gameBoard[i, j] == null)
    //                debugingArray += "N ";
    //            else
    //                debugingArray += "X";
    //        }
    //        debugingArray += "\n \n";
    //    }
    //    var myArrayComp = GameObject.Find("MyArray").GetComponent<Text>();
    //    myArrayComp.text = debugingArray;
    //}
    public static bool DeleteAllFullRows()
    {//cycles through the 20 rows
        for (int row = 0; row < 20; ++ row)
        {//goes through each column in the row if it is full
            if(IsRowFull(row))
            {
                DeleteGBRow(row);
                //sound could be inserted here if desired
                //DeleteGBRow(row);
                return true;
            }
        }
        return false;
    }
    public static bool IsRowFull(int row)
    {//cycles through the columns
        for (int col = 0; col < 10; ++col)
        {
            //returns false if no rows full
            if (gameBoard[col, row] == null)
                return false;
        }
        return true;
    }

    public static void DeleteGBRow(int row)
    { //deletes in both the row and the array, first for destroying cubes in scene, second for destroying inside of array
        for (int col = 0; col < 10; ++ col)
        {
            Destroy(gameBoard[col, row].gameObject);
            gameBoard[col, row] = null;
        }
        row++;
        // cycles through the 20 rows
        for(int j = row; j < 20; ++j)
        {
            // cycles through all columns
            for(int col = 0; col < 10; ++col)
            {
                // checks for block
                if (gameBoard[col,j] != null)
                {
                    //moves stuff above into deleted row
                    gameBoard[col, j -1] = gameBoard[col, j];
                    // cube gets deleted in array
                    gameBoard[col, j] = null;
                    // cube cube deleted on board
                    gameBoard[col, j - 1].position += new Vector3(0, -1, 0);
                    //break;
                }
            }
            //DeleteGBRow(row);
        }
    }
}