using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Start () {
		score.text = GlobalSettings.playerHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene ("Level2", LoadSceneMode.Single);
	}
}
