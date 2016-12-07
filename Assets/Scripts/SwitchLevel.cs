using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			PlayerCharacter pc = other.gameObject.GetComponent<PlayerCharacter> ();

			GlobalSettings.playerAcorns = 10;
			GlobalSettings.playerHealth = 100;
			GlobalSettings.playerLives = pc.GetPlayerLives ();
			StartCoroutine (WaitRoutine ());
		}
	}


	IEnumerator WaitRoutine(){

		yield return new WaitForSeconds (20f);
		SceneManager.LoadScene ("EndOfLevel", LoadSceneMode.Single);

	}

}
