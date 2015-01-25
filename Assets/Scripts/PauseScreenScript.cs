using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class PauseScreenScript : MonoBehaviour {


	public static PauseScreenScript Instance;
	
	void Awake()
	{
		if (Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}


	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
