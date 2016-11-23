using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuControl : MonoBehaviour {

	// Use this for initialization
	public void NewGameHandler(){
		Application.LoadLevel (1);
	}

	public void ExitGameHandler(){
		Application.Quit ();
	}
}
