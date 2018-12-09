using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour {

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-1, 0, 0);

            Debug.Log(transform.position);

            if(!IsInBorder(transform.position))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(1, 0, 0);

            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown("s"))
        {
            transform.position += new Vector3(0, -1, 0);

            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown("w"))
        {
            transform.Rotate(0, 0, 90);

            Debug.Log(transform.position);
        }

        
    }
    public static bool IsInBorder(Vector2 pos)
    {
            return ((int)pos.x >= -5.6 && (int)pos.x <= 2.4 && (int)pos.y >= -9.8);
    }
}
