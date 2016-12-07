using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Start () {
		score.text = "Score: " + GlobalSettings.score.ToString ();
	}


	public void LoadNextLevel(){

		if (GlobalSettings.levelIndex == 3) {
			GlobalSettings.levelIndex = 1;
		} else {
			GlobalSettings.levelIndex++;
		}

		SceneManager.LoadScene (GlobalSettings.levelIndex, LoadSceneMode.Single); 
	}

	public void ExitGame(){
		Application.Quit ();
	}


}
