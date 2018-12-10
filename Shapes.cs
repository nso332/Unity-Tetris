using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {
    // sets shape fall speed
    public float speed = 1.0f;
    //used for telling if shape needs to move down
    float lastMoveDown = 0;

	// Update is called once per frame
	void Update () {//move left
        if (Input.GetKeyDown("a"))
        {//polymorphism (below)
            transform.position += new Vector3(-1, 0, 0);

            if(!IsInGrid())
                transform.position += new Vector3(1, 0, 0);
            else
                UpdateGameBoard();
        }//move right
        if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsInGrid())
                transform.position += new Vector3(-1, 0, 0);
            else
                UpdateGameBoard();
        }//move down
        if (Input.GetKeyDown("s") || Time.time -lastMoveDown >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsInGrid())
            {
                transform.position += new Vector3(0, 1, 0);

                bool rowDeleted = GameBoard.DeleteAllFullRows();

                if(rowDeleted)
                    GameBoard.DeleteAllFullRows();
                    //IncreaseTextUIScore();
                enabled = false;
                FindObjectOfType<ShapeSpawner>().SpawnShape();
            }
            else
                UpdateGameBoard();
            lastMoveDown = Time.time;
        }//rotate left
        if (Input.GetKeyDown("w"))
        {
            transform.Rotate(0, 0, 90);
            if (!IsInGrid())
                transform.Rotate(0, 0, -90);
            else
                UpdateGameBoard();
        }//rotate right
        if (Input.GetKeyDown("e"))
        {
            transform.Rotate(0, 0, -90);
            if (!IsInGrid())
                transform.Rotate(0, 0, 90);
            else
                UpdateGameBoard();
        }
    }
    public bool IsInGrid()
    {      //checks if shape can go in cell
        foreach(Transform hiddenArray in transform)
        {
            Vector2 vect = RoundVector(hiddenArray.position);
            if(!IsInBorder(vect))
                return false;
            if(GameBoard.gameBoard[(int)vect.x, (int)vect.y] != null && GameBoard.gameBoard[(int)vect.x, (int)vect.y].parent != transform)
                return false;
        }
        return true;
    }

    public Vector2 RoundVector(Vector2 vect)
    {
        //vector 2 is a struct in this instance, used to round up 
        return new Vector2(Mathf.Round(vect.x), Mathf.Round(vect.y));
    }
    public static bool IsInBorder(Vector2 pos)
    {
            return ((int)pos.x >= 0 && (int)pos.x <= 9 && (int)pos.y >= 0);
    }
    // puts down the shape if it touches other shapes or the bottom of the array
    public void UpdateGameBoard()
    {
        for(int y = 0; y < 20; ++y)
        {
            for(int x = 0; x<10; ++x)
            {
                if(GameBoard.gameBoard[x,y] != null && GameBoard.gameBoard[x, y].parent == transform)
                    {
                        GameBoard.gameBoard[x, y] = null;
                    }
            }
        }
        // creates an array using cubes in unity
        foreach(Transform hiddenArray in transform)
        {
            Vector2 vect = RoundVector(hiddenArray.position);

            GameBoard.gameBoard[(int)vect.x, (int)vect.y] = hiddenArray;

            //Debug.Log("Cube At : " + vect.x + " " + vect.y);
        }

        //GameBoard.DebugingPrintArray();
    }

    //void IncreaseTextUIScore()
    //{
    //    var textUIComp = GameObject.Find("Score").GetComponent<Text>();

    //    int score = int.Parse(textUIComp.text);

    //    score++;

    //    textUIComp.text = score.ToString();
    //}
}
