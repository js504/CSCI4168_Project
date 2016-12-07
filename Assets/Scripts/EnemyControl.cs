using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public Animator animator;
	public float patrolDistance = 1.0f;
	public float speed = 2.0f;
	Vector3 velocity;
	bool facingLeft;

	Vector3 startPos;

	bool moving;
	bool attack;
	bool knockedOut;

	int triggerHit = 0;
	int acornHit = 0;


	bool burning;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		velocity = new Vector3 (speed, 0, 0);
		animator.SetBool ("walking", true);

		moving = true;
	    facingLeft = true;
		attack = false;
		knockedOut = false;
		burning = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		RaycastHit hit;
		Ray sightRay;

		if (burning) {
			animator.SetBool ("walking", false);
			animator.SetBool ("attack", false);
			animator.SetBool ("knockedOut", true);
		} else {
			if (moving && !knockedOut) {
				float distanceTravelled = transform.position.x - startPos.x;
				//print (distanceTravelled);
				if (facingLeft) {


					if ((-distanceTravelled >= patrolDistance) && !attack) {

						FlipDirection ();
					}

					sightRay = new Ray (transform.position, Vector3.left);

					transform.Translate (velocity * Time.deltaTime * -1.0f);
				} else {

							
					if ((distanceTravelled >= patrolDistance) && !attack) {

						FlipDirection ();

					}

					sightRay = new Ray (transform.position, Vector3.right);


					transform.Translate (velocity * Time.deltaTime * -1.0f);

				}

				if (Physics.Raycast (sightRay, out hit, 100.0f)) {
					if (hit.collider.tag == "Player") {
						//print ("i see the player");
					}
				}
			}
		}


	}
		


	void FlipDirection(){
		facingLeft = !facingLeft;

		Vector3 enemyRot = transform.eulerAngles;

		if (!facingLeft) {

			enemyRot.y = 180f;

		} else {

			enemyRot.y = 0f;

		}

		transform.eulerAngles = enemyRot;


		if (!attack) {
			StartCoroutine (WaitRoutine ());
		}



	}

	void attackPlayer(Collider other){
		attack = true;
		velocity = new Vector3 (10f, 0, 0);

		if ((other.gameObject.transform.position.x < transform.position.x) && !facingLeft) {
			
			FlipDirection ();
		} else if((other.gameObject.transform.position.x > transform.position.x) && facingLeft){
			
			FlipDirection ();
		}
	}

	IEnumerator WaitRoutine(){

		animator.SetBool ("walking", false);
		moving = false;
		yield return new WaitForSeconds (5f);
		moving = true;
		animator.SetBool ("walking", true);

	}


	IEnumerator KnockedOutRoutine(){

		animator.SetBool ("walking", false);
		animator.SetBool ("knockedOut", true);

		moving = false;
		knockedOut = true;

		yield return new WaitForSeconds (10f);

		knockedOut = false;
		moving = true;

		acornHit = 0;

		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<BoxCollider> ().isTrigger = false;

		animator.SetBool ("knockedOut", false);
		animator.SetBool ("walking", true);

	}

	void OnTriggerEnter(Collider other){

		if (!burning) {
			if (other.gameObject.tag.Equals ("Player")) {
				triggerHit++;

				if (!knockedOut) {

					if ((other.gameObject.transform.position.x < transform.position.x) && facingLeft || (other.gameObject.transform.position.x > transform.position.x) && facingLeft) {

						attackPlayer (other);

						if (triggerHit == 2) {
							animator.SetBool ("attack", true);
							other.gameObject.GetComponent<PlayerCharacter> ().hit (2);
						}


					}

				}
			} else if (other.gameObject.tag.Equals ("AcornProjectile") && !knockedOut) {
				acornHit++;
				if (acornHit > 2) {
					print ("im hit!");
					knockedOut = true;
					GetComponent<Rigidbody> ().isKinematic = true;
					GetComponent<BoxCollider> ().isTrigger = true;
					StartCoroutine (KnockedOutRoutine ());
				}
			}
		}

	}

	void OnTriggerExit(Collider other){

		if (!burning) {
			if (other.gameObject.tag.Equals ("Player")) {
		
				if (triggerHit > 0) {
					triggerHit--;
				} else if (triggerHit < 0) {
					triggerHit = 0;
				}

				print (triggerHit);

				if (triggerHit == 0) {
					attack = false;
					velocity = new Vector3 (speed, 0, 0);
				}

			} else if (other.gameObject.tag.Equals ("AcornProjectile") && !knockedOut) {

				acornHit--;

				if (acornHit < 0) {
					acornHit = 0;
				}
			}


			if (!attack || knockedOut) {
				animator.SetBool ("attack", false);
			}
		}
			
	}

	public void SetOnFire(bool onFire){
		this.burning = onFire;
	}

	public bool GetOnFire(){
		return burning;
	}

}
