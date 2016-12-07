using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {


	public GameObject player;
	public Text health;
	public Text lives;
	public Text acorns;

	PlayerCharacter pc;

	// Use this for initialization
	void Start () {
		pc = player.GetComponent<PlayerCharacter> ();
	}
	
	// Update is called once per frame
	void Update () {
		health.text = "Health: " + pc.GetPlayerHealth ().ToString();
		lives.text = "Lives: " + pc.GetPlayerLives ().ToString();
		acorns.text = "Acorns: " + pc.GetPlayerAcorns ().ToString();
	}
}
