using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerCharacter : MonoBehaviour {


	int health;		//number of chops it takes the enemy to cut you down
	int numLives;
	public Text livesText;

	public Transform hand;
	public GameObject acornAmmoRef;

	private GameObject acorn;

	int atkCount = 0;

	PlayerControl playerControl;

	// Use this for initialization
	void Start () {
		playerControl = GetComponent<PlayerControl> ();
		acorn = (GameObject)Instantiate (acornAmmoRef, hand);
		acorn.transform.localPosition = new Vector3 (0f, 0f, 0f);
		numLives = 5; //started lives from five, will increase when picking up acrons and decrease when losing a fight with enemy 
		SetLivesText (); // calling the function to display lives on screen
		health = 4; 

		//hand = transform.Find ("PlayerMiddleFinger").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			ThrowAcorn ();
		}
	}

	//an acorn object will be deactivated everytime it collides with the player
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			numLives = numLives + 1;
			SetLivesText (); // calling the function to keep updating on display lives
		} else if(other.gameObject.CompareTag("Weapon")){
			
			print ("attacked " + atkCount++);
		}
	}

	void SetLivesText ()
	{
		livesText.text= "Lives: " + numLives.ToString();
	}

	void ThrowAcorn(){
		acorn.transform.parent = null;
		Vector3 force;
		if (playerControl.getFacingRight ()) {
			force = new Vector3 (1f, 0.25f, 0f);
		} else {
			force = new Vector3 (-1f, 0.25f, 0f);
		}

		acorn.GetComponent<Rigidbody> ().AddRelativeForce (force * 30f, ForceMode.Impulse);
		acorn.GetComponent<Rigidbody> ().useGravity = true;

		acorn = null;

		acorn = (GameObject)Instantiate (acornAmmoRef, hand);
		acorn.transform.localPosition = new Vector3 (0f, 0f, 0f);
	}

}
