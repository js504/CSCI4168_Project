using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Animator animator;
	public float speed = 10.0f;
	bool facingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool ("walking", true);

			if (Input.GetAxis ("Horizontal") > 0) {
				print ("right");
				if (!facingRight) {
					FlipDirection ();
				}
				transform.Translate (Vector3.right * Time.deltaTime * speed);
			} else if (Input.GetAxis ("Horizontal") < 0){

				print ("left");
				if (facingRight) {
					FlipDirection ();
				}
//				transform.rotation = Quaternion.Euler (0, 0, 0);
				transform.Translate (Vector3.left * Time.deltaTime * speed * -1f);
			}
		} else {
			animator.SetBool ("walking", false);
		}
	}

	void FlipDirection(){
		
//		Vector3 scale = transform.localScale;
//		scale.x *= -1;
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
		}
	}
}
