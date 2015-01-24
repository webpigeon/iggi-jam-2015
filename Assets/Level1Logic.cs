using UnityEngine;
using System.Collections;

public class Level1Logic : MonoBehaviour {
    public GameObject wallShort;
    public GameObject wallTall;
    public GameObject wallLeft;
    public GameObject wallRight;
    public GameObject keyLower;
    public GameObject keyHigher;
    public GameObject door;
    public GameObject goal;
    public GameObject player;

    public bool[] solutions = { false, false, false, false, false };
    private PlatformerCharacter2D playerScript;
    private Door doorScript;

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<PlatformerCharacter2D>();
        doorScript = door.GetComponent<Door>();
        resetLevel();
	}

    public void resetLevel() {
        player.transform.position.Set(-7.5f, -3f, 0f);
        player.GetComponent<Rigidbody2D>().Sleep();
        playerScript.Key = false;

        wallShort.SetActive(solutions[0]);
        door.SetActive(solutions[0]);
        if (solutions[0]) {
            BoxCollider2D[] colliders = door.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D col in colliders) {
                col.enabled = true;
            }
        }
        doorScript.requiresKey = solutions[1];
        keyLower.SetActive(!solutions[2]);
        keyHigher.SetActive(solutions[2]);
        wallTall.SetActive(solutions[3]);
        wallLeft.SetActive(solutions[4]);
        wallRight.SetActive(solutions[4]);

    }
}
