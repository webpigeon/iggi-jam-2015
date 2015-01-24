using UnityEngine;
using System.Collections;

public class TriggerZoneRecord : MonoBehaviour {
    public float lastTrigger = 0;
    public int id = -1; // Used for debugging

    void OnTriggerEnter2D() {
        lastTrigger = Time.time;
    }
}
