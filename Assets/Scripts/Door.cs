using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public BoxCollider2D[] colliders;
    public bool requiresKey = false;

	void Start () {
        colliders = gameObject.GetComponents<BoxCollider2D>();

	}

    void OnTriggerEnter2D(Collider2D collider) {
        PlatformerCharacter2D player = collider.attachedRigidbody.gameObject.GetComponent<PlatformerCharacter2D>();
        if (player != null && (requiresKey == false || player.Key == true)) {
            foreach (BoxCollider2D col in colliders) {
                col.enabled = false;
            }
            // TODO: We should also animate. Instead we just destroy the object to be lazy.
            gameObject.SetActive(false);
        }
    }
}
 