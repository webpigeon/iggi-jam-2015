﻿using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public float speed;
	public float displacement;
	public bool stopMoving;

	private bool shouldMove;
	private GameObject character;
	private Vector3 target;
	private Vector3 startPos;
	private Vector3 leftPos;
	private Vector3 rightPos;

	void Start () {
		shouldMove = true;
		startPos = transform.position;
		leftPos = new Vector3 (startPos.x - displacement, startPos.y, 0);
		rightPos = new Vector3 (startPos.x + displacement, startPos.y, 0);
		target = rightPos;
	}
	
	void Update () {
		if (shouldMove) {
			float speedDelta = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target, speedDelta);
			float delta = Vector3.Distance (target, transform.position);
			if (delta <= 0.01) {
				if (target == leftPos) {
					target = rightPos;
				} else {
					target = leftPos;
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.GetComponent<PlatformerCharacter2D>() != null) {
			//Debug.Log("Trigger was... er... triggered...");
			character = col.gameObject;
			character.transform.parent = this.gameObject.transform;

			if (stopMoving) {
				shouldMove = false;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.GetComponent<PlatformerCharacter2D>() != null) {
			character.transform.parent = null;
			character = null;

			if (stopMoving) {
				shouldMove = true;
			}
		}
	}
}
