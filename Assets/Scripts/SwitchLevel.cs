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

			GlobalSettings.playerAcorns = pc.GetPlayerAcorns ();
			GlobalSettings.playerHealth = pc.GetPlayerHealth ();
			GlobalSettings.playerLives = pc.GetPlayerLives ();
			StartCoroutine (WaitRoutine ());
		}
	}


	IEnumerator WaitRoutine(){

		yield return new WaitForSeconds (10f);
		SceneManager.LoadScene (GlobalSettings.levelIndex, LoadSceneMode.Single);

	}

}
