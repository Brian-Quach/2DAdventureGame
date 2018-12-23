﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float speed = 10f;

    private Rigidbody2D body2d;

	void Start () {
        body2d = GetComponent<Rigidbody2D>();	
	}
	
	void Update () {
        body2d.velocity = new Vector2(transform.localScale.x, 0) * speed;	
	}
}
