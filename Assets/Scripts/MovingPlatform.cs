using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public int minUnits;
	public int maxUnits;
	public float currentUnits;
	public float speed;
	private PlatformerCharacter2D character;

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

		if (character != null) {
			character.AdjustMove(currentUnits);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "CharacterRobotBoy") {
			Debug.Log("Trigger was... er... triggered...");
			character = col.gameObject.GetComponent<PlatformerCharacter2D>();
		}
	}

	void onTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "CharacterRobotBoy") {
			character = null;
		}
	}
}
