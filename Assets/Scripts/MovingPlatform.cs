using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public int minUnits;
	public int maxUnits;
	public float currentUnits;
	public float speed;

	// Use this for initialization
	void Start () {
		this.speed = -0.1f;
		this.minUnits = -2;
		this.maxUnits = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentUnits < minUnits) {
			speed = 0.1f;
		}

		if (currentUnits > maxUnits) {
			speed = -0.1f;
		}

		currentUnits += speed;
		transform.Translate (currentUnits * Time.deltaTime, 0, 0);
	}
}
