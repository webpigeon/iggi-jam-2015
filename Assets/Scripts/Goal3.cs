using UnityEngine;
using System.Collections;

public class Goal3 : MonoBehaviour {
    private Level3Logic level3Logic;

    void Awake() {
        level3Logic = FindObjectOfType<Level3Logic>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        level3Logic.solutions++;
        level3Logic.resetLevel();
    }
}
