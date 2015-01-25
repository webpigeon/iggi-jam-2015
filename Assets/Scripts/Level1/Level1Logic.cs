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
    public GameObject[] triggerZones;

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
        playerScript.forcePositionVector = new Vector3(-7.5f, -3f, 0f);
        playerScript.forcePosition = true;

        playerScript.Key = false;

        triggerZones[0].SetActive(!solutions[0]);
        triggerZones[1].SetActive(solutions[0] && !solutions[1]);
        triggerZones[2].SetActive(solutions[1] && !solutions[2]);
        triggerZones[3].SetActive(!solutions[3]);
        triggerZones[4].SetActive(!solutions[4]);

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

		bool allComplete = true;
		for (int i=0; i<solutions.Length; i++) {
			allComplete = allComplete && solutions [i];
		}

		if (allComplete) {
			Application.LoadLevel ("Level2");
		}

    }
}
