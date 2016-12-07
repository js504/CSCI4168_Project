using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerCharacter : MonoBehaviour {


	int health;		//number of chops it takes the enemy to cut you down
	int numLives;
	int numAcorns;
	public Text livesText;

	public Transform hand;
	public GameObject acornAmmoRef;
	AudioSource sound;
	public AudioClip throwAcornSound;

	private GameObject acorn;

	int atkCount = 0;

	PlayerControl playerControl;

	bool thrown = false;
	bool onFire = false;

	Vector3 weaponOrigin = new Vector3 (0f, 0f, 0f);
	// Use this for initialization
	void Start () {
		playerControl = GetComponent<PlayerControl> ();
		sound = GetComponent<AudioSource> ();

		//acorn = (GameObject)Instantiate (acornAmmoRef, hand);
		//acorn.transform.localPosition = new Vector3 (0f, 0f, 0f);
		numLives = 5; //started lives from five, will increase when picking up acrons and decrease when losing a fight with enemy 
		SetLivesText (); // calling the function to display lives on screen
		health = 100;
		numAcorns = 2;

		GlobalSettings.playerHealth = health;
		GlobalSettings.playerLives = numLives;
		GlobalSettings.playerLives = numAcorns;

		//hand = transform.Find ("PlayerMiddleFinger").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("space")) {
			if(numAcorns > 0){
				thrown = true;
				ThrowAcorn ();
				sound.PlayOneShot(throwAcornSound);//activating throw sound 
			}
		}

		if (!thrown) {
			//acorn.transform.localPosition = weaponOrigin;
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
		acorn = (GameObject)Instantiate (acornAmmoRef, hand);
		acorn.transform.localPosition = new Vector3 (0f, 0f, 0f);

		acorn.transform.parent = null;
		Vector3 force;
		if (playerControl.getFacingRight ()) {
			force = new Vector3 (1f, 0.25f, 0f);
		} else {
			force = new Vector3 (-1f, 0.25f, 0f);
		}

		acorn.GetComponent<Rigidbody> ().AddRelativeForce (force * 30f, ForceMode.Impulse);
		acorn.GetComponent<Rigidbody> ().useGravity = true;

		numAcorns--;

		acorn = null;



		thrown = false;

	}

	public void SetPlayerHealth(int health){
		this.health = health;
	}


	public void SetPlayerAcorns(int numAcorns){
		this.numAcorns = numAcorns;
	}

	public void SetPlayerLives(int numLives){
		this.numLives = numLives;
	}

	public int GetPlayerHealth(){
		return health;
	}


	public int GetPlayerAcorns(){
		return numAcorns;
	}

	public int GetPlayerLives(){
		return numLives;
	}

	public void SetOnFire(bool onFire){
		this.onFire = onFire;
	}

	public bool GetOnFire(){
		return onFire;
	}
}
