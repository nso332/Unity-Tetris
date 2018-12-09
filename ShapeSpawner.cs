﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public GameObject[] shapes;

    public void SpawnShape()
    {
        int shapeIndex = Random.Range(0, 6);

        Instantiate(shapes[shapeIndex], transform.position, Quaternion.identity);
        // shape index between 0-6, transform positoin is the position of the shape spawner, quaternion handles rotation
    }

	// Use this for initialization
	void Start () {
        SpawnShape();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
