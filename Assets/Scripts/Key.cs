using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        PlatformerCharacter2D player = collider.gameObject.GetComponent<PlatformerCharacter2D>();
        if (player != null) {
            player.Key = true;
            Destroy(gameObject);
        }
    }
}
