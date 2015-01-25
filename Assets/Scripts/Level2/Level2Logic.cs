using UnityEngine;
using System.Collections;

public class Level2Logic : MonoBehaviour {
    public GameObject box3a;
    public GameObject box3b;
    public GameObject wallLeft;
    public GameObject wallRightFake;
    public GameObject wallRightReal;
    public GameObject player;
    public GameObject[] triggerZones;

    public bool[] solutions = { false, false, false, false };
    private PlatformerCharacter2D playerScript;

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<PlatformerCharacter2D>();
        resetLevel();
	}

    public void resetLevel() {
        playerScript.forcePositionVector = new Vector3(-7.5f, -3f, 0f);
        playerScript.forcePosition = true;
		playerScript.Key = false;

        triggerZones[0].SetActive(!solutions[0]);
        triggerZones[1].SetActive(solutions[0] && !solutions[1]);
        triggerZones[2].SetActive(solutions[0] && !solutions[2]);
        triggerZones[3].SetActive(solutions[0] && !solutions[3]);
        box3a.SetActive(!solutions[0]);
        box3b.SetActive(solutions[0]);
        wallLeft.SetActive(solutions[2]);
        wallRightFake.SetActive(solutions[1]);
        wallRightReal.SetActive(solutions[3]);

		bool allComplete = true;
		for (int i=0; i<solutions.Length; i++) {
			allComplete = allComplete && solutions [i];
		}
		
		if (allComplete) {
			Application.LoadLevel ("Level3");
		}
    }
}
