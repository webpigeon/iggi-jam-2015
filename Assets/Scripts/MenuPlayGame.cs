using UnityEngine;
using System.Collections;

public class MenuPlayGame : MonoBehaviour {
	public void OnClickPlay(){
		Application.LoadLevel ("Level1");
	}

	public void OnClickCredits(){
		Application.LoadLevel ("Credits");
	}

	public void OnBackFromCredits(){
		Application.LoadLevel ("MainMenu");
	}
}
