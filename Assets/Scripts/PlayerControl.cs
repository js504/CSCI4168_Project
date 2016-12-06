using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	AudioSource sound;
	public AudioClip rootingSound;
	public Animator animator;
	public float speed = 10.0f;
	bool facingRight = true;
	bool rooted = false;

	Rigidbody rb;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		rb = GetComponent<Rigidbody>();
		sound = GetComponent<AudioSource> ();

	}

	void Update(){

		if(Input.GetKeyDown("left ctrl")){
			rooted = !rooted;
			animator.SetBool ("rooted", rooted);


			rb.isKinematic = rooted;
			rb.detectCollisions = !rooted;

			if(rooted){
				sound.PlayOneShot(rootingSound);//activating the rooting sound
			}


	
		}
	}

	// Update is called once per frame
	void FixedUpdate () {


		if (!rooted) {
			if (Input.GetAxis ("Horizontal") != 0) {
				animator.SetBool ("walking", true);

				if (Input.GetAxis ("Horizontal") > 0) {
					if (!facingRight) {
						FlipDirection ();
					}

					transform.Translate (Vector3.right * Time.deltaTime * speed);
				} else if (Input.GetAxis ("Horizontal") < 0) {

					if (facingRight) {
						FlipDirection ();
					}

					transform.Translate (Vector3.left * Time.deltaTime * speed * -1f);
				}
			} else {
				animator.SetBool ("walking", false);
			}
		}
	}

	void FlipDirection(){
		
		facingRight = !facingRight;
	
		Vector3 cameraRot = Camera.main.transform.eulerAngles;
		Vector3 cameraPos = Camera.main.transform.localPosition;
		Vector3 playerRot = transform.eulerAngles;

		if (!facingRight) {
			cameraRot.y = 180f;
			playerRot.y = 180.0f;


		} else {
			cameraRot.y = 180f;
			playerRot.y = 0f;


		}

		Camera.main.transform.eulerAngles = cameraRot;

		cameraPos.z *= -1f;
		cameraPos.x *= -1f;


		transform.eulerAngles = playerRot;
		Camera.main.transform.localPosition = cameraPos;
	}

	public bool getFacingRight(){
		return facingRight;
	}
		


}
