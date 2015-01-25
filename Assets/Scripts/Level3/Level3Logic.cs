using UnityEngine;
using System.Collections;

public class Level3Logic : MonoBehaviour {
    public GameObject movingPlatformWeak;
    public GameObject movingPlatformStrong;
    public GameObject door;
    public GameObject goalLower;
    public GameObject goalHigher;
    public GameObject keyHigher;
    public GameObject keyLower;
    public GameObject keyClimbable;
    public GameObject player;

    public int solutions = 0;
    private PlatformerCharacter2D playerScript;

	void Start () {
        playerScript = player.GetComponent<PlatformerCharacter2D>();
        resetLevel();
	}

    public void resetLevel() {
        playerScript.forcePositionVector = new Vector3(-8f, -0.5f, 0f);
        playerScript.forcePosition = true;
		playerScript.Key = false;

        movingPlatformStrong.SetActive(solutions != 1);
        movingPlatformWeak.SetActive(solutions == 1);
        door.SetActive(solutions > 2);
		door.GetComponent<BoxCollider2D> ().enabled = true;
        goalLower.SetActive(solutions != 2);
        goalHigher.SetActive(!goalLower.activeInHierarchy);
        keyHigher.SetActive(solutions == 4);
        keyClimbable.SetActive(solutions == 2 || solutions == 4);
        keyLower.SetActive(!keyClimbable.activeInHierarchy);

		if (solutions == 5) {
			Application.LoadLevel ("gamewin");
		}

    }
}
