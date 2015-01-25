using UnityEngine;
using System.Collections;

public class Goal2 : MonoBehaviour {
    public GameObject[] triggerZones;
    private Level2Logic level2Logic;

    void Awake() {
        level2Logic = FindObjectOfType<Level2Logic>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        int mostRecentTriggerIndex = 0;
        float mostRecentTriggerTime = 0;
        for (int i = 0 ; i < 4 ; i++) {
            float thisTriggerTime = triggerZones[i].GetComponent<TriggerZoneRecord>().lastTrigger;
            if (thisTriggerTime > mostRecentTriggerTime) {
                mostRecentTriggerTime = thisTriggerTime;
                mostRecentTriggerIndex = i;
            }
        }
        level2Logic.solutions[mostRecentTriggerIndex] = true;
        level2Logic.resetLevel();
    }
}
