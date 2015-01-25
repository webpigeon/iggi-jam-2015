using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public bool requiresKey = false;
    private BoxCollider2D[] colliders;

	void Start () {
        colliders = gameObject.GetComponents<BoxCollider2D>();
	}

    void OnTriggerEnter2D(Collider2D collider) {
        PlatformerCharacter2D player = collider.attachedRigidbody.gameObject.GetComponent<PlatformerCharacter2D>();
        if (player != null && (requiresKey == false || player.Key == true)) {
            foreach (BoxCollider2D col in colliders) {
                col.enabled = false;
            }
			player.playDoorSound();
            // TODO: We should also animate. Instead we just destroy the object to be lazy.
            gameObject.SetActive(false);
        }
    }
}
 