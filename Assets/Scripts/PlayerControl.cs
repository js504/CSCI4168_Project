using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public Animator animator;
	public float speed = 10.0f;
	public Text livesText;
	bool facingRight = true;
	bool rooted = false;

	Rigidbody rb;

	private int countlives; //counting lives

	// Use this for initialization
	void Start () {
		countlives = 5; //started lives from five, will increase when picking up acrons and decrease when losing a fight with enemy 
		SetLivesText (); // calling the function to display lives on screen
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if(Input.GetKeyDown("left ctrl")){
			print("ctrled!");
			rooted = !rooted;
			animator.SetBool ("rooted", rooted);

			rb.isKinematic = rooted;
			rb.detectCollisions = !rooted;
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
			playerRot.y = 180f;


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
