using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public Animator animator;
	public float speed = 10.0f;
	public Text livesText;
	bool facingRight = true;

	private int countlives; //counting lives

	// Use this for initialization
	void Start () {
		countlives = 5; //started lives from five, will increase when picking up acrons and decrease when losing a fight with enemy 
		SetLivesText (); // calling the function to display lives on screen
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool ("walking", true);

			if (Input.GetAxis ("Horizontal") > 0) {
				if (!facingRight) {
					FlipDirection ();
				}

				transform.Translate (Vector3.right * Time.deltaTime * speed);
			} else if (Input.GetAxis ("Horizontal") < 0){

				if (facingRight) {
					FlipDirection ();
				}

				transform.Translate (Vector3.left * Time.deltaTime * speed * -1f);
			}
		} else {
			animator.SetBool ("walking", false);
		}
	}

	void FlipDirection(){
		
		facingRight = !facingRight;
	
		Quaternion cameraRot = Camera.main.transform.localRotation;
		Vector3 cameraPos = Camera.main.transform.localPosition;
		Quaternion playerRot = transform.localRotation;

		if (!facingRight) {
			print ("changing Rot1");
			cameraRot.y = 180f;
			playerRot.y = 180f;

		} else {
			print ("changing Rot2");
			cameraRot.y = 0f;
			playerRot.y = 0f;

		}
		cameraPos.z *= -1f;
		cameraPos.x *= -1f;

		transform.localRotation = playerRot;

		Camera.main.transform.localRotation = cameraRot;

		Camera.main.transform.localPosition = cameraPos;



	}

	//an acron object will be deactivated everytime it collides with the player
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			countlives = countlives + 1;
			SetLivesText (); // calling the function to keep updating on desplay lives
		}
	}

	void SetLivesText ()
	{
		livesText.text= "Lives: " + countlives.ToString();
	}


}
