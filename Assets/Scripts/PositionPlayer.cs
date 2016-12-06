using UnityEngine;
using System.Collections;

public class PositionPlayer : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerCharacter pc = player.GetComponent<PlayerCharacter> ();

		pc.SetPlayerAcorns (GlobalSettings.playerAcorns);
		pc.SetPlayerHealth (GlobalSettings.playerHealth);
		pc.SetPlayerLives (GlobalSettings.playerLives);
//		if (player != null) {
//			print ("Found the player!");
//
//			player.transform.position = new Vector3 (0f, 0f, 0f);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
