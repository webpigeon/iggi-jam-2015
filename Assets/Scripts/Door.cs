using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public BoxCollider2D[] colliders;

	void Start () {
        colliders = gameObject.GetComponents<BoxCollider2D>();

	}

    void OnTriggerEnter2D(Collider2D collider) {
        PlatformerCharacter2D player = collider.attachedRigidbody.gameObject.GetComponent<PlatformerCharacter2D>();
        if (player != null && player.Key == true) {
            foreach (BoxCollider2D col in colliders) {
                Destroy(col);
            }
            // TODO: We should also animate
        }
    }
}
 