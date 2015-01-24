using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public float speed;
	public float displacement;
	private GameObject character;
	private Vector3 target;
	private Vector3 startPos;
	private Vector3 leftPos;
	private Vector3 rightPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		leftPos = new Vector3 (startPos.x - displacement, startPos.y, 0);
		rightPos = new Vector3 (startPos.x + displacement, startPos.y, 0);
		target = leftPos;
	}
	
	// Update is called once per frame
	void Update () {

		float speedDelta = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, speedDelta);

		float delta = Vector3.Distance(target, transform.position);
		if (delta == 0) {
			if (target == leftPos) {
				target = rightPos;
			} else {
				target = leftPos;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "CharacterRobotBoy") {
			Debug.Log("Trigger was... er... triggered...");
			character = col.gameObject;
			character.transform.parent = this.gameObject.transform;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		Debug.Log("I'm free!");
		if (col.gameObject.name == "CharacterRobotBoy" && character != null) {
			character.transform.parent = null;
			character = null;
		}
	}
}
