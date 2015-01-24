using UnityEngine;
using System.Collections;

public class Goal1 : MonoBehaviour {
    private Level1Logic level1Logic;
    private int i = 0;

    void Awake() {
        level1Logic = FindObjectOfType<Level1Logic>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        level1Logic.solutions[i++] = true;
        level1Logic.resetLevel();
    }
}
