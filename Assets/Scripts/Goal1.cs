using UnityEngine;
using System.Collections;

public class Goal1 : MonoBehaviour {
    public GameObject[] triggerZones;
    private Level1Logic level1Logic;

    void Awake() {
        level1Logic = FindObjectOfType<Level1Logic>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        int mostRecentTriggerIndex = 0;
        float mostRecentTriggerTime = 0;
        for (int i = 0 ; i < 5 ; i++) {
            float thisTriggerTime = triggerZones[i].GetComponent<TriggerZoneRecord>().lastTrigger;
            if (thisTriggerTime > mostRecentTriggerTime) {
                mostRecentTriggerTime = thisTriggerTime;
                mostRecentTriggerIndex = i;
            }
        }
        level1Logic.solutions[mostRecentTriggerIndex] = true;
        level1Logic.resetLevel();
    }
}
