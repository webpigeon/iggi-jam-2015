using UnityEngine;
using System.Collections;

public class MenuPlayGame : MonoBehaviour {
	public void OnClickPlay(){
		Application.LoadLevel ("Level1");
	}

	public void onClickQuit() {
		Debug.Log ("maple");
		Application.Quit ();
	}
}
