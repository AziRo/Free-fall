﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
	
    public float speed;


	void FixedUpdate () {
        transform.Translate(Vector3.up * speed);
	}
}
